using System;
using System.Drawing;
using System.Windows.Forms;
using ENothi_Desktop.Manager;
using ENothi_Desktop.Models;
using ENothi_Desktop.Models.Interface.IManager;
using ENothi_Desktop.Ui;
using ENothi_Desktop.Ui.AlertUi;

namespace ENothi_Desktop
{
    public partial class MainUi : Form
    {
        private readonly ILoginManager _loginManager;
        public MainUi()
        {
            _loginManager = new LoginManager();
            InitializeComponent();
        }
        private void MainUi_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                loginTabControl.SelectedTab = userIdTabPage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void footerPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, footerPanel.ClientRectangle,
                Color.White, 1, ButtonBorderStyle.Solid, // left
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid, // top
                Color.White, 1, ButtonBorderStyle.Solid, // right
                Color.White, 1, ButtonBorderStyle.Solid);// bottom
        }

       

        private void leftPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, leftPannel.ClientRectangle,
                Color.White, 1, ButtonBorderStyle.Solid, // left
                Color.White, 1, ButtonBorderStyle.Solid, // top
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid, // right
                Color.White, 1, ButtonBorderStyle.Solid);// bottom
        }

        private void helpDeskPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, helpDeskPanel.ClientRectangle,
                Color.White, 1, ButtonBorderStyle.Solid, // left
                Color.FromArgb(94, 18, 152), 2, ButtonBorderStyle.Solid, // top
                Color.White, 1, ButtonBorderStyle.Solid, // right
                Color.FromArgb(94, 18, 152), 2, ButtonBorderStyle.Solid);// bottom
        }
        private void Alert(string message)
        {
            Form_Alert frm = new Form_Alert();
            frm.ShowAlert(message);
        }

        private void userIdTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                string userId = userIdTextBox.Text;
                string autocompleteUserId = _loginManager.AutoCompleteUserId(userId);
                userIdTextBox.Text = autocompleteUserId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void userIdLoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoginCredential credential = new LoginCredential();
                credential.Username = userIdTextBox.Text;
                credential.Password = passwordUserIdTextBox.Text;
                if (credential.Username != "" && credential.Password != "")
                {
                    LoginResponse response = _loginManager.ValidateUser(credential);

                    if (response != null)
                    {
                        SetRefreshHelper();
                        DashboardUi dashboardUi = new DashboardUi(response);
                        dashboardUi.Show();

                    }
                    else
                    {
                        this.Alert("Invalid username or password");
                    }
                }
                else
                {
                    this.Alert("Username or password empty");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetRefreshHelper()
        {
            ReloadHelper.IsArchive = false;
        }
    }
}
