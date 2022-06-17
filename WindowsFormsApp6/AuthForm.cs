using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        
        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (!(btLogin.Text == "" || tbPassword.Text == ""))
            {
                DataBase DB = new DataBase();
                if (DB.AuthCheck(tbLogin.Text, tbPassword.Text))
                {
                    MenuForm frm = new MenuForm();
                    ActiveUpdater.MakeActive();
                    Hide();
                    frm.ShowDialog();
                }
                else
                {
                    tbPassword.Clear();
                    tbLogin.Focus();
                }
            }
            else
            {
                MessageBox.Show("Поле логина или пароля не заполнено", "Ошибка");
                tbLogin.Focus();
                tbPassword.Clear();
            }

        }
        private void AuthForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void AuthForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btLogin_Click(sender, e);
        }
        private void tbLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbPassword.Focus();
        }
    }
}
