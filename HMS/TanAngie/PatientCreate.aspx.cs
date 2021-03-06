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
    public partial class PatientCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            SqlConnection conDatabase;
            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
            conDatabase = new SqlConnection(connStr);
            conDatabase.Open();
            string strCheck;
            SqlCommand cmdCheck;
            strCheck = "Select * From dbo.Patient Where PatientIC = @IC";
            cmdCheck = new SqlCommand(strCheck, conDatabase);
            cmdCheck.Parameters.AddWithValue("@IC", tbIC.Text);
            SqlDataReader dtr;
            dtr = cmdCheck.ExecuteReader();
            if (dtr.Read())
            {
                lblIcCheckMesg.Text = "The Idendity Card had already exist. Please check from the Patient details.";
            }
            else
            {
                lblIcCheckMesg.Text = "The Idendity Card is Valid.";
            } 
            conDatabase.Close();
            dtr.Close();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm to Create the Patient?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (lblIcCheckMesg.Text.Equals("The Idendity Card is Valid."))
                {
                    int idcheck = loginIDCheck();
                    if (idcheck > 0)
                    {
                        int check = PasswordCheck();
                        if (check > 0)
                        {
                            DataSave();
                            tbAddress.Text = "";  //Reset All The Things
                            tbContactNum.Text = "";
                            tbEmail.Text = "";
                            tbIC.Text = "";
                            tbLoginId.Text = "";
                            tbName.Text = "";
                            tbSecurityPw.Text = "";
                            lblIcCheckMesg.Text = "";
                            ddlSecurityQuestion.ClearSelection();
                            rblGender.ClearSelection();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Check the Validation of Idendity Card.");
                }
            }
        }
        protected void DataSave()
        {
            String PatientID = PatientIdAssign();

            //Data Save
            SqlConnection conDatabase;
            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
            conDatabase = new SqlConnection(connStr);
            conDatabase.Open();

            SqlCommand cmdCreatePatient; //For Patient
            SqlCommand cmdCreateLogin; //For Login
            string strCreateStaff; //For Patient
            string strCreateLogin; //For Login

            //For Login Table
            strCreateLogin = "Insert Into Login (LoginID,LoginPW,SecurityQ,SecurityPW) Values" +
               " (@LoginID,@LoginPW,@SecurityQ,@SecurityPW)";
            cmdCreateLogin = new SqlCommand(strCreateLogin, conDatabase);
            cmdCreateLogin.Parameters.AddWithValue("@LoginID", tbLoginId.Text);
            cmdCreateLogin.Parameters.AddWithValue("@LoginPW", pwPassword.Value);
            cmdCreateLogin.Parameters.AddWithValue("@SecurityQ", ddlSecurityQuestion.SelectedItem.Value);
            cmdCreateLogin.Parameters.AddWithValue("@SecurityPW", tbSecurityPw.Text);
            cmdCreateLogin.ExecuteNonQuery();

            //For Staff Table
            strCreateStaff = "Insert Into Patient (PatientID,PatientIC,PatientName,PatientGender," +
                "PatientAddr,PatientContactNo,PatientEmail,PatientStatus,LoginID) "+
                "Values (@PatientID,@PatientIC,@PatientName,@PatientGender," +
                "@PatientAddr,@PatientContactNo,@PatientEmail,@PatientStatus,@LoginID)";
            cmdCreatePatient = new SqlCommand(strCreateStaff, conDatabase);
            cmdCreatePatient.Parameters.AddWithValue("@PatientID", PatientID);
            cmdCreatePatient.Parameters.AddWithValue("@PatientIC", tbIC.Text);
            cmdCreatePatient.Parameters.AddWithValue("@PatientName", tbName.Text);
            cmdCreatePatient.Parameters.AddWithValue("@PatientGender", rblGender.SelectedItem.Value);
            cmdCreatePatient.Parameters.AddWithValue("@PatientAddr", tbAddress.Text);
            cmdCreatePatient.Parameters.AddWithValue("@PatientContactNo", tbContactNum.Text);
            cmdCreatePatient.Parameters.AddWithValue("@PatientEmail", tbEmail.Text);
            cmdCreatePatient.Parameters.AddWithValue("@PatientStatus","");
            cmdCreatePatient.Parameters.AddWithValue("@LoginID", tbLoginId.Text);
            int n = cmdCreatePatient.ExecuteNonQuery();
            if (n > 0)
            {
                MessageBox.Show("New Patient's Details had Saved Successfuly.\n\nPatient ID : " + PatientID);
            }
            else
                MessageBox.Show("Error, the Data Cannot be Saved.");

            conDatabase.Close();
        }
        protected int PasswordCheck()
        {
            if (pwPassword.Value.Equals(pwConfirm.Value))
            {
                return 1;
            }
            else
            {
                MessageBox.Show("Please Check that Password must Same with Confirm Password.");
                return 0;
            }
        }
        protected String PatientIdAssign()
        {
            String lastId;
            String convertId;
            Int32 idAdd1;
            String newId = null;

            SqlConnection conDatabase;
            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
            conDatabase = new SqlConnection(connStr);
            conDatabase.Open();
            string strCheck;
            SqlCommand cmdCheck;
            strCheck = "Select TOP 1 PatientID From dbo.Patient Order By PatientID DESC";
            cmdCheck = new SqlCommand(strCheck, conDatabase);
            SqlDataReader dtr;
            dtr = cmdCheck.ExecuteReader();
            if (dtr.Read())
            {
                lastId = "" + dtr["PatientID".ToString()];
                convertId = lastId.Substring(1);
                idAdd1 = Convert.ToInt32(convertId);
                idAdd1 += 1;
                if (idAdd1 < 9)
                    newId = "P000" + Convert.ToString(idAdd1);
                else if (idAdd1 < 99)
                    newId = "P00" + Convert.ToString(idAdd1);
                else if (idAdd1 < 999)
                    newId = "P0" + Convert.ToString(idAdd1);
                else if (idAdd1 < 9999)
                    newId = "P" + Convert.ToString(idAdd1);
            }
            else
            {
                MessageBox.Show("Patient ID Assign Failed.");
            }
            conDatabase.Close();
            dtr.Close();
            return newId;
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm to Reset All?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tbAddress.Text = "";
                tbContactNum.Text = "";
                tbEmail.Text = "";
                tbIC.Text = "";
                tbLoginId.Text = "";
                tbName.Text = "";
                tbSecurityPw.Text = "";
                lblIcCheckMesg.Text = "";
                ddlSecurityQuestion.ClearSelection();
                rblGender.ClearSelection();
            }
        }
        protected int loginIDCheck()
        {
            SqlConnection conDatabase;
            string connStr = ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString;
            conDatabase = new SqlConnection(connStr);
            conDatabase.Open();
            string strCheck;
            SqlCommand cmdCheck;
            strCheck = "Select * From dbo.Login Where LoginID = @LoginID";
            cmdCheck = new SqlCommand(strCheck, conDatabase);
            cmdCheck.Parameters.AddWithValue("@LoginID",tbLoginId.Text);
            SqlDataReader dtr;
            dtr = cmdCheck.ExecuteReader();
            if (dtr.Read())
            {
                MessageBox.Show("The LoginID had already exist.Please insert a new LoginID.");
                conDatabase.Close();
                dtr.Close();
                return 0;
            }
            else
            {
                conDatabase.Close();
                dtr.Close();
                return 1;
            }
        }
    }
}