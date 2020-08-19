namespace ENothi_Desktop.Ui.CustomUserControl
{
    partial class DakAttachmentList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.attachmentName = new System.Windows.Forms.Label();
            this.mainLabel = new System.Windows.Forms.Label();
            this.downloadButton = new System.Windows.Forms.Button();
            this.attachmentTypePicBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attachmentTypePicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.downloadButton);
            this.panel1.Controls.Add(this.mainLabel);
            this.panel1.Controls.Add(this.attachmentName);
            this.panel1.Controls.Add(this.attachmentTypePicBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 46);
            this.panel1.TabIndex = 0;
            // 
            // attachmentName
            // 
            this.attachmentName.AutoSize = true;
            this.attachmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachmentName.Location = new System.Drawing.Point(51, 16);
            this.attachmentName.Name = "attachmentName";
            this.attachmentName.Size = new System.Drawing.Size(59, 16);
            this.attachmentName.TabIndex = 1;
            this.attachmentName.Text = "main.pdf";
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.BackColor = System.Drawing.Color.White;
            this.mainLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainLabel.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(168)))), ((int)(((byte)(0)))));
            this.mainLabel.Location = new System.Drawing.Point(118, 16);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(46, 18);
            this.mainLabel.TabIndex = 13;
            this.mainLabel.Text = "মূল পত্র";
            this.mainLabel.Visible = false;
            this.mainLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainLabel_Paint);
            // 
            // downloadButton
            // 
            this.downloadButton.FlatAppearance.BorderSize = 0;
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadButton.Image = global::ENothi_Desktop.Properties.Resources.icons8_downloading_updates_25px;
            this.downloadButton.Location = new System.Drawing.Point(439, 11);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(38, 23);
            this.downloadButton.TabIndex = 14;
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // attachmentTypePicBox
            // 
            this.attachmentTypePicBox.Image = global::ENothi_Desktop.Properties.Resources.icons8_html_20px;
            this.attachmentTypePicBox.Location = new System.Drawing.Point(26, 14);
            this.attachmentTypePicBox.Name = "attachmentTypePicBox";
            this.attachmentTypePicBox.Size = new System.Drawing.Size(20, 20);
            this.attachmentTypePicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.attachmentTypePicBox.TabIndex = 0;
            this.attachmentTypePicBox.TabStop = false;
            // 
            // DakAttachmentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.panel1);
            this.Name = "DakAttachmentList";
            this.Size = new System.Drawing.Size(500, 46);
            this.Load += new System.EventHandler(this.DakAttachmentList_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DakAttachmentList_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attachmentTypePicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label attachmentName;
        private System.Windows.Forms.PictureBox attachmentTypePicBox;
        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.Button downloadButton;
    }
}
