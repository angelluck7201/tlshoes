using System;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes
{
    public partial class LoginForm : System.Windows.Forms.Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtUserName.Focus();
            txtPass.Properties.PasswordChar = '*';
        }

        private void ShowMainForm()
        {
            FormFactory<Main>.Get().InitLogin();
            this.Dispose();
        }

        private void CheckLogin()
        {
            var userName = txtUserName.Text;
            var pass = txtPass.Text;
            var isLoginOk = Authorization.CheckLogin(userName, pass);
            if (isLoginOk)
            {
                ShowMainForm();
                lblErrorMessage.Visible = false;
            }
            else
            {
                lblErrorMessage.Visible = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckLogin();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckLogin();
            }
        }

        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckLogin();
            }
        }

    }
}
