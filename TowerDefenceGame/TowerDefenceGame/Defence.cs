using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace TowerDefenceGame.GameCore
{
	public class Defence
	{
		public Defence(PictureBox box, Image img, Color backgroundFlush)
		{
			if (box.Width!=img.Width || box.Height!=img.Height)
				throw new ArgumentOutOfRangeException("Ошибка размера изображения.");
			else {}
			openSpot=true;
			toGrad=180/Math.PI;
			currentAngle=0;
			mouseEnter=false;
			control=box;
			controlLoc=new Point(control.Location.X,control.Location.Y);
			controlSize=new Size(control.Width,control.Height);
			centerPos=new Point(control.Location.X+control.Width/2,control.Location.Y+control.Height/2);
			initialImage=img;
			control.Image=(Image)initialImage.Clone();
			imageSize=new Size(control.Image.Width,control.Image.Height);
			canvas=Graphics.FromImage(control.Image);
			rotate=Graphics.FromImage(control.Image);
			rotate.TranslateTransform(initialImage.Width/2,initialImage.Height/2);
		}
		
		protected bool openSpot;
		private readonly double toGrad;
		private double currentAngle;
		private bool mouseEnter;
		private PictureBox control;
		private Point controlLoc,centerPos;
		private Size controlSize,imageSize;
		private Image initialImage;
		private Graphics canvas,rotate;
		private Color bgFlush;
		private GameField field;
		private Thread processor;

		public bool OpenSpot { get { return openSpot; } }
		public PictureBox Control { get { return control; } }

		public void MouseEnter(Pen p)
		{
			canvas.DrawRectangle(p,0,0,imageSize.Width-1,imageSize.Height-1);
			if (control.InvokeRequired)
				control.Invoke(new Action(() => { control.Refresh(); } ));
			else
				control.Refresh();
			mouseEnter=true;
		}
		public void MouseLeave()
		{
			ResetImage(0);
			mouseEnter=false;
		}

		private void ResetImage(float rotateAngle)
		{
			rotate.Clear(bgFlush);
			rotate.RotateTransform(rotateAngle);
			rotate.DrawImage(
				initialImage,
				0-rotate.Transform.OffsetX,
				0-rotate.Transform.OffsetY,
				initialImage.Width,
				initialImage.Height);
			if (control.InvokeRequired)
				control.Invoke(new Action(() => { control.Refresh(); } ));
			else
				control.Refresh();
		}
		protected virtual Enemy SearchTarget() { return null; }
		public void AimTarget(Point coords)
		{
			if (openSpot)
				return;
			else {}
			if (
					coords.X>=controlLoc.X && coords.X<=controlLoc.X+controlSize.Width &&
					coords.Y>=controlLoc.Y && coords.Y<=controlLoc.Y+controlSize.Height)
				return;
			else {}
			double sideA,sideB,sideC,quarter;
			if (coords.X<centerPos.X && coords.Y<=centerPos.Y)
			{ // левая верхняя четверть
				sideA=centerPos.X-coords.X;
				sideB=centerPos.Y-coords.Y;
				quarter=0;
			} else
			if (coords.X>=centerPos.X && coords.Y<centerPos.Y)
			{ // правая верхняя четверть
				sideA=centerPos.Y-coords.Y;
				sideB=coords.X-centerPos.X;
				quarter=90;
			} else
			if (coords.X>centerPos.X && coords.Y>=centerPos.Y)
			{ // правая нижняя четверть
				sideA=coords.X-centerPos.X;
				sideB=coords.Y-centerPos.Y;
				quarter=180;
			} else
			// if (coords.X<=centerPos.X && coords.Y>centerPos.Y)
			{ // левая нижняя четверть
				sideA=coords.Y-centerPos.Y;
				sideB=centerPos.X-coords.X;
				quarter=270;
			}
			sideC=Math.Sqrt(sideA*sideA+sideB*sideB);
			double
				// angleA=Math.Acos((sideB*sideB+sideC*sideC-sideA*sideA)/(2*sideB*sideC))*toGrad,
				angleB=Math.Acos((sideA*sideA+sideC*sideC-sideB*sideB)/(2*sideA*sideC))*toGrad+quarter,
				// angleC=Math.Acos((sideA*sideA+sideB*sideB-sideC*sideC)/(2*sideA*sideB))*toGrad;
				relativeAngle=angleB-currentAngle;
			if (relativeAngle>180)
				relativeAngle-=360;
			else {}
			ResetImage((float)relativeAngle);
			currentAngle=angleB;
		}
		protected virtual void SingleShot(int powerShot) {}

		protected void ProcessorFunc()
		{
			
		}

		public void Dispose()
		{
			if (control.InvokeRequired)
				control.Invoke(new Action(() => { Dispose(); }));
			else {}
			try { control.Image.Dispose(); } catch {}
			control.Image=null;
			control=null;
		}
		~Defence()
		{
			canvas.Dispose();
			rotate.Dispose();
			canvas=rotate=null;
			initialImage=null;
			centerPos=Point.Empty;
			bgFlush=Color.Empty;
			try { Dispose(); } catch {}
		}
	}

	class FireMonster:Defence
	{
		public FireMonster(PictureBox box, Image img, Color backgroundFlush):base(box,img,backgroundFlush)
		{ openSpot=false; }

		protected override Enemy SearchTarget()
		{
			return null;
		}
		protected override void SingleShot(int powerShot)
		{
			
		}
	}

	class LaserMonster:Defence
	{
		public LaserMonster(PictureBox box, Image img, Color backgroundFlush):base(box,img,backgroundFlush)
		{ openSpot=false; }

		protected override Enemy SearchTarget()
		{
			return null;
		}
		protected override void SingleShot(int powerShot)
		{
			
		}
	}

	class CritFireMonster:Defence
	{
		public CritFireMonster(PictureBox box, Image img, Color backgroundFlush):base(box,img,backgroundFlush)
		{ openSpot=false; }

		protected override Enemy SearchTarget()
		{
			return null;
		}
		protected override void SingleShot(int powerShot)
		{
			
		}
	}
}
