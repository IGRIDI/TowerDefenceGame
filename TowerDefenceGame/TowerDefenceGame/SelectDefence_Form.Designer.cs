namespace TowerDefenceGame
{
	partial class SelectDefence_Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureFireDefence = new System.Windows.Forms.PictureBox();
			this.pictureLaserDefence = new System.Windows.Forms.PictureBox();
			this.pictureCritFireDefence = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureFireDefence)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureLaserDefence)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureCritFireDefence)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureFireDefence
			// 
			this.pictureFireDefence.Location = new System.Drawing.Point(34, 14);
			this.pictureFireDefence.Margin = new System.Windows.Forms.Padding(25, 5, 5, 5);
			this.pictureFireDefence.Name = "pictureFireDefence";
			this.pictureFireDefence.Size = new System.Drawing.Size(50, 50);
			this.pictureFireDefence.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureFireDefence.TabIndex = 0;
			this.pictureFireDefence.TabStop = false;
			this.pictureFireDefence.Click += new System.EventHandler(this.pictureSelect_Click);
			this.pictureFireDefence.MouseEnter += new System.EventHandler(this.pictureSelect_MouseEnter);
			this.pictureFireDefence.MouseLeave += new System.EventHandler(this.pictureSelect_MouseLeave);
			// 
			// pictureLaserDefence
			// 
			this.pictureLaserDefence.Location = new System.Drawing.Point(94, 14);
			this.pictureLaserDefence.Margin = new System.Windows.Forms.Padding(5);
			this.pictureLaserDefence.Name = "pictureLaserDefence";
			this.pictureLaserDefence.Size = new System.Drawing.Size(50, 50);
			this.pictureLaserDefence.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureLaserDefence.TabIndex = 1;
			this.pictureLaserDefence.TabStop = false;
			this.pictureLaserDefence.Click += new System.EventHandler(this.pictureSelect_Click);
			this.pictureLaserDefence.MouseEnter += new System.EventHandler(this.pictureSelect_MouseEnter);
			this.pictureLaserDefence.MouseLeave += new System.EventHandler(this.pictureSelect_MouseLeave);
			// 
			// pictureCritFireDefence
			// 
			this.pictureCritFireDefence.Location = new System.Drawing.Point(154, 14);
			this.pictureCritFireDefence.Margin = new System.Windows.Forms.Padding(5, 5, 25, 5);
			this.pictureCritFireDefence.Name = "pictureCritFireDefence";
			this.pictureCritFireDefence.Size = new System.Drawing.Size(50, 50);
			this.pictureCritFireDefence.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureCritFireDefence.TabIndex = 2;
			this.pictureCritFireDefence.TabStop = false;
			this.pictureCritFireDefence.Click += new System.EventHandler(this.pictureSelect_Click);
			this.pictureCritFireDefence.MouseEnter += new System.EventHandler(this.pictureSelect_MouseEnter);
			this.pictureCritFireDefence.MouseLeave += new System.EventHandler(this.pictureSelect_MouseLeave);
			// 
			// SelectDefence_Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ClientSize = new System.Drawing.Size(238, 78);
			this.Controls.Add(this.pictureCritFireDefence);
			this.Controls.Add(this.pictureLaserDefence);
			this.Controls.Add(this.pictureFireDefence);
			this.Font = new System.Drawing.Font("Times New Roman", 13F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.Name = "SelectDefence_Form";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SelectDefence_Form";
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SelectDefence_Form_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.pictureFireDefence)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureLaserDefence)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureCritFireDefence)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureFireDefence;
		private System.Windows.Forms.PictureBox pictureLaserDefence;
		private System.Windows.Forms.PictureBox pictureCritFireDefence;

	}
}