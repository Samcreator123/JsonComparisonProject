using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonCompare
{
    public partial class SpecfiyColumnsForm : Form
    {
        public List<string> _colummsString;
        public Action<List<string>> _passListToForm1;
        public SpecfiyColumnsForm()
        {
            InitializeComponent();

        }
        public void SetParas(List<string> listbox, Action<List<string>> passListToForm1)
        {
            ColumnsListBox.Items.AddRange(listbox.ToArray());
            _colummsString = listbox;
            _passListToForm1 = passListToForm1;
        }
        private void Add_Click(object sender, EventArgs e)
        {
            string textThatAdd = ColumnNameTtb.Text;
            if (string.IsNullOrWhiteSpace(textThatAdd))
            {
                MessageBox.Show("沒有任何資料");
                return;
            }

            if (_colummsString.Contains(textThatAdd))
            {
                MessageBox.Show("該欄位已存在");
                return;
            }

            _colummsString.Add(textThatAdd);
            ColumnNameTtb.Clear();
            ColumnsListBox.Items.Clear();
            ColumnsListBox.Items.AddRange(_colummsString.ToArray());

        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (ColumnsListBox.SelectedItem == null)
            {
                MessageBox.Show("請點擊列表中要刪除的欄位");
                return;
            }
            string textThatAdd = ColumnsListBox.SelectedItem.ToString();

            _colummsString.Remove(textThatAdd);
            ColumnNameTtb.Clear();
            ColumnsListBox.Items.Clear();
            ColumnsListBox.Items.AddRange(_colummsString.ToArray());

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            ColumnsListBox.DataSource = _colummsString;
            _passListToForm1.Invoke(_colummsString);
            this.Close();
        }

        private void RemoveAll_Click(object sender, EventArgs e)
        {
            if (_colummsString.Count() <= 0)
            {
                return;
            }
            DialogResult dialogResult = MessageBox.Show("確定要移除全部項目?!", "移除全部項目", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.OK)
            {
                _colummsString = new List<string>();
                ColumnNameTtb.Clear();
                ColumnsListBox.Items.Clear();
                ColumnsListBox.Items.AddRange(_colummsString.ToArray());
            }
            else
            {
                return;
            }
        }
    }
}
