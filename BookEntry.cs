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
    public partial class BookEntry : Form
    {
        public BookEntry()
        {
            InitializeComponent();
        }

        private void BookEntry_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection sv = new Connection();
            sv.thisConnection.Open();

            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM Bookshelf", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "Bookshelf");

            DataRow thisRow = thisDataSet.Tables["Bookshelf"].NewRow();
            try
            {

                thisRow["BookName"] = textBox1.Text;
                thisRow["PublishYear"] = textBox2.Text;
                thisRow["WriterName"] = textBox3.Text;
                thisRow["Quantity"] = textBox4.Text;
                thisRow["Category"] = textBox5.Text;
                thisRow["EntryDate"] = dateTimePicker1.Value;

                thisDataSet.Tables["Bookshelf"].Rows.Add(thisRow);

                thisAdapter.Update(thisDataSet, "Bookshelf");
                MessageBox.Show("Data entry created.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManFeatures ob = new ManFeatures();
            ob.Show();
            this.Hide();
        }
    }
}
