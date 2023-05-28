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
    public partial class AddManager : Form
    {
        public AddManager()
        {
            InitializeComponent();
        }

        private void AddManager_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection sv = new Connection();
            sv.thisConnection.Open();

            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM Managers", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "Managers");

            DataRow thisRow = thisDataSet.Tables["Managers"].NewRow();
            try
            {

                thisRow["Manager"] = textBox1.Text;
                thisRow["Password"] = textBox2.Text;

                thisDataSet.Tables["Managers"].Rows.Add(thisRow);

                thisAdapter.Update(thisDataSet, "Managers");
                MessageBox.Show("Data entry created.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();

            AdFeatures ob = new AdFeatures();
            ob.Show();
            this.Hide();
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
    }
}
