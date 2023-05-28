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
    public partial class ManLogin : Form
    {
        public ManLogin()
        {
            InitializeComponent();
        }
        private void logincheck()
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();
                OracleCommand thisCommand = new OracleCommand();
                thisCommand.Connection = CN.thisConnection;
                thisCommand.CommandText = "SELECT * FROM ManagerLog WHERE Username='" + textBox1.Text + "' AND Password='" + textBox2.Text + "'";
                OracleDataReader thisReader = thisCommand.ExecuteReader();
                if (thisReader.Read())
                {
                    ManFeatures oform = new ManFeatures();
                    oform.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Credentials");
                }

                CN.thisConnection.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ManLogin_Load(object sender, EventArgs e)
        {

        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                logincheck();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            logincheck();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            ob.Show();
            this.Hide();
        }
    }
}
