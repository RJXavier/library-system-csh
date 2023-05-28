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
    public partial class BookDelete : Form
    {
        public BookDelete()
        {
            InitializeComponent();
        }



        private void BookDelete_Load(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            Connection CN = new Connection();
            CN.thisConnection.Open();
            OracleCommand thisCommand = CN.thisConnection.CreateCommand();


            if (comboBox1.SelectedIndex == 0)
            {
                thisCommand.CommandText = "SELECT * FROM Bookshelf where BookName LIKE '%" + textBox7.Text + "%'";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                thisCommand.CommandText = "SELECT * FROM Bookshelf  where PublishYear LIKE '%" + textBox7.Text + "%'";
            }

            else if (comboBox1.SelectedIndex == 2)
            {
                thisCommand.CommandText = "SELECT * FROM Bookshelf where WriterName LIKE '%" + textBox7.Text + "%'";
            }

            else if (comboBox1.SelectedIndex == 3)
            {
                thisCommand.CommandText = "SELECT * FROM Bookshelf where Quantity LIKE '%" + textBox7.Text + "%'";
            }

            else if (comboBox1.SelectedIndex == 4)
            {
                thisCommand.CommandText = "SELECT * FROM Bookshelf where Category LIKE '%" + textBox7.Text + "%'";
            }
            else
            {
                MessageBox.Show("Please enter a search term");
            }

            listView1.Clear();
            listView2.Clear();
            listView3.Clear();
            listView4.Clear();
            listView5.Clear();

            OracleDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read())
            {
                ListViewItem obj = new ListViewItem();
                ListViewItem obj2 = new ListViewItem();
                ListViewItem obj3 = new ListViewItem();
                ListViewItem obj4 = new ListViewItem();
                ListViewItem obj5 = new ListViewItem();


                obj.Text = thisReader["BookName"].ToString();
                listView1.Items.Add(obj);
                obj2.Text = thisReader["PublishYear"].ToString();
                listView2.Items.Add(obj2);
                obj3.Text = thisReader["WriterName"].ToString();
                listView3.Items.Add(obj3);
                obj4.Text = thisReader["Quantity"].ToString();
                listView4.Items.Add(obj4);
                obj5.Text = thisReader["Category"].ToString();
                listView5.Items.Add(obj5);

            }

            CN.thisConnection.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection CN = new Connection();
            CN.thisConnection.Open();
            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            if (comboBox1.SelectedIndex == 0)
            {
                thisCommand.CommandText = "DELETE Bookshelf WHERE BookName LIKE '%" + textBox7.Text + "%'";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                thisCommand.CommandText = "DELETE Bookshelf WHERE PublishYear LIKE '%" + textBox7.Text + "%'";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                thisCommand.CommandText = "DELETE Bookshelf WHERE WriterName LIKE '%" + textBox7.Text + "%'";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                thisCommand.CommandText = "DELETE Bookshelf WHERE Quantity LIKE '%" + textBox7.Text + "%'";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                thisCommand.CommandText = "DELETE Bookshelf WHERE Category LIKE '%" + textBox7.Text + "%'";
            }
            else
            {
                MessageBox.Show("No value to delete");

            }

            thisCommand.Connection = CN.thisConnection;
            thisCommand.CommandType = CommandType.Text;

            try
            {
                thisCommand.ExecuteNonQuery();
                MessageBox.Show("Deleted");
                this.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            CN.thisConnection.Close();
            this.Hide();
            BookDelete obj = new BookDelete();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManFeatures ob = new ManFeatures();
            ob.Show();
            this.Hide();
        }
    }
}
