using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
namespace CAPSlock
{
    partial class CAPSControl
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
            //this.FormClosing += Form1_FormClosing;
            this.remoteDesktop1 = new VncSharp.RemoteDesktop();
            this.SuspendLayout();
            // 
            // remoteDesktop1
            // 
            this.remoteDesktop1.AutoScroll = true;
            this.remoteDesktop1.AutoScrollMinSize = new System.Drawing.Size(608, 427);
            this.remoteDesktop1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remoteDesktop1.Location = new System.Drawing.Point(0, 0);
            this.remoteDesktop1.Margin = new System.Windows.Forms.Padding(0);
            this.remoteDesktop1.Name = "remoteDesktop1";
            this.remoteDesktop1.Size = new System.Drawing.Size(965, 708);
            this.remoteDesktop1.TabIndex = 1;
            this.remoteDesktop1.Paint += new System.Windows.Forms.PaintEventHandler(this.remoteDesktop1_Paint);
            // 
            // CAPSControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 708);
            this.Controls.Add(this.remoteDesktop1);
            this.Name = "CAPSControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAPSControl";
            this.ResumeLayout(false);

        }

        /*private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

           
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();
            System.Threading.Thread.Sleep(1000);
            screenshot();
      

        }

        private void  screenshot()
        {
            string projectFolder = "..\\..\\";
            Bitmap captureBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
Screen.PrimaryScreen.Bounds.Height,
PixelFormat.Format32bppArgb);
            Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
            captureBitmap.Save(projectFolder + @"Image\test.jpg", ImageFormat.Jpeg);


        }*/
        #endregion

        private VncSharp.RemoteDesktop remoteDesktop1;
    }
}