namespace biometric_election_system
{
    partial class FingerPrint
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
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label14 = new System.Windows.Forms.Label();
            this.Thumbprintpic = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.FingerPrintUploader = new System.Windows.Forms.Button();
            this.FPNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Thumbprintpic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(421, 49);
            this.label1.TabIndex = 11;
            this.label1.Text = "Please upload your Fingerprint.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 159);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(449, 118);
            this.label14.TabIndex = 13;
            this.label14.Text = "- Upload your Thumb print.\r\n- Your Thumb print should match with Nadra Database.\r" +
    "\n- If not so, you are not able to Vote.\r\n\r\n\r\n";
            // 
            // Thumbprintpic
            // 
            this.Thumbprintpic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Thumbprintpic.Location = new System.Drawing.Point(529, 54);
            this.Thumbprintpic.Name = "Thumbprintpic";
            this.Thumbprintpic.Size = new System.Drawing.Size(214, 243);
            this.Thumbprintpic.TabIndex = 12;
            this.Thumbprintpic.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::biometric_election_system.Properties.Resources.Untitled;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 86);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // FingerPrintUploader
            // 
            this.FingerPrintUploader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.FingerPrintUploader.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(174)))), ((int)(((byte)(76)))));
            this.FingerPrintUploader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.FingerPrintUploader.ForeColor = System.Drawing.Color.White;
            this.FingerPrintUploader.Location = new System.Drawing.Point(589, 312);
            this.FingerPrintUploader.Name = "FingerPrintUploader";
            this.FingerPrintUploader.Size = new System.Drawing.Size(101, 41);
            this.FingerPrintUploader.TabIndex = 26;
            this.FingerPrintUploader.Text = "Browse";
            this.FingerPrintUploader.UseVisualStyleBackColor = false;
            this.FingerPrintUploader.Click += new System.EventHandler(this.FingerPrintUploader_Click);
            // 
            // FPNext
            // 
            this.FPNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.FPNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(174)))), ((int)(((byte)(76)))));
            this.FPNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.FPNext.ForeColor = System.Drawing.Color.White;
            this.FPNext.Location = new System.Drawing.Point(589, 359);
            this.FPNext.Name = "FPNext";
            this.FPNext.Size = new System.Drawing.Size(101, 41);
            this.FPNext.TabIndex = 27;
            this.FPNext.Text = "Next";
            this.FPNext.UseVisualStyleBackColor = false;
            this.FPNext.Visible = false;
            this.FPNext.Click += new System.EventHandler(this.FPNext_Click);
            // 
            // FingerPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(870, 459);
            this.Controls.Add(this.FPNext);
            this.Controls.Add(this.FingerPrintUploader);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Thumbprintpic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FingerPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FingerPrint";
            ((System.ComponentModel.ISupportInitialize)(this.Thumbprintpic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox Thumbprintpic;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button FingerPrintUploader;
        private System.Windows.Forms.Button FPNext;
    }
}