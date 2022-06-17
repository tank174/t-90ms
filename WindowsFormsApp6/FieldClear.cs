using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    class FieldClear
    {
        public void ClearFields(Control.ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                switch (ctrl.GetType().ToString())
                {
                    case "System.Windows.Forms.TextBox":
                        (ctrl as TextBox).Clear();
                        break;
                    case "System.Windows.Forms.DateTimePicker":
                        if ((ctrl as DateTimePicker).CustomFormat == "yyyy-MM-dd")
                            (ctrl as DateTimePicker).Value = DateTime.Today;
                        else if ((ctrl as DateTimePicker).CustomFormat == "HH:mm")
                            (ctrl as DateTimePicker).Value = Convert.ToDateTime(DateTime.Now);
                        break;
                    case "System.Windows.Forms.ComboBox":
                        (ctrl as ComboBox).SelectedIndex = 0;
                        break;
                    case "System.Windows.Forms.CheckBox":
                        (ctrl as CheckBox).Checked = false;
                        break;
                }
            }
        }
    }
}
