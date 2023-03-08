using EmployeeVotingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeVotingSystem.Forms.Simple
{
    public partial class Jobs : System.Web.UI.Page
    {
        private string _jobID;

        private DataLayer _dataLayer;

        protected enum MessageType { Success, Error, Info, Warning };

        protected void Page_Load(object sender, EventArgs e)
        {
            var query = @"SELECT JOB_ID ""Job ID"", JOB_TITLE ""Job Title"", MIN_SALARY ""Min Salary"", MAX_SALARY ""Max Salary""" +
                         "FROM JOBS";

            _dataLayer = new DataLayer();
            _dataLayer.FillGridView(query, gridView);
        }

        protected void ShowMessage(string message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(),
                "ShowMessage('" + message + "','" + type + "');", true);
        }


        protected void SelectIndexChanged(object sender, EventArgs e)
        {
            _jobID = gridView.SelectedRow.Cells[1].Text.ToString();

            jobID.ReadOnly = true;
            jobID.Text = _jobID;
            jobTitle.Text = gridView.SelectedRow.Cells[2].Text.ToString();
            minSalary.Text = gridView.SelectedRow.Cells[3].Text.ToString();
            maxSalary.Text = gridView.SelectedRow.Cells[4].Text.ToString();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            gridView.DataBind();
        }

        protected void AddJob(object sender, EventArgs e)
        {
            string query = $"INSERT INTO " +
                           $"JOBS (JOB_ID, JOB_TITLE, MIN_SALARY, MAX_SALARY) " +
                           $"VALUES ('{jobID.Text}', '{jobTitle.Text}', {minSalary.Text}, {maxSalary.Text})";


            var result = _dataLayer.QueryExecution(query, "job");

            jobID.Text = "";
            jobTitle.Text = "";
            minSalary.Text = "";
            maxSalary.Text = "";
        }

        protected void NotifyFunction(object sender, EventArgs e)
        {
            ShowMessage("Notification Type", MessageType.Success);
        }

        protected void UpdateJob(object sender, EventArgs e)
        {
            string query = $"UPDATE JOBS " +
                           $"SET JOB_TITLE = '{jobTitle.Text}', " +
                           $"MIN_SALARY = {minSalary.Text}, " +
                           $"MAX_SALARY = {maxSalary.Text} " +
                           $"WHERE JOB_ID = '{jobID.Text}' ";

            var result = _dataLayer.QueryExecution(query, "job");

            jobID.Text = "";
            jobTitle.Text = "";
            minSalary.Text = "";
            maxSalary.Text = "";
        }

        protected void DeleteJob(object sender, EventArgs e)
        {
            string query = $"DELETE FROM JOBS WHERE JOB_ID = '{jobID.Text}'";

            var result = _dataLayer.QueryExecution(query, "job");

            jobID.Text = "";
            jobTitle.Text = "";
            minSalary.Text = "";
            maxSalary.Text = "";
        }

        protected void ClearTextFields(object sender, EventArgs e)
        {
			jobID.ReadOnly = false;

			jobID.Text = "";
            jobTitle.Text = "";
            minSalary.Text = "";
            maxSalary.Text = "";
        }
    }
}