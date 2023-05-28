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
    public partial class DeleteManager : Form
    {
        public DeleteManager()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        { 
            Connection co = new Connection();
            co.thisConnection.Open();

            OracleCommand thisCommand1 = co.thisConnection.CreateCommand();

            thisCommand1.CommandText = "DELETE Managers where Manager= '" + textBox1.Text + "'";

            thisCommand1.Connection = co.thisConnection;
            thisCommand1.CommandType = CommandType.Text;
            try
            {
                thisCommand1.ExecuteNonQuery();
                MessageBox.Show("delete successfully");
                this.Hide();
                AdFeatures ob = new AdFeatures();
                ob.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private void DeleteManager_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdFeatures ob = new AdFeatures();
            ob.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
