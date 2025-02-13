using LMS.Business;

namespace LMS.Presentation.Winform
{
    public partial class ReaderForm : Form
    {
        public ReaderForm()
        {
            InitializeComponent();
        }

        private void ReaderForm_Load(object sender, EventArgs e)
        {
            var bll = new ReaderService();
            dataGridView1.DataSource = bll.GetReaders();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
