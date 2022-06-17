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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            switch (Variables.User.Role)
            {
                case "Кассир":
                    btReports.Visible =
                    btManager.Visible =
                    btAccountans.Visible =
                    btCashier.Visible =
                    btEntertainers.Visible = false;
                    break;

                case "Бухалтер":
                    btEvents.Visible =
                    btManager.Visible =
                    btAccountans.Visible =
                    btCashier.Visible =
                    btEntertainers.Visible = false;
                    break;
            }
            int height = 12;
            ButtonSorter btst = new ButtonSorter();
            foreach (Control bt in btst.SortButts(this.Controls))
            {
                if (bt is Button && (bt as Button).Visible)
                {
                    (bt as Button).Location = new Point(12, height);
                    height += (bt as Button).Height + 6;
                }
            }
            this.Height = height + 45;
        }

        private void btReports_Click(object sender, EventArgs e)
        {
            
        }

        private void btManagers_Click(object sender, EventArgs e)
        {
            UsersForm frm = new UsersForm(0);
            Hide();
            frm.ShowDialog();
            Show();
        }

        private void btAccountants_Click(object sender, EventArgs e)
        {
            UsersForm frm = new UsersForm(1);
            Hide();
            frm.ShowDialog();
            Show();
        }

        private void btCashiers_Click(object sender, EventArgs e)
        {
            UsersForm frm = new UsersForm(2);
            Hide();
            frm.ShowDialog();
            Show();
        }
        private void MenuForm_FormClosing(object sender, FormClosedEventArgs e)
        {
            ActiveUpdater.MakeInactive();
        }

        private void btChangePass_Click(object sender, EventArgs e)
        {
            ChangePassForm frm = new ChangePassForm();
            Hide();
            frm.ShowDialog();
            Show();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
