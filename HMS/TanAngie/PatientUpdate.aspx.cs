﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace StaffManagement
{
    public partial class PatientUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String patientid = Request.QueryString["patientid"];
                SqlConnection conDatabase;
                string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
                conDatabase = new SqlConnection(connStr);
                conDatabase.Open();
                string strGet;
                SqlCommand cmdGet;
                strGet = "Select * From Patient Where PatientID = @ID";
                cmdGet = new SqlCommand(strGet, conDatabase);
                cmdGet.Parameters.AddWithValue("@ID", patientid);
                SqlDataReader dtr;
                dtr = cmdGet.ExecuteReader();
                if (dtr.Read())
                {
                    tbAddress.Text = dtr["PatientAddr"].ToString();
                    tbContactNum.Text = dtr["PatientContactNo"].ToString();
                    tbEmail.Text = dtr["PatientEmail"].ToString();
                    tbGender.Text = dtr["PatientGender"].ToString();
                    tbIC.Text = dtr["PatientIC"].ToString();
                    tbName.Text = dtr["PatientName"].ToString();
                    tbPatientId.Text = dtr["PatientId"].ToString();
                }
                else
                {
                    MessageBox.Show("Error.Cannot get Patient Details.");
                }
                conDatabase.Close();
                dtr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Login First.");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm to update the details?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conDatabase;
                string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
                conDatabase = new SqlConnection(connStr);
                conDatabase.Open();
                string strUpdate;
                SqlCommand cmdUpdate;
                strUpdate = "Update Patient Set PatientAddr=@Address, PatientContactNo=@contactNo, PatientEmail=@Email,"
                    + " Where PatientID = @ID";
                cmdUpdate = new SqlCommand(strUpdate, conDatabase);
                cmdUpdate.Parameters.AddWithValue("@ID", tbPatientId.Text);
                cmdUpdate.Parameters.AddWithValue("@Address", tbAddress.Text);
                cmdUpdate.Parameters.AddWithValue("@contactNo", tbContactNum.Text);
                cmdUpdate.Parameters.AddWithValue("@Email", tbEmail.Text);
                int n = cmdUpdate.ExecuteNonQuery();
                if (n > 0)
                    MessageBox.Show("Your Update already Success.");
                else
                    MessageBox.Show("Cannot be Update.");
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                String patientid = tbPatientId.Text;
                SqlConnection conDatabase;
                string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
                conDatabase = new SqlConnection(connStr);
                conDatabase.Open();
                string strGet;
                SqlCommand cmdGet;
                strGet = "Select * From Patient Where PatientID = @ID";
                cmdGet = new SqlCommand(strGet, conDatabase);
                cmdGet.Parameters.AddWithValue("@ID", patientid);
                SqlDataReader dtr;
                dtr = cmdGet.ExecuteReader();
                if (dtr.Read())
                {
                    tbAddress.Text = dtr["PatientAddr"].ToString();
                    tbContactNum.Text = dtr["PatientContactNo"].ToString();
                    tbEmail.Text = dtr["PatientID"].ToString();
                    tbGender.Text = dtr["PatientGender"].ToString();
                    tbIC.Text = dtr["PatientIC"].ToString();
                    tbName.Text = dtr["PatientName"].ToString();
                    tbPatientId.Text = dtr["PatientId"].ToString();
                }
                else
                {
                    MessageBox.Show("Error.Cannot get Patient Details.");
                }
                conDatabase.Close();
                dtr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Login First.");
            }
        }
    }
}