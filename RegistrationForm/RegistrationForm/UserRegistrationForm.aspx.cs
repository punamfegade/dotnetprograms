using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace RegistrationForm 
{
    public partial class UserRegistrationForm : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
           if (Page.IsPostBack == false)
            {
                BindGridview();
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }

       public void ClearData()
        {
           txtFirstName.Text = "";
           txtLastName.Text = "";
           txtUserName.Text = "";
           txtPassword.Text = "";
           txtConfirmPassword.Text = "";
           txtEmail.Text = "";
           txtPhoneNo.Text = "";
           txtLocation.Text = "";

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Insert into Students (UserName,Password,FirstName,LastName,Email,PhoneNo,Location )values (@UserName,@Password,@FirstName,@LastName,@Email,@PhoneNo,@Location)", conn);
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@PhoneNo", txtPhoneNo.Text);
                cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                ClearData();
                lblMessage.Visible = true;
                lblMessage.Text = "User Registered successfully.";
                BindGridview();

            }

            catch (Exception ex)
            {
            }

            finally
            {
                conn.Close();
            }

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string SID = lblId.Text;
                SqlCommand cmd = new SqlCommand("update Students Set UserName=@UserName,Password=@Password,FirstName=@FirstName,LastName=@LastName,Email=@Email,PhoneNo=@PhoneNo,Location=@Location where Id=@ID", conn);
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@PhoneNo", txtPhoneNo.Text);
                cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
                cmd.Parameters.AddWithValue("@ID", SID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                lblMessage.Visible = true;
                lblMessage.Text = "Student Updated successfully.";
                GridViewStudent.EditIndex = -1;
                BindGridview();
                btnUpdate.Visible = false;
                btnSave.Visible = true;

            }

            catch (Exception ex)
            {
            }

            finally
            {
                conn.Close();

            }



        }



        public void BindGridview()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from Students", conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                conn.Open();
                DataSet ds = new DataSet();
                adp.Fill(ds);
                GridViewStudent.DataSource = ds;
                GridViewStudent.DataBind();
                conn.Close();
            }

            catch (Exception ex)
            {

            }
            finally
            {

            }
        }



        protected void GridViewStudent_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow row = GridViewStudent.SelectedRow;
            lblId.Text = row.Cells[2].Text;
            txtUserName.Text = row.Cells[3].Text;
            txtPassword.Text = row.Cells[4].Text;
            txtConfirmPassword.Text = row.Cells[4].Text;
            txtFirstName.Text = row.Cells[5].Text;
            txtLastName.Text = row.Cells[6].Text;
            txtEmail.Text = row.Cells[7].Text;
            txtPhoneNo.Text = row.Cells[8].Text;
            txtLocation.Text = row.Cells[9].Text;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            lblMessage.Visible = false;

        }



        protected void GridViewStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {   try
            {
                conn.Open();
                int SID = Convert.ToInt32(GridViewStudent.DataKeys[e.RowIndex].Value);
                SqlCommand cmd = new SqlCommand("Delete From Students where Id='" + SID + "'", conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                lblMessage.Visible = true;
                lblMessage.Text = "Student deleted successfully.";
                GridViewStudent.EditIndex = -1;
                BindGridview();

            }

            catch (Exception ex)
            {
            }

            finally
            {
                conn.Close();
            }
        }

    }

}