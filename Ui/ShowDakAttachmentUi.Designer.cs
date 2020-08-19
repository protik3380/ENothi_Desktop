namespace ENothi_Desktop.Ui
{
    partial class ShowDakAttachmentUi
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.totalAttachmentPanel = new System.Windows.Forms.Panel();
            this.totalAttachmentsLabel = new System.Windows.Forms.Label();
            this.dakAttachmentFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            this.totalAttachmentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Controls.Add(this.closeButton);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(559, 61);
            this.topPanel.TabIndex = 2;
            this.topPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.topPanel_Paint);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("SolaimanLipi", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "ডাক সংযুক্তিসমূহ";
            // 
            // totalAttachmentPanel
            // 
            this.totalAttachmentPanel.Controls.Add(this.button2);
            this.totalAttachmentPanel.Controls.Add(this.pictureBox1);
            this.totalAttachmentPanel.Controls.Add(this.button1);
            this.totalAttachmentPanel.Controls.Add(this.totalAttachmentsLabel);
            this.totalAttachmentPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.totalAttachmentPanel.Location = new System.Drawing.Point(0, 61);
            this.totalAttachmentPanel.Name = "totalAttachmentPanel";
            this.totalAttachmentPanel.Size = new System.Drawing.Size(559, 73);
            this.totalAttachmentPanel.TabIndex = 3;
            this.totalAttachmentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.totalAttachmentPanel_Paint);
            // 
            // totalAttachmentsLabel
            // 
            this.totalAttachmentsLabel.AutoSize = true;
            this.totalAttachmentsLabel.Font = new System.Drawing.Font("SolaimanLipi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAttachmentsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(145)))), ((int)(((byte)(156)))));
            this.totalAttachmentsLabel.Location = new System.Drawing.Point(39, 30);
            this.totalAttachmentsLabel.Name = "totalAttachmentsLabel";
            this.totalAttachmentsLabel.Size = new System.Drawing.Size(125, 24);
            this.totalAttachmentsLabel.TabIndex = 0;
            this.totalAttachmentsLabel.Text = " মোট সংযুক্তি (৩)";
            // 
            // dakAttachmentFlowPanel
            // 
            this.dakAttachmentFlowPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dakAttachmentFlowPanel.Location = new System.Drawing.Point(21, 137);
            this.dakAttachmentFlowPanel.Name = "dakAttachmentFlowPanel";
            this.dakAttachmentFlowPanel.Size = new System.Drawing.Size(501, 577);
            this.dakAttachmentFlowPanel.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(144)))), ((int)(((byte)(144)))));
            this.button2.Image = global::ENothi_Desktop.Properties.Resources.icons8_share_25px;
            this.button2.Location = new System.Drawing.Point(480, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = " ";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ENothi_Desktop.Properties.Resources.icons8_attach_25px;
            this.pictureBox1.Location = new System.Drawing.Point(20, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("SolaimanLipi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(144)))), ((int)(((byte)(144)))));
            this.button1.Image = global::ENothi_Desktop.Properties.Resources.icons8_insert_20px;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(308, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "সকল সংযুক্তি ডাউনলোড ";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Image = global::ENothi_Desktop.Properties.Resources.icons8_delete_25px_1;
            this.closeButton.Location = new System.Drawing.Point(518, 6);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(33, 30);
            this.closeButton.TabIndex = 0;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ShowDakAttachmentUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(559, 715);
            this.Controls.Add(this.dakAttachmentFlowPanel);
            this.Controls.Add(this.totalAttachmentPanel);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowDakAttachmentUi";
            this.Text = "ShowDakAttachmentUi";
            this.Load += new System.EventHandler(this.ShowDakAttachmentUi_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ShowDakAttachmentUi_Paint);
            this.topPanel.ResumeLayout(false);
            this.totalAttachmentPanel.ResumeLayout(false);
            this.totalAttachmentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel totalAttachmentPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label totalAttachmentsLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel dakAttachmentFlowPanel;
    }
}