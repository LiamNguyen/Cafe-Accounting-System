using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AccountingSystemValidation
{
    public class InputValidation
    {
        public String validateInput(List<TextBox> listTxtBox)
        {
            String errorMessage = null;
            Regex regex = new Regex(@"[\~\`\!\@\#\$\%\^\&\*\(\)\-\+\=\;\:\'\<\,\.\>\?]");
            foreach (TextBox txtB in listTxtBox) {
                if (txtB.Text.Equals(""))
                {
                    txtB.BackColor = Color.LightPink;
                    errorMessage = "Blanks are not allowed";
                    continue;
                }
                MatchCollection matches = regex.Matches(txtB.Text);
                if (matches.Count > 0)
                {
                    txtB.BackColor = Color.LightPink;
                    errorMessage = "Special characters are not allowed";
                }
            }
            return errorMessage;
        }

        public String validateInputAllowNull(List<TextBox> listTxtBox)
        {
            String errorMessage = null;
            Regex regex = new Regex(@"[\~\`\!\@\#\$\%\^\&\*\(\)\-\+\=\;\:\'\<\,\.\>\?]");
            foreach (TextBox txtB in listTxtBox)
            {
                MatchCollection matches = regex.Matches(txtB.Text);
                if (matches.Count > 0)
                {
                    txtB.BackColor = Color.LightPink;
                    errorMessage = "Special characters are not allowed";
                }
            }
            return errorMessage;
        }

        public void validateNumberOnly(Object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        public String validateDateFormatOnly(List<TextBox> listTxtBox) 
        {
            String errorMessage = null;
            Regex regex = new Regex(@"[A-Z\~\`\!\@\#\$\%\^\&\*\(\)\-\+\=\;\:\'\<\,\.\>\?]");
            foreach (TextBox txtB in listTxtBox)
            {
                if (txtB.Text.Equals(""))
                {
                    txtB.BackColor = Color.LightPink;
                    errorMessage = "Blanks are not allowed";
                    continue;
                }
                MatchCollection matches = regex.Matches(txtB.Text);
                if (matches.Count > 0)
                {
                    txtB.BackColor = Color.LightPink;
                    errorMessage = "Special characters are not allowed";
                }
            }
            return errorMessage;
        }
    }
}
