using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newproject
{
    public partial class viewBook : Form
    {
        public viewBook()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        int address;
        Int64 info;
        private void viewBook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = DESKTOP-HQPD7LE\\PAFKIET;  database = Librarymanagement; Integrated Security= True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select  * from NewBook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                address = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());


            }
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = DESKTOP-HQPD7LE\\PAFKIET;  database = Librarymanagement; Integrated Security= True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select  * from NewBook where bid = " + info + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            info = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtbname.Text = ds.Tables[0].Rows[0][1].ToString();
            txtbauthorname.Text = ds.Tables[0].Rows[0][2].ToString();
            dateTimePicker1.Text = ds.Tables[0].Rows[0][3].ToString();
            txtbprice.Text = ds.Tables[0].Rows[0][4].ToString();
            txtbquantity.Text = ds.Tables[0].Rows[0][5].ToString();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void txtbookname_TextChanged(object sender, EventArgs e)
        {
            if (txtbookname.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = DESKTOP-HQPD7LE\\PAFKIET;  database = Librarymanagement; Integrated Security= True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Select  * from NewBook where bName LIKE  '" + txtbookname.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = DESKTOP-HQPD7LE\\PAFKIET;  database = Librarymanagement; Integrated Security= True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Select  * from NewBook";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update Data.?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {
                string bname = txtbname.Text;
                string bauthor = txtbauthorname.Text;
                string bpdate = dateTimePicker1.Text;
                Int64 price = int.Parse(txtbprice.Text);
                Int64 bquantity = int.Parse(txtbquantity.Text);



                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = DESKTOP-HQPD7LE\\PAFKIET;  database = Librarymanagement; Integrated Security= True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Update NewBook set bName = '" + bname + "',bAuthor= '" + bauthor + "',bPdate= '" + bpdate + "',bPrice = " + bpdate + ",bQuantity= " + bquantity + " where bid=" + info + " ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete Data.?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)

            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = DESKTOP-HQPD7LE\\PAFKIET;  database = Librarymanagement; Integrated Security= True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Delete  From Newbook where bid = " + info + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


            }
        }
    }
}

