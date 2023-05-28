using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryBookStore
{
    public partial class ManFeatures : Form
    {
        public ManFeatures()
        {
            InitializeComponent();
        }

        private void ManFeatures_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookEntry oform = new BookEntry();
            oform.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BookEdit oform = new BookEdit();
            oform.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BookSearch oform = new BookSearch();
            oform.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BookDelete oform = new BookDelete();
            oform.Show();
            this.Hide();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ManLogin oform = new ManLogin();
            oform.Show();
            this.Hide();
        }
    }
}
