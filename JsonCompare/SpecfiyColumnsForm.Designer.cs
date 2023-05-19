namespace JsonCompare
{
    partial class SpecfiyColumnsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Add = new Button();
            Remove = new Button();
            ColumnsListBox = new ListBox();
            Exit = new Button();
            RemoveAll = new Button();
            ColumnNameTtb = new TextBox();
            SuspendLayout();
            // 
            // Add
            // 
            Add.Location = new Point(314, 82);
            Add.Name = "Add";
            Add.Size = new Size(94, 29);
            Add.TabIndex = 0;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // Remove
            // 
            Remove.Location = new Point(314, 126);
            Remove.Name = "Remove";
            Remove.Size = new Size(94, 29);
            Remove.TabIndex = 1;
            Remove.Text = "Remove";
            Remove.UseVisualStyleBackColor = true;
            Remove.Click += Remove_Click;
            // 
            // ColumnsListBox
            // 
            ColumnsListBox.FormattingEnabled = true;
            ColumnsListBox.ItemHeight = 19;
            ColumnsListBox.Location = new Point(24, 33);
            ColumnsListBox.Name = "ColumnsListBox";
            ColumnsListBox.Size = new Size(241, 289);
            ColumnsListBox.TabIndex = 2;
            // 
            // Exit
            // 
            Exit.Location = new Point(314, 293);
            Exit.Name = "Exit";
            Exit.Size = new Size(94, 29);
            Exit.TabIndex = 3;
            Exit.Text = "Exit";
            Exit.UseVisualStyleBackColor = true;
            Exit.Click += Exit_Click;
            // 
            // RemoveAll
            // 
            RemoveAll.Location = new Point(314, 170);
            RemoveAll.Name = "RemoveAll";
            RemoveAll.Size = new Size(94, 29);
            RemoveAll.TabIndex = 4;
            RemoveAll.Text = "RemoveAll";
            RemoveAll.UseVisualStyleBackColor = true;
            RemoveAll.Click += RemoveAll_Click;
            // 
            // ColumnNameTtb
            // 
            ColumnNameTtb.Location = new Point(294, 33);
            ColumnNameTtb.Name = "ColumnNameTtb";
            ColumnNameTtb.PlaceholderText = "Enter Column...";
            ColumnNameTtb.Size = new Size(136, 27);
            ColumnNameTtb.TabIndex = 5;
            // 
            // SpecfiyColumnsForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 364);
            Controls.Add(ColumnNameTtb);
            Controls.Add(RemoveAll);
            Controls.Add(Exit);
            Controls.Add(ColumnsListBox);
            Controls.Add(Remove);
            Controls.Add(Add);
            Name = "SpecfiyColumnsForm";
            Text = "SpecfiyColumnsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Add;
        private Button Remove;
        private ListBox ColumnsListBox;
        private Button Exit;
        private Button RemoveAll;
        private TextBox ColumnNameTtb;
    }
}