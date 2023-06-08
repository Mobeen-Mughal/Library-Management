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
    public partial class Addbook : Form
    {
        public Addbook()
        {
            InitializeComponent();
        }

        private void Addbook_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string bname = txtBookname.Text;
            string bauthor = txtBookauthor.Text;
            string bPdate = dateTimePicker1.Text;
            Int64 bprice = Int64.Parse(txtbookprice.Text);
            Int64 bquantity = Int64.Parse(txtbookqauntity.Text);


            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source =DESKTOP-HQPD7LE\\PAFKIET;  database = Librarymanagement; Integrated Security= True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            con.Open();
            cmd.CommandText = "insert into NewBook (bName,bAuthor,bPdate,bPrice,bQuantity) values ('" + bname + "','" + bauthor + "','" + bPdate + "','" + bprice + "', '" + bquantity + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
