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
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.RowCount &&
                e.ColumnIndex >= 0 && e.ColumnIndex < dataGridView1.ColumnCount)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null)
                {
                    address = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                }

                panel2.Visible = true;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=DESKTOP-HQPD7LE\\PAFKIET;Database=Librarymanagement;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                info = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["bid"].Value);

                cmd.CommandText = "SELECT * FROM NewBook WHERE bid = @info";
                cmd.Parameters.AddWithValue("@info", info);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtbname.Text = ds.Tables[0].Rows[0]["bName"].ToString();
                    txtbauthorname.Text = ds.Tables[0].Rows[0]["bAuthor"].ToString();
                    dateTimePicker1.Text = ds.Tables[0].Rows[0]["bPdate"].ToString();
                    txtbprice.Text = ds.Tables[0].Rows[0]["bPrice"].ToString();
                    txtbquantity.Text = ds.Tables[0].Rows[0]["bQuantity"].ToString();
                }
            }
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
            if (MessageBox.Show("Update Data?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string bname = txtbname.Text;
                string bauthor = txtbauthorname.Text;
                string bpdate = dateTimePicker1.Text;
                Int64 price = Int64.Parse(txtbprice.Text);
                Int64 bquantity = Int64.Parse(txtbquantity.Text);

                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-HQPD7LE\\PAFKIET;Database=Librarymanagement;Integrated Security=True"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "UPDATE NewBook SET bName = @bname, bAuthor = @bauthor, bPdate = @bpdate, bPrice = @bprice, bQuantity = @bquantity WHERE bid = @info";
                    cmd.Parameters.AddWithValue("@bname", bname);
                    cmd.Parameters.AddWithValue("@bauthor", bauthor);
                    cmd.Parameters.AddWithValue("@bpdate", bpdate);
                    cmd.Parameters.AddWithValue("@bprice", price);
                    cmd.Parameters.AddWithValue("@bquantity", bquantity);
                    cmd.Parameters.AddWithValue("@info", info);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete Data?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-HQPD7LE\\PAFKIET;Database=Librarymanagement;Integrated Security=True"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "DELETE FROM NewBook WHERE bid = @info";
                    cmd.Parameters.AddWithValue("@info", info);

                    cmd.ExecuteNonQuery();

                }
            }

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}

