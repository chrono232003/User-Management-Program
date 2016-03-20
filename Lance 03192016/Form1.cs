using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lance_03192016
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += new System.EventHandler(buttonClickAdd);
            button2.Click += new System.EventHandler(buttonClickSearch);
         }
        //Handles the addition of new users
        private void buttonClickAdd(object sender, EventArgs e)
        {
            queryAdd();
        }
        private void queryAdd()
        {
        //Call the database class 
           Class1 connClass = new Class1();
           SqlConnection conn = connClass.dataBaseConnect();

            try
            {
                conn.Open();
                
                SqlCommand command = new SqlCommand("INSERT INTO People (FirstName, LastName, Sex, DOB) VALUES ('" + textBoxFirst.Text + "' , '" + textBoxLast.Text + "' , '" + textBoxSex.Text + "' , '" + textBoxDOB.Text + "')", conn);
                if (textBoxFirst.Text != "" && textBoxLast.Text != "" && textBoxFirst.Text != "" && textBoxDOB.Text != "")   
                {
                    command.ExecuteNonQuery();
                    label1.Text = "Query ran successfully";
                }
                else
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = "forgot to add all the information needed";
                }
                conn.Close();
            }
            catch (SqlException e)
            {
                label1.Text = e.GetBaseException().ToString();
            }
        }
        //Handles the search function
        private void buttonClickSearch(object sender, EventArgs e)
        {
            querySearch();
        }
        private void querySearch()
        {
            //Call the database class 
            Class1 connClass = new Class1();
            SqlConnection conn = connClass.dataBaseConnect();
            try
            {
                conn.Open();
                SqlDataReader reader = null;
                SqlCommand command = new SqlCommand("SELECT FirstName, LastName, Sex, DOB FROM people WHERE LastName = '" + textBoxSearch.Text + "'", conn);
                reader = command.ExecuteReader();
                //populate a gridview
                if (reader.HasRows)
                {
                DataTable table = new DataTable();
                table.Load(reader);
                dataGridView1.DataSource = table;
               
                //Populate text boxes
                    //while (reader.Read())
                    //{

                    //    textBoxFirst.Text = reader["FirstName"].ToString();
                    //    textBoxLast.Text = reader["LastName"].ToString();
                    //    textBoxSex.Text = reader["Sex"].ToString();
                    //    textBoxDOB.Text = reader["DOB"].ToString();
                    //    label1.ForeColor = Color.Blue;
                    //    label1.Text = "1 result Found";
                    //    //MessageBox.Show("We found data!");
                    //}
                }
                else
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = "No results were found";
                    //MessageBox.Show("No Data Found!");
                }

                conn.Close();
            }
            catch (Exception e)
            {
                label1.Text = e.GetBaseException().ToString();
            }
        }
        private void SetUpDataGridView()
        {
            DataGridViewCellStyle style =
      dataGridView1.ColumnHeadersDefaultCellStyle;
            style.BackColor = Color.Navy;
            style.ForeColor = Color.White;
            style.Font = new Font(dataGridView1.Font, FontStyle.Bold);

            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Location = new Point(8, 8);
            dataGridView1.Size = new Size(500, 300);
            dataGridView1.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView1.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Raised;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView1.GridColor = SystemColors.ActiveBorder;
            dataGridView1.RowHeadersVisible = false;
        }

       }
}
