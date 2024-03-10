using EmployeeVotingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeVotingSystem.Forms.Simple
{
    public partial class Roles : System.Web.UI.Page
    {
        private string _roleID;

        private DataLayer _dataLayer = new DataLayer();

        protected enum MessageType { Success, Error, Info, Warning };

        protected void Page_Load(object sender, EventArgs e)
        {
			var query = @"SELECT R.ROLE_ID ""Role ID"", R.ROLE_TYPE ""Role Type"", J.JOB_TITLE ""Job Title"" " +
						 "FROM ROLES R " +
						 "JOIN JOBS J " +
						 "ON R.JOB_ID = J.JOB_ID";

			_dataLayer.FillGridView(query, gridView);

			if (!IsPostBack)
            {

				var jobQuery = "SELECT JOB_ID, JOB_TITLE FROM JOBS";
				var title = "JOB_TITLE";
				var value = "JOB_ID";

				var dropDownList = jobID;

				_dataLayer.FillDropDown(jobQuery, dropDownList, title, value);
			}
        }

        protected void ShowMessage(string message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(),
                "ShowMessage('" + message + "','" + type + "');", true);
        }


        protected void SelectIndexChanged(object sender, EventArgs e)
        {
            _roleID = gridView.SelectedRow.Cells[1].Text.ToString();

            roleID.ReadOnly = true;

			roleID.Text = _roleID;
            roleType.Text = gridView.SelectedRow.Cells[2].Text.ToString();

			var job = _dataLayer.ReturnQuery($"SELECT JOB_ID FROM JOBS WHERE JOB_TITLE = '{gridView.SelectedRow.Cells[3].Text}'");

			jobID.Text = job;
        }

		protected void DataBinding(object sender, EventArgs e)
		{
			if (jobID.SelectedIndex != -1)
			{
				jobID.SelectedIndex = 0;
			}
		}

		protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            gridView.DataBind();
        }

        protected void AddRole(object sender, EventArgs e)
        {
			string query = $"INSERT INTO " +
                           $"ROLES (ROLE_ID, ROLE_TYPE, JOB_ID) " +
                           $"VALUES ('{roleID.Text}', '{roleType.Text}', '{jobID.Text}')";

            var result = _dataLayer.QueryExecution(query, "Role");

			labelMessage.Text = result;

			if (result.ToLower().Contains("violation"))
			{
				labelMessage.ForeColor = System.Drawing.Color.Red;
			}

			labelMessage.ForeColor = System.Drawing.Color.Green;

			roleID.ReadOnly = false;

            roleID.Text = "";
			roleType.Text = "";
        }

        protected void NotifyFunction(object sender, EventArgs e)
        {
            ShowMessage("Notification Type", MessageType.Success);
        }

        protected void UpdateRole(object sender, EventArgs e)
        {
            string query = $"UPDATE ROLES " +
                           $"SET ROLE_TYPE = '{roleType.Text}', " +
                           $"JOB_ID = '{jobID.Text}' " +
                           $"WHERE ROLE_ID = '{roleID.Text}' ";

            var result = _dataLayer.QueryExecution(query, "Role");

			labelMessage.Text = result;
			labelMessage.ForeColor = System.Drawing.Color.Purple;

			roleID.ReadOnly = false;

			roleID.Text = "";
            roleType.Text = "";
        }

        protected void DeleteRole(object sender, EventArgs e)
        {
            string query = $"DELETE FROM ROLES WHERE ROLE_ID = '{roleID.Text}'";

            var result = _dataLayer.QueryExecution(query, "Role");

			labelMessage.Text = result;
			labelMessage.ForeColor = System.Drawing.Color.Red;

			roleID.ReadOnly = false;

			roleID.Text = "";
            roleType.Text = "";
        }

        protected void ClearTextFields(object sender, EventArgs e)
        {
			roleID.ReadOnly = false;

			roleID.Text = "";
            roleType.Text = "";
        }
    }
}