using JsonCompare.JsonCompareCore.Api;
using JsonCompare.JsonCompareCore.Impl;

namespace JsonCompare
{
    public partial class Form1 : Form
    {
        private IJsonComparison _jsonComparison;
        private List<string> _specifyColumnName = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _jsonComparison = new JsonComparisonImpl();
            this.SetDefaultPlaceHolder();

        }

        private void ComparisonBtn_Click(object sender, EventArgs e)
        {

            ResultTtb.ForeColor = SystemColors.WindowText;

            string sourceStr;
            string targetStr;

            //新增雙向跟指定欄位
            bool isCallApi = tabControl1.SelectedIndex == 1;
            bool isTwoWay = TwoWayRBtn.Checked;

            new Task(() =>
            {
                string result;
                if (isCallApi)
                {
                    ResultTtb.SetText("查詢中...");

                    sourceStr = _jsonComparison.CallApiWithPost(SourceURLTtb.GetText(), SourceBodyTtb.GetText());
                    targetStr = _jsonComparison.CallApiWithPost(TargetUrlTtb.GetText(), TargetBodyTtb.GetText());

                    ResultTtb.SetText("比對中...");

                    result = _jsonComparison.CompareSpecifyColumns(sourceStr, targetStr, isTwoWay, _specifyColumnName.ToArray());

                }
                else
                {
                    ResultTtb.SetText("比對中...");

                    result = _jsonComparison.CompareSpecifyColumns(SourceTtb.GetText(), TargetTtb.GetText(), isTwoWay, _specifyColumnName.ToArray());

                }

                if (_specifyColumnName.Count() <= 0)
                {
                    ResultTtb.SetText(result);
                }
                else
                {
                    string specifyColumns = _specifyColumnName.Aggregate(string.Empty, (current, column) => current + $"{column},");

                    ResultTtb.SetText($"指定比對以下欄位 {specifyColumns} 後 結果是 \r\n\r\n"+result);
                }


            }).Start();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            this.ClearTtb();
        }
        private void ClearTtb()
        {
            foreach (var textbox in this.Controls.OfType<RichTextBox>())
            {
                textbox.SetText(string.Empty);
            }

            this.SetDefaultPlaceHolder();

            SourceTtb.Focus();
        }
        private void ResultTtb_TextChanged(object sender, EventArgs e)
        {
            // var changedStr = _jsonComparison.ChangeSourceColorColumn();

            //this.ChangeColor(changedStr.source, changedStr.target);
        }
        private void SpecifyColumnsBtn_Click(object sender, EventArgs e)
        {
            SpecfiyColumnsForm specfiyColumnsForm = new SpecfiyColumnsForm();
            specfiyColumnsForm.SetParas(_specifyColumnName, GetListOtherForm);
            specfiyColumnsForm.Show();
            this.Visible = false;
        }
        private void GetListOtherForm(List<string> list)
        {
            _specifyColumnName = list;
            this.Visible = true;
        }
        private void SetDefaultPlaceHolder()
        {
            SourceTtb.SetPlaceHolder("Enter Source JSON Here...");
            TargetTtb.SetPlaceHolder("Enter Target JSON Here ...");
            ResultTtb.SetPlaceHolder("Result Will Show Here ...");
            SourceURLTtb.SetPlaceHolder("Enter SourceUrl Here ...");
            SourceBodyTtb.SetPlaceHolder("Enter SourceBody Here ...");
            TargetUrlTtb.SetPlaceHolder("Enter TargetUrl Here ...");
            TargetBodyTtb.SetPlaceHolder("Enter TargetBody Here ...");
        }


        private void FakeDataMaker_Click(object sender, EventArgs e)
        {
            SourceTtb.ForeColor = SystemColors.WindowText;
            TargetTtb.ForeColor = SystemColors.WindowText;
            SourceTtb.Text = @"{
                              ""familyMemberCounts"": 6,
                              ""balance"": 100000,
                              ""parent"": {
                                ""avgAge"": 30,
                                ""sons"": [
                                  {
                                    ""name"": ""lee"",
                                    ""Age"": 12
                                  },
                                  {
                                    ""name"": ""ho"",
                                    ""Age"": 12
                                  },
                                  {
                                    ""name"": ""woo"",
                                    ""Age"": 12
                                  },
                                  {
                                    ""name"": ""woo1"",
                                    ""Age"": 123
                                  }
                                ],
                                ""daughters"": [
                                  {
                                    ""name"": ""yo"",
                                    ""Age"": 8,
                                    ""manyInt"": [
                                      1,
                                      2,
                                      3,
                                      5
                                    ]
                                  }
                                ]
                              }
                            }";
            TargetTtb.Text = @"{
                            ""familyMemberCounts"": 6,
                            ""parent"": {

                            ""sons"": [
                                {
                                ""name"": ""lee"",
                                ""Age"": 12
                                },
                                {
                                ""name"": ""ho"",
                                ""Age"": 12
                                },
                                {
                                ""name"": ""woo"",
                                ""Age"": 123
                                }
                            ],
                            ""daughters"": [
                                {
                                ""name"": ""yo"",
                                ""Age"": 8,
                                ""manyInt"": [
                                    1,
                                    2,
                                    3
          
                                ]
                                },
                                {
                                ""name"": ""wyo"",
                                ""Age"": 8,
                                ""manyInt"": [
                                    1,
                                    2,
                                    3
          
                                ]
                                }
                            ]
                            }
                        }";
        }


    }
}