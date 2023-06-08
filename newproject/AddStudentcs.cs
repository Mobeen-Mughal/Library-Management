using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newproject
{
    public partial class AddStudentcs : Form
    {
        public AddStudentcs()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("confirm?", "Alert ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

     
            private void btnsave_Click(object sender, EventArgs e)
        {

            Int64 sid = Int64.Parse(txtsid.Text);
            string sname = txtsname.Text;
            string sdepart = txtsdepart.Text;
            Int64 scontact = Int64.Parse(txtscontact.Text);
            string saddress = txtsaddress.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = DESKTOP-HQPD7LE\\PAFKIET; database = Librarymanagement; Integrated Security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            con.Open();

            cmd.CommandText = "INSERT INTO NewStudent (stuid,sname, sdepart, scontact, saddress) VALUES (@sid, @sname, @sdepart, @scontact, @saddress)";
            cmd.Parameters.AddWithValue("@sid", sid);
            cmd.Parameters.AddWithValue("@sname", sname);
            cmd.Parameters.AddWithValue("@sdepart", sdepart);
            cmd.Parameters.AddWithValue("@scontact", scontact);
            cmd.Parameters.AddWithValue("@saddress", saddress);

            cmd.ExecuteNonQuery();
            con.Close();
        }

    }



}

