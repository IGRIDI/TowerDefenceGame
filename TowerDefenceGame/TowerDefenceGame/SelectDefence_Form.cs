using System;
using System.Drawing;
using System.Windows.Forms;

namespace TowerDefenceGame
{
	using GameCore;
	public partial class SelectDefence_Form:Form
	{
		public SelectDefence_Form(TowerDefenceGame_Form link, int defIndex)
		{
			InitializeComponent();
			parent=link;
			this.CenterToParent();
			defenceIndex=defIndex;
			SetImage(pictureFireDefence,parent.FireDefenceImg);
			SetImage(pictureLaserDefence,parent.LaserDefenceImg);
			SetImage(pictureCritFireDefence,parent.CritFireDefenceImg);
		}

		private TowerDefenceGame_Form parent;
		private int defenceIndex;

		private void SetImage(PictureBox component, Image img)
		{
			if (component.Width!=img.Width || component.Height!=img.Height)
				throw new ArgumentOutOfRangeException("Ошибка размера изображения.");
			else {}
			if (component.Tag!=null)
				try { (component.Tag as Graphics).Dispose(); } catch {}
			else {}
			component.Tag=null;
			component.Image=(Image)img.Clone();
			component.Tag=Graphics.FromImage(component.Image);
		}

		private void SelectDefence_Form_KeyUp(object sender,KeyEventArgs e)
		{
			if (e.KeyValue==27)
			{
				this.DialogResult=DialogResult.None;
				this.Close();
			} else {}
		}
		private void pictureSelect_MouseEnter(object sender,EventArgs e)
		{
			PictureBox current=(sender as PictureBox);
			Graphics canvas=(current.Tag as Graphics);
			canvas.DrawRectangle(parent.RedOutline,0,0,current.Image.Width-1,current.Image.Height-1);
			current.Refresh();
			canvas=null;
			current=null;
			GC.Collect();
		}
		private void pictureSelect_MouseLeave(object sender,EventArgs e)
		{
			PictureBox current=(sender as PictureBox);
			Graphics canvas=(current.Tag as Graphics);
			canvas.Clear(parent.BackgroundFlush);
			if (current==pictureFireDefence)
				canvas.DrawImage(parent.FireDefenceImg,0,0,parent.FireDefenceImg.Width,parent.FireDefenceImg.Height);
			else
			if (current==pictureLaserDefence)
				canvas.DrawImage(parent.LaserDefenceImg,0,0,parent.LaserDefenceImg.Width,parent.LaserDefenceImg.Height);
			else
			if (current==pictureCritFireDefence)
				canvas.DrawImage(parent.CritFireDefenceImg,0,0,parent.CritFireDefenceImg.Width,parent.CritFireDefenceImg.Height);
			else
				throw new InvalidOperationException("Что то пошло не так ...");
			current.Refresh();
			canvas=null;
			current=null;
			GC.Collect();
		}
		private void pictureSelect_Click(object sender,EventArgs e)
		{
			PictureBox
				current=(sender as PictureBox),
				targetControl=parent.Field.Monsters[defenceIndex].Control;
			Defence newObj;
			parent.Field.Monsters[defenceIndex].Dispose();
			parent.Field.Monsters[defenceIndex]=null;
			GC.Collect();
			if (current==pictureFireDefence)
				newObj=new FireMonster(targetControl,parent.FireDefenceImg,parent.BackgroundFlush);
			else
			if (current==pictureLaserDefence)
				newObj=new LaserMonster(targetControl,parent.LaserDefenceImg,parent.BackgroundFlush);
			else
			if (current==pictureCritFireDefence)
				newObj=new CritFireMonster(targetControl,parent.CritFireDefenceImg,parent.BackgroundFlush);
			else
				throw new InvalidOperationException("Что то пошло не так ...");
			parent.Field.Monsters[defenceIndex]=newObj;
			newObj=null;
			this.DialogResult=DialogResult.OK;
			this.Close();
		}

		~SelectDefence_Form()
		{
			try { pictureFireDefence.Image.Dispose(); } catch {}
			try { pictureLaserDefence.Image.Dispose(); } catch {}
			try { pictureCritFireDefence.Image.Dispose(); } catch {}
			pictureFireDefence.Image=pictureLaserDefence.Image=pictureCritFireDefence.Image=null;
			try { (pictureFireDefence.Tag as Graphics).Dispose(); } catch {}
			try { (pictureLaserDefence.Tag as Graphics).Dispose(); } catch {}
			try { (pictureCritFireDefence.Tag as Graphics).Dispose(); } catch {}
			pictureFireDefence.Tag=pictureLaserDefence.Tag=pictureCritFireDefence.Tag=null;
			parent=null;
		}
	}
}
