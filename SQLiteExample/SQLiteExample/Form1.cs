namespace SQLiteExample
{
    public partial class Form1 : Form
    {
        private SQLitor sqlitor;

        private string DbName => textBoxDbFileName.Text;
        private string TbName => textBoxTableName.Text;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSetup_Click(object sender, EventArgs e)
        {
            sqlitor = new SQLitor("Datas", DbName + ".db", TbName);
        }
    }
}
