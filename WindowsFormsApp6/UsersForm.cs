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
    public partial class UsersForm : Form
    {
        public byte usertype { get; private set; }
        Panel panel1 = new Panel();
        Label lbErrorSuccess = new Label();
        string selrole;
        private bool isSearching = false;
        public UsersForm(byte usrtype)
        {
            InitializeComponent();
            usertype = usrtype;
        }

        private void FillThisTable()
        {
            DataBase DB = new DataBase();
            if (chbShowDisabled.Checked)
                DB.FillUsers(DB.Select("users", "id,surname,name,patronymic,login,password,passport,contact,birthdate,address,isActive,lastActiont,enabled,createddate,author,editdate,editor,disabledate,disabler",
                    "role = '" + selrole + "'"), dgv);
            else
                DB.FillUsers(DB.Select("users", "id,surname,name,patronymic,login,password,passport,contact,birthdate,address,isActive,lastActiont,enabled,createddate,author,editdate,editor,disabledate,disabler",
                    "role = '" + selrole + "' AND enabled = '1'"), dgv);
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            FieldClear FC = new FieldClear();
            FC.ClearFields(panel1.Controls);
            switch (usertype)
            {
                default:
                    selrole = "Руководитель";
                    break;
                case 1:
                    selrole = "Бухгалтер";
                    break;
                case 2:
                    selrole = "Кассир";
                    break;
            }
            lbErrorSuccess.Text = "";
            Text = selrole;
            FillThisTable();
        }

        private void chbShowDisabled_CheckedChanged(object sender, EventArgs e)
        {
            FillThisTable();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            LabelHandler LH = new LabelHandler();
            if (tbSurname.Text != "" && tbName.Text != "" && tbPatronymic.Text != "" && tbLogin.Text != "" && tbPassword.Text != "" && tbPassport.Text != "")
            {
                DataBase DB = new DataBase();
                if (DB.InsertUsers(selrole, tbSurname.Text, tbName.Text, tbPatronymic.Text, tbLogin.Text, tbPassword.Text, tbPassport.Text, tbContact.Text, dtpBirthdate.Value, tbAddress.Text))
                    LH.lbChange(lbErrorSuccess, Color.DarkBlue, "Запись добавлена");
                else
                    LH.lbChange(lbErrorSuccess, Color.DarkRed, "Запись не добавлена");
                ActiveUpdater.MakeActive();
                FillThisTable();
                FieldClear FC = new FieldClear();
                FC.ClearFields(panel1.Controls);
            }
            else
                LH.lbChange(lbErrorSuccess, Color.DarkRed, "Одно или более полей не заполены");
        }

        private void btCleartb_Click(object sender, EventArgs e)
        {
            FieldClear FC = new FieldClear();
            FC.ClearFields(panel1.Controls);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
            DataBase DB = new DataBase();
            LabelHandler LH = new LabelHandler();
            if (Convert.ToBoolean(dgv.SelectedRows[0].Cells[12].Value))
                if (DB.DeleteRecord(id, "users"))
                    LH.lbChange(lbErrorSuccess, Color.DarkBlue, "Запись удалена");
                else
                    LH.lbChange(lbErrorSuccess, Color.DarkRed, "Запись удалена");
            else
                if (DB.RestoreRecord(id, "users"))
                LH.lbChange(lbErrorSuccess, Color.DarkBlue, "Запичь восстановлена");
            else
                LH.lbChange(lbErrorSuccess, Color.DarkRed, "Запись не восстановслена");
            ActiveUpdater.MakeActive();
            FillThisTable();
        }
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                tbSurname.Text = dgv.SelectedRows[0].Cells[1].Value.ToString();
                tbName.Text = dgv.SelectedRows[0].Cells[2].Value.ToString();
                tbPatronymic.Text = dgv.SelectedRows[0].Cells[3].Value.ToString();
                tbLogin.Text = dgv.SelectedRows[0].Cells[4].Value.ToString();
                tbPassword.Text = dgv.SelectedRows[0].Cells[5].Value.ToString();
                tbPassport.Text = dgv.SelectedRows[0].Cells[6].Value.ToString();
                tbContact.Text = dgv.SelectedRows[0].Cells[7].Value.ToString();
                dtpBirthdate.Value = Convert.ToDateTime(dgv.SelectedRows[0].Cells[8].Value);
                tbAddress.Text = dgv.SelectedRows[0].Cells[9].Value.ToString();
            }
            catch { }
        }
        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                tbSurname.Text = dgv.SelectedRows[0].Cells[1].Value.ToString();
                tbName.Text = dgv.SelectedRows[0].Cells[2].Value.ToString();
                tbPatronymic.Text = dgv.SelectedRows[0].Cells[3].Value.ToString();
                tbLogin.Text = dgv.SelectedRows[0].Cells[4].Value.ToString();
                tbPassword.Text = dgv.SelectedRows[0].Cells[5].Value.ToString();
                tbPassport.Text = dgv.SelectedRows[0].Cells[6].Value.ToString();
                tbContact.Text = dgv.SelectedRows[0].Cells[7].Value.ToString();
                dtpBirthdate.Value = Convert.ToDateTime(dgv.SelectedRows[0].Cells[8].Value);
                tbAddress.Text = dgv.SelectedRows[0].Cells[9].Value.ToString();
            }
            catch { }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            LabelHandler LH = new LabelHandler();
            if (tbSurname.Text != "" && tbName.Text != "" && tbPatronymic.Text != "" && tbLogin.Text != "" && tbPassword.Text != "" && tbPassport.Text != "")
            {
                int id = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
                DataBase DB = new DataBase();
                if (DB.UpdateUsers(id, tbSurname.Text, tbName.Text, tbPatronymic.Text, tbLogin.Text, tbPassword.Text, tbPassport.Text, tbContact.Text, dtpBirthdate.Text, tbAddress.Text))
                    LH.lbChange(lbErrorSuccess, Color.DarkBlue, "Запись обновлена");
                else
                    LH.lbChange(lbErrorSuccess, Color.DarkRed, "Запись не обновлена");
                ActiveUpdater.MakeActive();
                FillThisTable();
            }
            else
                LH.lbChange(lbErrorSuccess, Color.DarkRed, "Одно или более полей не заполнены");
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string condition = "role = '" + selrole + "' AND ";
            if (tbSurname.Text != "")
                condition += "surname LIKE '%" + tbSurname.Text + "%' AND ";
            if (tbName.Text != "")
                condition += "name LIKE '%" + tbName.Text + "%' AND ";
            if (tbPatronymic.Text != "")
                condition += "patronymic LIKE '%" + tbPatronymic.Text + "%' AND ";
            if (tbLogin.Text != "")
                condition += "login LIKE '%" + tbLogin.Text + "%' AND ";
            if (tbPassword.Text != "")
                condition += "password LIKE '%" + tbPassword.Text + "%' AND ";
            if (tbPassport.Text != "")
                condition += "passport LIKE '%" + tbPassport.Text + "%' AND ";
            if (tbContact.Text != "")
                condition += "contact LIKE '%" + tbContact.Text + "%' AND ";
            if (tbAddress.Text != "")
                condition += "adress LIKE '%" + tbAddress.Text + "%' AND ";
            if (dtpBirthdate.Checked)
                condition += "birthdate LIKE '%" + dtpBirthdate.Text + "%' AND ";
            if (!chbShowDisabled.Checked)
                condition += "enabled = '1' AND ";
            DataBase DB = new DataBase();
            DB.FillUsers(DB.Select("users", "id,surname,name,patronymic,login,password,passport,contact,birthdate,address,isActive,lastAction,enabled,createddate,author,edidate,editor,disabledate,disabler",
                condition.Substring(0, condition.Length - 5)), dgv);
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            FieldClear FC = new FieldClear();
            FC.ClearFields(panel1.Controls);
            isSearching = !isSearching;
            btAdd.Enabled = !btAdd.Enabled;
            btDelete.Enabled = !btDelete.Enabled;
            btUpdate.Enabled = !btUpdate.Enabled;
            btFind.Enabled = !btFind.Enabled;
            dtpBirthdate.Visible = !dtpBirthdate.Visible;
        }
    }
}
