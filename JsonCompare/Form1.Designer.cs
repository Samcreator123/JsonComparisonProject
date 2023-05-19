namespace JsonCompare
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ComparisonBtn = new Button();
            SourceTtb = new RichTextBox();
            TargetTtb = new RichTextBox();
            ResultTtb = new RichTextBox();
            ClearBtn = new Button();
            ResultLabel = new Label();
            FakeDataMaker = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            TargetBodyTtb = new RichTextBox();
            TargetUrlTtb = new RichTextBox();
            SourceBodyTtb = new RichTextBox();
            SourceURLTtb = new RichTextBox();
            OneWayRBtn = new RadioButton();
            TwoWayRBtn = new RadioButton();
            SpecifyColumnsBtn = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // ComparisonBtn
            // 
            ComparisonBtn.Location = new Point(679, 446);
            ComparisonBtn.Name = "ComparisonBtn";
            ComparisonBtn.Size = new Size(105, 29);
            ComparisonBtn.TabIndex = 0;
            ComparisonBtn.Text = "Comparison";
            ComparisonBtn.UseVisualStyleBackColor = true;
            ComparisonBtn.Click += ComparisonBtn_Click;
            // 
            // SourceTtb
            // 
            SourceTtb.Location = new Point(15, 19);
            SourceTtb.Name = "SourceTtb";
            SourceTtb.Size = new Size(283, 357);
            SourceTtb.TabIndex = 1;
            SourceTtb.Text = "";
            // 
            // TargetTtb
            // 
            TargetTtb.Location = new Point(304, 19);
            TargetTtb.Name = "TargetTtb";
            TargetTtb.Size = new Size(285, 357);
            TargetTtb.TabIndex = 2;
            TargetTtb.Text = "";
            // 
            // ResultTtb
            // 
            ResultTtb.Location = new Point(643, 37);
            ResultTtb.Name = "ResultTtb";
            ResultTtb.Size = new Size(302, 391);
            ResultTtb.TabIndex = 3;
            ResultTtb.Text = "";
            ResultTtb.TextChanged += ResultTtb_TextChanged;
            // 
            // ClearBtn
            // 
            ClearBtn.Location = new Point(806, 446);
            ClearBtn.Name = "ClearBtn";
            ClearBtn.Size = new Size(94, 29);
            ClearBtn.TabIndex = 4;
            ClearBtn.Text = "ClearALL!";
            ClearBtn.UseVisualStyleBackColor = true;
            ClearBtn.Click += ClearBtn_Click;
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Location = new Point(762, 15);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(52, 19);
            ResultLabel.TabIndex = 7;
            ResultLabel.Text = "Result";
            // 
            // FakeDataMaker
            // 
            FakeDataMaker.Location = new Point(100, 446);
            FakeDataMaker.Name = "FakeDataMaker";
            FakeDataMaker.Size = new Size(179, 29);
            FakeDataMaker.TabIndex = 8;
            FakeDataMaker.Text = "GenerateFakeData";
            FakeDataMaker.UseVisualStyleBackColor = true;
            FakeDataMaker.Click += FakeDataMaker_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(614, 420);
            tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(SourceTtb);
            tabPage1.Controls.Add(TargetTtb);
            tabPage1.Location = new Point(4, 28);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(606, 388);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Json";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(TargetBodyTtb);
            tabPage2.Controls.Add(TargetUrlTtb);
            tabPage2.Controls.Add(SourceBodyTtb);
            tabPage2.Controls.Add(SourceURLTtb);
            tabPage2.Location = new Point(4, 28);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(606, 388);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "CallApi";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // TargetBodyTtb
            // 
            TargetBodyTtb.Location = new Point(24, 231);
            TargetBodyTtb.Name = "TargetBodyTtb";
            TargetBodyTtb.Size = new Size(535, 132);
            TargetBodyTtb.TabIndex = 3;
            TargetBodyTtb.Text = "";
            // 
            // TargetUrlTtb
            // 
            TargetUrlTtb.Location = new Point(25, 197);
            TargetUrlTtb.Name = "TargetUrlTtb";
            TargetUrlTtb.Size = new Size(535, 28);
            TargetUrlTtb.TabIndex = 2;
            TargetUrlTtb.Text = "";
            // 
            // SourceBodyTtb
            // 
            SourceBodyTtb.Location = new Point(24, 49);
            SourceBodyTtb.Name = "SourceBodyTtb";
            SourceBodyTtb.Size = new Size(531, 125);
            SourceBodyTtb.TabIndex = 1;
            SourceBodyTtb.Text = "";
            // 
            // SourceURLTtb
            // 
            SourceURLTtb.Location = new Point(24, 13);
            SourceURLTtb.Name = "SourceURLTtb";
            SourceURLTtb.Size = new Size(532, 30);
            SourceURLTtb.TabIndex = 0;
            SourceURLTtb.Text = "";
            // 
            // OneWayRBtn
            // 
            OneWayRBtn.AutoSize = true;
            OneWayRBtn.Checked = true;
            OneWayRBtn.Location = new Point(532, 438);
            OneWayRBtn.Name = "OneWayRBtn";
            OneWayRBtn.Size = new Size(90, 23);
            OneWayRBtn.TabIndex = 10;
            OneWayRBtn.TabStop = true;
            OneWayRBtn.Text = "OneWay";
            OneWayRBtn.UseVisualStyleBackColor = true;
            // 
            // TwoWayRBtn
            // 
            TwoWayRBtn.AutoSize = true;
            TwoWayRBtn.Location = new Point(532, 467);
            TwoWayRBtn.Name = "TwoWayRBtn";
            TwoWayRBtn.Size = new Size(90, 23);
            TwoWayRBtn.TabIndex = 11;
            TwoWayRBtn.Text = "TwoWay";
            TwoWayRBtn.UseVisualStyleBackColor = true;
            // 
            // SpecifyColumnsBtn
            // 
            SpecifyColumnsBtn.Location = new Point(338, 446);
            SpecifyColumnsBtn.Name = "SpecifyColumnsBtn";
            SpecifyColumnsBtn.Size = new Size(102, 29);
            SpecifyColumnsBtn.TabIndex = 12;
            SpecifyColumnsBtn.Text = "SpecifyCols";
            SpecifyColumnsBtn.UseVisualStyleBackColor = true;
            SpecifyColumnsBtn.Click += SpecifyColumnsBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(972, 499);
            Controls.Add(SpecifyColumnsBtn);
            Controls.Add(TwoWayRBtn);
            Controls.Add(OneWayRBtn);
            Controls.Add(tabControl1);
            Controls.Add(FakeDataMaker);
            Controls.Add(ResultLabel);
            Controls.Add(ClearBtn);
            Controls.Add(ResultTtb);
            Controls.Add(ComparisonBtn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ComparisonBtn;
        private RichTextBox SourceTtb;
        private RichTextBox TargetTtb;
        private RichTextBox ResultTtb;
        private Button ClearBtn;
        private Label ResultLabel;
        private Button FakeDataMaker;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private RichTextBox TargetBodyTtb;
        private RichTextBox TargetUrlTtb;
        private RichTextBox SourceBodyTtb;
        private RichTextBox SourceURLTtb;
        private RadioButton OneWayRBtn;
        private RadioButton TwoWayRBtn;
        private Button SpecifyColumnsBtn;
    }
}