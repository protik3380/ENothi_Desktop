using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENothi_Desktop.Models.DakAttachment;

namespace ENothi_Desktop.Ui.CustomUserControl
{
    public partial class DakAttachmentList : UserControl
    {
        [Category("Custom Props")]
        public DakAttachment Record { get; set; }
        public DakAttachmentList()
        {
            InitializeComponent();
        }

        private void DakAttachmentList_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                Color.White, 1, ButtonBorderStyle.Solid, // left
                Color.White, 1, ButtonBorderStyle.Solid, // top
                Color.White, 1, ButtonBorderStyle.Solid, // right
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid);// bottom
        }

        private void mainLabel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, mainLabel.ClientRectangle, Color.FromArgb(255,168,0), ButtonBorderStyle.Solid);
        }

        private void DakAttachmentList_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRowData();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadRowData()
        {
            attachmentName.Text = Record.UserFileName;
            mainLabel.Visible = Record.IsMain==1;
            if (Record.AttachmentType== "image/jpeg")
            {
                attachmentTypePicBox.Image = Properties.Resources.imageFileAttachment;
            }
            else if (Record.AttachmentType == "application/pdf")
            {
                attachmentTypePicBox.Image = Properties.Resources.attachmentPdf;
            }
            else
            {
                attachmentTypePicBox.Image = Properties.Resources.icons8_html_20px;
            }
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string url = Record.DownloadUrl;
                // Get filename from URL
                string filename = GetFilename(url);
                if (Record.AttachmentType == "image/jpeg")
                {
                    filename += ".jpeg";
                }
                else if (Record.AttachmentType == "application/pdf")
                {
                    filename += ".pdf";
                }
                else
                {
                    filename += ".html";
                }
                using (var client = new WebClient())
                {
                    client.DownloadFile(url, desktopPath + "/" + filename);
                }
                MessageBox.Show(@"Download ready");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private string GetFilename(string hreflink)
        {
            Uri uri = new Uri(hreflink);

            string filename = System.IO.Path.GetFileName(uri.LocalPath);

            return filename;
        }
    }
}
