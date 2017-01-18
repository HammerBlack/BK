namespace OrderSystem_v1
{
    partial class Notice
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
            this.Conferm = new System.Windows.Forms.Button();
            this.BoxShow = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Conferm
            // 
            this.Conferm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Conferm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Conferm.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Conferm.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Conferm.Location = new System.Drawing.Point(65, 147);
            this.Conferm.Name = "Conferm";
            this.Conferm.Size = new System.Drawing.Size(98, 31);
            this.Conferm.TabIndex = 6;
            this.Conferm.Text = "確定";
            this.Conferm.UseVisualStyleBackColor = true;
            this.Conferm.Click += new System.EventHandler(this.Conferm_Click);
            this.Conferm.MouseEnter += new System.EventHandler(this.Conferm_MouseEnter);
            this.Conferm.MouseLeave += new System.EventHandler(this.Conferm_MouseLeave);
            // 
            // BoxShow
            // 
            this.BoxShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BoxShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BoxShow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BoxShow.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BoxShow.ForeColor = System.Drawing.SystemColors.Control;
            this.BoxShow.Location = new System.Drawing.Point(39, 73);
            this.BoxShow.Multiline = true;
            this.BoxShow.Name = "BoxShow";
            this.BoxShow.ReadOnly = true;
            this.BoxShow.Size = new System.Drawing.Size(148, 55);
            this.BoxShow.TabIndex = 13;
            this.BoxShow.Text = "登入成功";
            this.BoxShow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Notice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(231, 211);
            this.Controls.Add(this.BoxShow);
            this.Controls.Add(this.Conferm);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Notice";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Conferm;
        private System.Windows.Forms.TextBox BoxShow;
    }
}