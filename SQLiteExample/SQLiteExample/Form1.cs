using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace SQLiteExample
{
    public partial class Form1 : Form
    {
        private SQLitor sqlitor;

        private string DbName => textBoxDbFileName.Text;

        private string TbName => textBoxTableName.Text;

        private bool setuped = false;

        private string Topic => comboBoxTopic.Text;

        private string Message => textBoxMessage.Text;

        private string Status { get { return labelStatus.Text; } set { Invoke(() => { labelStatus.Text = value; }); } }

        private enum TopicType
        {
            System = 0,
            Device,
            Run,
            Alarm,
        }

        public Form1()
        {
            InitializeComponent();

            Load += (s, e) =>
            {
                MaximizeBox = false;
                FormBorderStyle = FormBorderStyle.FixedSingle;

                //comboBoxTopic.DataSource = Enum.GetValues(typeof(TopicType));
                //comboBoxTopic.SelectedIndex = 0;

                setuped = false;

                Status = "Initialized";
            };

            FormClosing += (s, e) =>
            {
                if (setuped)
                {
                    sqlitor?.Close();
                }
            };
        }

        private void buttonSetup_Click(object sender, EventArgs e)
        {
            try
            {
                if (!setuped)
                {
                    sqlitor = new SQLitor("Datas", DbName + ".db", TbName);
                    setuped = true;
                    Status = "Setup finished";
                }
                else
                {
                    Status = "DataBase is setuped";
                }

            }
            catch (Exception ex)
            {
                Status = "Has an error when setup." + Environment.NewLine + ex.Message;
            }

        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            try
            {
                sqlitor.Insert(Topic,Message);

                Status =  "Data inserted";
            }
            catch (Exception ex)
            {
                Status = "Has an error when insert." + Environment.NewLine + ex.Message;
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            try
            {
                var keywords = textBoxMessage.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                List<string> keywordList = new List<string>();
                for (int i = 0; i < keywords.Length; i++)
                {
                    //Debug.WriteLine("Keyword : " + keywords[i]);
                    keywordList.Add(keywords[i]);
                }

                dataGridViewDBData.DataSource = sqlitor.Select(Topic, keywordList).ToArray();

                Status = "Select finished";
            }
            catch (Exception ex)
            {
                var errorMessage = "Has an error when select." + Environment.NewLine + ex.Message;
                Status = errorMessage;
            }
        }

        private void labelInsertTestData_Click(object sender, EventArgs e)
        {
            try
            {
                Status = "Insert testdata";

                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

                for (int i = 0; i < 50; i++)
                {
                    Random rand = new Random();
                    var topic = ((TopicType)rand.Next(1, Enum.GetValues(typeof(TopicType)).Length)).ToString();

                    int length = rand.Next(10, 50);
                    var msg = "測試用資料：" + new string(Enumerable.Repeat(chars, length).Select(s => s[rand.Next(s.Length)]).ToArray());

                    Debug.WriteLine(topic + ":\r\n" + msg);
                    sqlitor.Insert(topic, msg);
                }

                Status = "Testdata inserted";
            }
            catch (Exception ex)
            {
                Status = "Has an error when insert testdata." + Environment.NewLine + ex.Message;
            }
        }

        private void labelStatus_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Status);
        }

        private void comboBoxTopic_DropDown(object sender, EventArgs e)
        {
            if (!setuped)
            {
                return;
            }

            comboBoxTopic.DataSource = sqlitor.GetTopicType();
        }
    }
}
