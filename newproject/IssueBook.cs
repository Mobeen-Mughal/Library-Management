using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newproject
{
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = DESKTOP-HQPD7LE\\PAFKIET;  database = Librarymanagement; Integrated Security= True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();


            cmd = new SqlCommand("select bName from NewBook", con);
            SqlDataReader Sdr = cmd.ExecuteReader();


            while (Sdr.Read())
            {
                for (int i = 0; i < Sdr.FieldCount; i++)
                {
                    comboBox1.Items.Add(Sdr.GetString(i));

                }
            }
                Sdr.Close();
                con.Close();
            }

        private void btnsearchstud_Click(object sender, EventArgs e)
        {
            if (txtstudid.Text != "")
            {
                string edi = txtstudid.Text;
                string connectionString = "Data Source=DESKTOP-HQPD7LE\\PAFKIET;database=Librarymanagement;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM NewStudent WHERE stuid = @stuid", con);
                    cmd.Parameters.AddWithValue("@stuid", edi);

                    SqlDataAdapter DA = new SqlDataAdapter();
                    DA.SelectCommand = cmd;

                    DataSet DS = new DataSet();
                    DA.Fill(DS);

                    if (DS.Tables[0].Rows.Count != 0)
                    {
                        txtsname.Text = DS.Tables[0].Rows[0][1].ToString();
                        txtsdepart.Text = DS.Tables[0].Rows[0][2].ToString();
                        txtscontact.Text = DS.Tables[0].Rows[0][3].ToString();
                        txtsaddress.Text = DS.Tables[0].Rows[0][4].ToString();
                    }
                    else
                    {
                        txtsname.Clear();
                        txtsdepart.Clear();
                        txtscontact.Clear();
                        txtsaddress.Clear();
                        MessageBox.Show("Invalid Studne ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void btnissue_Click(object sender, EventArgs e)
        {

            Int64 sid = Int64.Parse(txtstudid.Text); 
            string sname = txtsname.Text;
            string sdepart = txtsdepart.Text;
            string scontact = txtscontact.Text;
            Int64 contact = Int64.Parse(txtscontact.Text);
            string saddress = txtsaddress.Text;
            string bookname = comboBox1.Text;
            string bookIssueDate = dateTimePicker3.Text;


            string edi = txtstudid.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = DESKTOP-HQPD7LE\\PAFKIET;  database = Librarymanagement; Integrated Security= True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = " insert into IssueBook (std_id, std_name,std_depart,std_contact ,book_name ,book_issue_date) values ("+sid+",'"+sname+"','" + sdepart + "'," + scontact + ",'" +bookname + "', '"+bookIssueDate+"' )";
            cmd.ExecuteNonQuery();
            con.Close();


            MessageBox.Show("Book issued Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }


            }
    }

}
   

