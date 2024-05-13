using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace SQLiteExample
{
    public partial class Form1 : Form
    {
        private SQLitor sqlitor;

        private string DbName => textBoxDbFileName.Text;
        private string TbName => textBoxTableName.Text;

        private string Status { set { Invoke(() => { labelStatus.Text = value; }); } }

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

                comboBoxTopic.DataSource = Enum.GetValues(typeof(TopicType));
                comboBoxTopic.SelectedIndex = 0;

                Status = "Initialized";
            };
        }

        private void buttonSetup_Click(object sender, EventArgs e)
        {
            try
            {
                sqlitor = new SQLitor("Datas", DbName + ".db", TbName);
                Status = "Setup finished";
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
                //var topic = comboBoxTopic.SelectedItem as string;
                //var message = textBoxMessage.Text;


                Status = "Data inserted";
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
                var topic = comboBoxTopic.SelectedItem.ToString();
                var keyword = textBoxMessage.Text;

                Debug.WriteLine(topic + ":" + keyword);
                sqlitor.Select(topic, keyword);
            }
            catch (Exception ex)
            {
                var errorMessage = "Has an error when select." + Environment.NewLine + ex.Message;
                Status = errorMessage;
                Debug.WriteLine(errorMessage);

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
                Status = "Has an error when insert testdata.\r\n" + ex.Message;
            }
        }
    }
}
