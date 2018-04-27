using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TowerDefenceGame
{
	using GameCore;

	public partial class TowerDefenceGame_Form:Form
	{
		public TowerDefenceGame_Form()
		{
			InitializeComponent();
			redOutline=new Pen(Color.FromArgb(255,255,0,0));
			backgroundFlush=Color.FromArgb(0,255,255,255);
			defence=new List<PictureBox>();
			defence.Add(pictureDefence_00);
			defence.Add(pictureDefence_01);
			defence.Add(pictureDefence_02);
			defence.Add(pictureDefence_03);
			defence.Add(pictureDefence_10);
			defence.Add(pictureDefence_11);
			defence.Add(pictureDefence_12);
			defence.Add(pictureDefence_13);
			defence.Add(pictureDefence_20);
			defence.Add(pictureDefence_21);
			defence.Add(pictureDefence_22);
			defence.Add(pictureDefence_23);
		}

		#region Глобальные данные формы
		private const string
			dataDir="TowerDefenceGame_Data",
			dataDirNotFoundText="Директория данных приложения не обнаружена.",
			dataErrorText="Ошибка данных.",
			appExitText="\r\nЗавершение работы программы.",
			askClosingProgram="Закрыть программу ?\r\n(нет - для выхода в главное меню)",
			warningMessage="Внимание",
			errorMessage="Ошибка";
		private List<PictureBox> defence;
		private Image
			openspotImg,
			fireDefenceImg,
			laserDefenceImg,
			critfireDefenceImg;
		private Pen redOutline;
		private Color backgroundFlush;
		private GameField field;

		#endregion

		#region Свойства
		public Image FireDefenceImg { get { return fireDefenceImg; } }
		public Image LaserDefenceImg { get { return laserDefenceImg; } }
		public Image CritFireDefenceImg { get { return critfireDefenceImg; } }
		public Pen RedOutline { get { return redOutline; } }
		public Color BackgroundFlush { get { return backgroundFlush; } }
		public GameField Field { get { return field; } }

		#endregion


		#region Дополнительные функции
		private bool LoadImage(PictureBox component, string filePath)
		{
			if (File.Exists(filePath))
			{
				component.Image=Image.FromFile(filePath);
				/*if (component.Image.Width>component.Width || component.Image.Height>component.Height)
					component.SizeMode=PictureBoxSizeMode.Zoom;
				else
					component.SizeMode=PictureBoxSizeMode.CenterImage;*/
				if (component.Width!=component.Image.Width || component.Height!=component.Image.Height)
					return false;
				else {}
				return true;
			} else
				return false;
		}
		private void AlignControls(Control parent)
		{
			List<Control> subs=new List<Control>();
			Control current;
			int i=0,g;
			for (;i<parent.Controls.Count;i++)
				subs.Add(parent.Controls[i]);
			for (i=0;i<subs.Count;i++)
				for (g=0;g<subs.Count;g++)
					if (Convert.ToInt32(subs[i].Tag)<Convert.ToInt32(subs[g].Tag))
					{
						current=subs[i];
						subs[i]=subs[g];
						subs[g]=current;
						current=null;
					} else {}
			for (i=0;i<subs.Count;i++)
			{
				subs[i].BringToFront();
				subs[i]=null;
			}
			subs.Clear();
			subs=null;
		}
		private void StartGame()
		{
			field=new GameField(12,pictureGameField);
			try
			{
				for (int i=0;i<defence.Count;i++)
					field.Monsters[i]=new Defence(defence[i],openspotImg,backgroundFlush);
			} catch
			{
				MessageBox.Show(dataErrorText+appExitText,errorMessage,MessageBoxButtons.OK,MessageBoxIcon.Error);
				Process.GetCurrentProcess().Kill();
			}
		}
		private void StopGame()
		{
			// 
			field=null;
		}

		#endregion

		#region Работа с формой
		private void TowerDefenceGame_Form_Load(object sender,EventArgs e)
		{
			string errorMessgae="";
			int i=0;
			if (!Directory.Exists(dataDir))
			{
				errorMessgae=dataDirNotFoundText+appExitText;
				goto end;
			} else {}

			try
			{
				openspotImg=Image.FromFile(dataDir+"\\Images\\Objects\\openspot.png");
				fireDefenceImg=Image.FromFile(dataDir+"\\Images\\Monsters\\fire_defence.png");
				laserDefenceImg=Image.FromFile(dataDir+"\\Images\\Monsters\\laser_defence.png");
				critfireDefenceImg=Image.FromFile(dataDir+"\\Images\\Monsters\\critfire_defence.png");
			} catch
			{
				errorMessgae=dataErrorText+appExitText;
				goto end;
			}
			if (
					!LoadImage(pictureMainMenu,dataDir+"\\Images\\Backgrounds\\main_background.png") ||
					!LoadImage(pictureButton_Play,dataDir+"\\Images\\Buttons\\play_default.png") ||
					!LoadImage(pictureButton_Info,dataDir+"\\Images\\Buttons\\info_default.png") ||
					!LoadImage(pictureButton_Exit,dataDir+"\\Images\\Buttons\\exit_default.png") ||
					!LoadImage(pictureGameField,dataDir+"\\Images\\Backgrounds\\game_background.png") ||
					!LoadImage(pictureGameTower,dataDir+"\\Images\\Objects\\tower.png")
				)
			{
				errorMessgae=dataErrorText+appExitText;
				goto end;
			} else {}

			panelMainMenu.Parent=this;
			panelGameField.Parent=this;
			this.ClientSize=new Size(800,600);
			this.CenterToScreen();
			
			pictureMainMenu.Parent=panelMainMenu;
			panelMainMenu.Size=this.ClientSize;
			pictureButton_Play.Parent=pictureMainMenu;
			pictureButton_Info.Parent=pictureMainMenu;
			pictureButton_Exit.Parent=pictureMainMenu;

			pictureGameField.Parent=panelGameField;
			panelGameField.Size=this.ClientSize;
			pictureGameTower.Parent=pictureGameField;
			for (;i<defence.Count;i++)
				defence[i].Parent=pictureGameField;

			AlignControls(this);
			AlignControls(panelMainMenu);
			AlignControls(pictureMainMenu);
			AlignControls(panelGameField);
			AlignControls(pictureGameField);

			panelGameField.Visible=false;

			end:;
			if (errorMessgae!="")
			{
				MessageBox.Show(errorMessgae,errorMessage,MessageBoxButtons.OK,MessageBoxIcon.Error);
				Process.GetCurrentProcess().Kill();
			} else {}
		}
		private void TowerDefenceGame_Form_FormClosing(object sender,FormClosingEventArgs e)
		{
			if (panelGameField.Visible)
			{
				// игру на паузу
				DialogResult answer=MessageBox.Show(askClosingProgram,warningMessage,MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);
				switch (answer)
				{
					case DialogResult.No:
						e.Cancel=true;
						panelGameField.Visible=false;
						panelMainMenu.Visible=true;		
						break;
					case DialogResult.Cancel:
						e.Cancel=true;
						// продолжить игру
						break;
				}
			} else {}
		}

		#endregion

		#region Главное меню
		private void picturePlay_Button_Click(object sender,EventArgs e)
		{
			panelMainMenu.Visible=false;
			panelGameField.Visible=true;
			StartGame();
		}
		private void pictureInfo_Button_Click(object sender,EventArgs e)
		{
			//
		}
		private void pictureExit_Button_Click(object sender,EventArgs e)
		{
			Application.Exit();
		}

		#endregion

		#region Работа с Defence
		private void pictureDefence_MouseEnter(object sender,EventArgs e)
		{
			field.Monsters[Convert.ToInt32((sender as PictureBox).Tag)-1].MouseEnter(redOutline);
			GC.Collect();
		}
		private void pictureDefence_MouseLeave(object sender,EventArgs e)
		{
			field.Monsters[Convert.ToInt32((sender as PictureBox).Tag)-1].MouseLeave();
			GC.Collect();
		}
		private void pictureDefence_Click(object sender,EventArgs e)
		{
			int index=Convert.ToInt32((sender as PictureBox).Tag)-1;
			if (field.Monsters[index].OpenSpot)
			{
				SelectDefence_Form selector;
				try
				{
					selector=new SelectDefence_Form(this,index);
				} catch
				{
					MessageBox.Show(dataErrorText+appExitText,errorMessage,MessageBoxButtons.OK,MessageBoxIcon.Error);
					Process.GetCurrentProcess().Kill();
					return;
				}
				selector.ShowDialog();
				selector.Dispose();
				selector=null;
			} else
			{
				// здесь варево с прокачкой и выпиливанием
			}
		}

		#endregion

		private void pictureGameField_MouseMove(object sender,MouseEventArgs e)
		{
			Point outLoc=e.Location;
			PictureBox current=(sender as PictureBox);
			if (current!=pictureGameField)
			{
				outLoc.X+=current.Location.X;
				outLoc.Y+=current.Location.Y;
			}
			for (int i=0;i<field.Monsters.Count;i++)
				field.Monsters[i].AimTarget(outLoc);
		}

		~TowerDefenceGame_Form()
		{
			StopGame();
			for (int i=0;i<defence.Count;i++)
				defence[i]=null;
			defence.Clear();
			defence=null;
			openspotImg.Dispose();
			fireDefenceImg.Dispose();
			laserDefenceImg.Dispose();
			critfireDefenceImg.Dispose();
			openspotImg=fireDefenceImg=laserDefenceImg=critfireDefenceImg=null;
			redOutline.Dispose();
			redOutline=null;
			backgroundFlush=Color.Empty;
			/*

		private GameField field;
			*/
		}
	}
}
