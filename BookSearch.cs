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
    public partial class BookSearch : Form
    {
        public BookSearch()
        {
            InitializeComponent();
        }

        private void BookSearch_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManFeatures ob = new ManFeatures();
            ob.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Connection CN = new Connection();
            CN.thisConnection.Open();
            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            if (comboBox1.SelectedIndex == 0)
            {
                thisCommand.CommandText = "SELECT * FROM Bookshelf where BookName LIKE '%" + textBox2.Text + "%'";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                thisCommand.CommandText = "SELECT * FROM Bookshelf  where PublishYear LIKE '%" + textBox2.Text + "%'";
            }

            else if (comboBox1.SelectedIndex == 2)
            {
                thisCommand.CommandText = "SELECT * FROM Bookshelf where WriterName LIKE '%" + textBox2.Text + "%'";
            }

            else if (comboBox1.SelectedIndex == 3)
            {
                thisCommand.CommandText = "SELECT * FROM Bookshelf where Quantity LIKE '%" + textBox2.Text + "%'";
            }

            else if (comboBox1.SelectedIndex == 4)
            {
                thisCommand.CommandText = "SELECT * FROM Bookshelf where Category LIKE '%" + textBox2.Text + "%'";
            }
            else
            {
                MessageBox.Show("Please enter a search term");
            }


            listView1.Items.Clear();
            OracleDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read())
            {
                ListViewItem lsvItem = new ListViewItem();


                lsvItem.Text = thisReader["BookName"].ToString();
                lsvItem.SubItems.Add(thisReader["PublishYear"].ToString());
                lsvItem.SubItems.Add(thisReader["WriterName"].ToString());
                lsvItem.SubItems.Add(thisReader["Quantity"].ToString());
                lsvItem.SubItems.Add(thisReader["Category"].ToString());

                listView1.Items.Add(lsvItem);
                

            }
            


            CN.thisConnection.Close();

        }
    }
}
