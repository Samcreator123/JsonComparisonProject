using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JsonCompare
{
    public static class UIExtension
    {
        public static void SetText(this RichTextBox textBox, string msg)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new Action<RichTextBox, string>(SetText), textBox, msg);
            }
            else
            {
                textBox.Text = msg;
            }
        }

        public static string GetText(this RichTextBox textBox)
        {
            if (textBox.InvokeRequired)
            {
                return textBox.Invoke(new Func<string>(() => GetText(textBox)));
            }
            else
            {
                return textBox.Text;
            }
        }
        public static void SetPlaceHolder(this RichTextBox textBox, string msg)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new Action<RichTextBox, string>(SetPlaceHolder), textBox, msg);
            }
            else
            {
                textBox.Text = msg;
                textBox.ForeColor = SystemColors.GrayText;
                textBox.Enter += (sender, e) => RichTextBox_Enter(sender, e, msg);
                textBox.Leave += (sender, e) => RichTextBox_Leave(sender, e, msg);
            }
        }
        private static void RichTextBox_Enter(object sender, EventArgs e,string placeHolderMsg)
        {
            if (sender is not RichTextBox)
            {
                return;
            }

            var textBox = sender as RichTextBox;

            // 點擊時，如果裡面的字體不是預設且不為空 則必是輸入的內容
            if (textBox.GetText() != placeHolderMsg && !string.IsNullOrWhiteSpace(textBox.GetText()))
            {
                textBox.ForeColor = SystemColors.WindowText;
                return;
            }

            textBox.Text = "";
            textBox.ForeColor = SystemColors.WindowText;
        }
        private static void RichTextBox_Leave(object sender, EventArgs e, string msg)
        {
            if (sender is not RichTextBox)
            {
                return;
            }

            var textBox = sender as RichTextBox;

            // 如果有字，那就不是空
            if (!string.IsNullOrWhiteSpace(textBox.GetText()))
            {
                return;
            }

            textBox.Text = msg;
            textBox.ForeColor = SystemColors.GrayText;
        }
    }
}
