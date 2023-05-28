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
    public partial class ViewManager : Form
    {
        public ViewManager()
        {
            InitializeComponent();
        }

        private void ViewManager_Load_1(object sender, EventArgs e)
        {
            Connection CN = new Connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            thisCommand.CommandText = "SELECT * FROM Managers order by Manager";

            OracleDataReader thisReader = thisCommand.ExecuteReader();


            while (thisReader.Read())
            {
                ListViewItem lsvItem = new ListViewItem();
                lsvItem.Text = thisReader["Manager"].ToString();
                lsvItem.SubItems.Add(thisReader["Password"].ToString());

                listView1.Items.Add(lsvItem);
            }


            CN.thisConnection.Close();
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdFeatures ob = new AdFeatures();
            ob.Show();
            this.Hide();
        }
    }
}
