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
    public partial class BookEdit : Form
    {
        public BookEdit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection CN = new Connection();
            CN.thisConnection.Open();
            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            if (comboBox1.SelectedIndex == 0)
            {
                thisCommand.CommandText = "UPDATE Bookshelf SET Quantity = '" + textBox6.Text + "'where BookName LIKE '%" + textBox7.Text + "%'";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                thisCommand.CommandText = "UPDATE Bookshelf SET Quantity = '" + textBox6.Text + "'where PublishYear LIKE '%" + textBox7.Text + "%'";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                thisCommand.CommandText = "UPDATE Bookshelf SET Quantity = '" + textBox6.Text + "'where WriterName LIKE '%" + textBox7.Text + "%'";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                thisCommand.CommandText = "UPDATE Bookshelf SET Quantity = '" + textBox6.Text + "'where Quantity LIKE '%" + textBox7.Text + "%'";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                thisCommand.CommandText = "UPDATE Bookshelf SET Quantity = '" + textBox6.Text + "'where Category LIKE '%" + textBox7.Text + "%'";
            }
            else
            {
                MessageBox.Show("No value to update");
               
            }

            thisCommand.Connection = CN.thisConnection;
            thisCommand.CommandType = CommandType.Text;

            try
            {
                thisCommand.ExecuteNonQuery();
                MessageBox.Show("Updated");
                this.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            CN.thisConnection.Close();
            this.Hide();
            BookEdit obj = new BookEdit();
            obj.Show();


        }

        private void BookEdit_Load(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            ManFeatures ob = new ManFeatures();
            ob.Show();
            this.Hide();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
