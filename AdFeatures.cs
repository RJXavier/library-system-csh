using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace LibraryBookStore
{
    public partial class AdFeatures : Form
    {
        public AdFeatures()
        {
            InitializeComponent();
        }

        private void Features_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddManager oform = new AddManager();
            oform.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewManager oform = new ViewManager();
            oform.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteManager oform = new DeleteManager();
            oform.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdmLog obj = new AdmLog();
            obj.Show();
            this.Hide();
        }
    }
}
