using EmployeeVotingSystem.Data;
using System;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeVotingSystem.Forms.Simple
{
    public partial class Departments : System.Web.UI.Page
    {
        private string _departmentID;
        
        private DataLayer _dataLayer;
        
        protected enum MessageType { Success, Error, Info, Warning };

        protected void Page_Load(object sender, EventArgs e)
        {
            var query = @"SELECT DEPARTMENT_ID ""Department ID"", DEPARTMENT_NAME ""Department Name"", FLOOR ""Floor""" + 
                         "FROM DEPARTMENTS";
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
            _departmentID = gridView.SelectedRow.Cells[1].Text.ToString();

            departmentID.ReadOnly = true;
            departmentID.Text = _departmentID;
            departmentName.Text = gridView.SelectedRow.Cells[2].Text.ToString();
            departmentFloor.Text = gridView.SelectedRow.Cells[3].Text.ToString();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            gridView.DataBind();
        }

        protected void AddDepartment(object sender, EventArgs e)
        {
            string query = $"INSERT INTO " +
                           $"DEPARTMENTS (DEPARTMENT_ID, DEPARTMENT_NAME, FLOOR) " +
                           $"VALUES ('{departmentID.Text}', '{departmentName.Text}', {departmentFloor.Text})";


            var result = _dataLayer.QueryExecution(query, "Department");

            labelMessage.Text = result;

            departmentID.Text = "";
            departmentName.Text = "";
            departmentFloor.Text = "";

        }

        protected void NotifyFunction(object sender, EventArgs e)
        {
            ShowMessage("Notification Type", MessageType.Success);
        }

        protected void UpdateDepartment(object sender, EventArgs e)
        {
            string query = $"UPDATE DEPARTMENTS " +
                           $"SET DEPARTMENT_ID = '{departmentID.Text}', " +
                           $"DEPARTMENT_NAME = '{departmentName.Text}', " +
                           $"FLOOR = {departmentFloor.Text} " +
                           $"WHERE DEPARTMENT_ID = '{departmentID.Text}'";

            var result = _dataLayer.QueryExecution(query, "Department");
            
            labelMessage.Text = result;

            departmentID.Text = "";
            departmentName.Text = "";
            departmentFloor.Text = "";
        }

        protected void DeleteDepartment(object sender, EventArgs e)
        {
            string query = $"DELETE FROM DEPARTMENTS WHERE DEPARTMENT_ID = '{departmentID.Text}'";

            var result = _dataLayer.QueryExecution(query, "Department");

            labelMessage.Text = result;

            departmentID.Text = "";
            departmentName.Text = "";
            departmentFloor.Text = "";
        }

        protected void ClearTextFields(object sender, EventArgs e)
        {
			departmentID.ReadOnly = false;
			
            departmentID.Text = "";
            departmentName.Text = "";
            departmentFloor.Text = "";
            labelMessage.Text = "";
        }

        
    }
}