using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SemesterProject_XuanLu1
{
    public partial class frmCustomerInf : Form
    {
        /// <summary>
        /// use dataTable handle datagrid file
        /// </summary>
        DataTable table= new DataTable ("table");
        int index;
        public frmCustomerInf()
        {
            InitializeComponent();
        }
        /// <summary>
        /// DataGridView add columns
        /// </summary>
        
        private void frmOrder_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("PhoneNumber", Type.GetType ("System.Decimal"));
            table.Columns.Add("FirstName", Type.GetType("System.String"));
            table.Columns.Add("LastName", Type.GetType("System.String"));
            table.Columns.Add("Address", Type.GetType("System.String"));
            table.Columns.Add("Note", Type.GetType("System.String"));
            
            // data grid connect to table
            dataGridView1.DataSource = table;
            
            
        }
       /// <summary>
       /// update customer information
       /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow newdata = dataGridView1.Rows[index];
            newdata.Cells[0].Value = txtPhoneNumber.Text;
            newdata.Cells[1].Value = txtFirstName.Text;
            newdata.Cells[2].Value = txtLastName .Text;
            newdata.Cells[3].Value = txtAddress.Text;
            newdata.Cells[4].Value = txtNote.Text;

        }

        private void btbDelete_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            if(index != -1)
            {
                string msg = " Are you sure you want to delete this customer data?";
                DialogResult button = MessageBox.Show(msg, "Confirm Delete", MessageBoxButtons.YesNo);
                if (button == DialogResult.Yes) 
                {
                    table.Rows[index].Delete();
                }


            }
            
        }
        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";
            errorMessage += Validator.IsDecimal (txtPhoneNumber.Text, txtPhoneNumber.Tag.ToString());
            errorMessage += Validator.IsPresent(txtFirstName.Text, txtFirstName.Tag.ToString());
            errorMessage += Validator.IsPresent(txtLastName.Text, txtLastName.Tag.ToString());
            errorMessage += Validator.IsPresent(txtAddress.Text, txtAddress.Tag.ToString());

            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");

            }
            return success;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// insert user data save to datagridview
        /// </summary>
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                table.Rows.Add(txtPhoneNumber.Text, txtFirstName.Text , txtLastName.Text, 
                                txtAddress.Text ,txtNote.Text);
              
            }
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            txtPhoneNumber.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtAddress.Clear();
            txtNote.Clear();

        }
        /// <summary>
        /// Check if a given text exists in the given DataGridView at a given character
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("FirstName like '%" + txtSearch.Text + "%'");


        }
        /// <summary>
        /// select full row in datagridview
        /// </summary>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                index = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[index];
                txtPhoneNumber.Text = row.Cells[0].Value.ToString();
                txtFirstName.Text = row.Cells[1].Value.ToString();
                txtLastName.Text = row.Cells[2].Value.ToString();
                txtAddress.Text = row.Cells[3].Value.ToString();
                txtNote.Text = row.Cells[4].Value.ToString();
      
        }
        /// <summary>
        ///  programmatically sort the datagridview by string.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnExport_Click(object sender, EventArgs e)
        {
            TextWriter sw = new StreamWriter(@"D:\2021 Spring\visual C#\CM390\programming\SemesterProject_XuanLu1\Text.txt");
            
            for (int i = 0; i < dataGridView1 .Rows .Count ; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    sw.Write("\t" + dataGridView1.Rows[i].Cells [j].Value .ToString ()+"\t"+"|");
                }
                sw.WriteLine("");

            }
            sw.Close();
            MessageBox.Show("Data Exported Successfully!");
        }

        private void rbFirstName_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFirstName.Checked)
            {
                this.dataGridView1.Sort(this.dataGridView1.Columns["FirstName"], ListSortDirection.Ascending);
            }
            else 
            {
                this.dataGridView1.Sort(this.dataGridView1.Columns["LastName"], ListSortDirection.Ascending);
            }
        }
    }
}
