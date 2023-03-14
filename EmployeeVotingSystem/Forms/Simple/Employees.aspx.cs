using EmployeeVotingSystem.Data;
using Newtonsoft.Json.Linq;
using Syncfusion.EJ2.DropDowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeVotingSystem.Forms.Simple
{
    public partial class Employees : System.Web.UI.Page
    {
        private string _employeeID;

        private DataLayer _dataLayer = new DataLayer();

        protected enum MessageType { Success, Error, Info, Warning };

        protected void Page_Load(object sender, EventArgs e)
        {
            var query = @"SELECT E.EMPLOYEE_ID ""Employee ID"", E.FULL_NAME ""Employee Name"", E.CONTACT_NUMBER ""Contact Number"", " +
                        @"E.DATE_OF_BIRTH ""Date of Birth"", E.HIRE_DATE ""Hire Date"", E.SALARY ""Salary"", " +
                        @"R.ROLE_TYPE ""Role"", D.DEPARTMENT_NAME ""Department"", EMP.FULL_NAME ""Supervisor"" " +
                         "FROM EMPLOYEES E " +
                         "JOIN ROLES R " +
                         "ON E.ROLE_ID = R.ROLE_ID " +
                         "JOIN DEPARTMENTS D " +
                         "ON E.DEPARTMENT_ID = D.DEPARTMENT_ID " +
                         "LEFT JOIN EMPLOYEES EMP " +
                         "ON E.SUPERVISOR_ID = EMP.EMPLOYEE_ID " +
                         "ORDER BY E.EMPLOYEE_ID";

			var roleQuery = "SELECT ROLE_ID, ROLE_TYPE FROM ROLES";
			var roleTitle = "ROLE_TYPE";
			var roleValue = "ROLE_ID";
			var roleDropDownList = roleID;

			var departmentQuery = "SELECT DEPARTMENT_ID, DEPARTMENT_NAME FROM DEPARTMENTS";
			var departmentTitle = "DEPARTMENT_NAME";
			var departmentValue = "DEPARTMENT_ID";
            var departmentDropDownList = departmentID;

			var supervisorQuery = "SELECT EMPLOYEE_ID, FULL_NAME FROM EMPLOYEES";
			var supervisorTitle = "FULL_NAME";
			var supervisorValue = "EMPLOYEE_ID";
			var supervisorDropDownList = supervisorID;

			_dataLayer.FillDropDown(roleQuery, roleDropDownList, roleTitle, roleValue);
            _dataLayer.FillDropDown(departmentQuery, departmentDropDownList, departmentTitle, departmentValue);
            _dataLayer.FillDropDown(supervisorQuery, supervisorDropDownList, supervisorTitle, supervisorValue);

			_dataLayer.FillGridView(query, gridView);
        }

        protected void ShowMessage(string message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(),
                "ShowMessage('" + message + "','" + type + "');", true);
        }


        protected void SelectIndexChanged(object sender, EventArgs e)
        {
            _employeeID = gridView.SelectedRow.Cells[1].Text.ToString();

			employeeID.ReadOnly = true;
			employeeID.Text = _employeeID;
            employeeName.Text = gridView.SelectedRow.Cells[2].Text.ToString();
            contactNumber.Text = gridView.SelectedRow.Cells[3].Text.ToString();
            dateOfBirth.Text = gridView.SelectedRow.Cells[4].Text.ToString();
            hireDate.Text = gridView.SelectedRow.Cells[5].Text.ToString();
            salary.Text = gridView.SelectedRow.Cells[6].Text.ToString();

            var role = _dataLayer.ReturnQuery($"SELECT ROLE_ID FROM ROLES WHERE ROLE_TYPE = '{gridView.SelectedRow.Cells[7].Text}'");
            var department = _dataLayer.ReturnQuery($"SELECT DEPARTMENT_ID FROM DEPARTMENTS WHERE DEPARTMENT_NAME = '{gridView.SelectedRow.Cells[8].Text}'");
            var supervisor = _dataLayer.ReturnQuery($"SELECT EMPLOYEE_ID  FROM EMPLOYEES WHERE  FULL_NAME = '{gridView.SelectedRow.Cells[9].Text}'");

            roleID.Text = role;
            departmentID.Text = department;
            supervisorID.Text = supervisor;
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            gridView.DataBind();
        }

        protected void AddEmployee(object sender, EventArgs e)
        {
			var idQuery = "SELECT MAX(EMPLOYEE_ID) FROM EMPLOYEES";

			var employeeId = Int32.Parse(_dataLayer.ReturnQuery(idQuery)) + 1;

			string query = $"INSERT INTO " +
                           $"EMPLOYEES (EMPLOYEE_ID, FULL_NAME, CONTACT_NUMBER, DATE_OF_BIRTH, HIRE_DATE, SALARY, ROLE_ID, DEPARTMENT_ID, SUPERVISOR_ID) " +
                           $"VALUES ({employeeId}, '{employeeName.Text}', {contactNumber.Text}, TO_DATE('{dateOfBirth.Text}', 'YYYY-MM-DD'), TO_DATE('{hireDate.Text}', 'YYYY-MM-DD'), {salary.Text}, '{roleID.Text}', '{departmentID.Text}', {supervisorID.Text})";


            var result = _dataLayer.QueryExecution(query, "job");

            employeeID.Text = "";
            employeeName.Text = "";
            contactNumber.Text = "";
            dateOfBirth.Text = "";
            hireDate.Text = "";
            salary.Text = "";
        }

        protected void NotifyFunction(object sender, EventArgs e)
        {
            ShowMessage("Notification Type", MessageType.Success);
        }

        protected void UpdateEmployee(object sender, EventArgs e)
        {
            string query = $"UPDATE EMPLOYEES " +
                           $"SET FULL_NAME = '{employeeName.Text}', " +
                           $"CONTACT_NUMBER = {contactNumber.Text}, " +
                           $"DATE_OF_BIRTH = TO_DATE('{dateOfBirth.Text}', 'YYYY-MM-DD'), " +
                           $"HIRE_DATE = TO_DATE('{hireDate.Text}', 'YYYY-MM-DD'), " +
                           $"SALARY = {salary.Text}, " +
                           $"ROLE_ID = '{roleID.Text}', " +
                           $"DEPARTMENT_ID = '{departmentID.Text}', " +
                           $"SUPERVISOR_ID = {supervisorID.Text} " +
                           $"WHERE EMPLOYEE_ID = {employeeID.Text}";

            var result = _dataLayer.QueryExecution(query, "job");

            employeeID.Text = "";
            employeeName.Text = "";
            contactNumber.Text = "";
            dateOfBirth.Text = "";
            hireDate.Text = "";
            salary.Text = "";
        }

        protected void DeleteEmployee(object sender, EventArgs e)
        {
            string query = $"DELETE FROM EMPLOYEES WHERE EMPLOYEE_ID = '{employeeID.Text}'";

            var result = _dataLayer.QueryExecution(query, "job");

            employeeID.Text = "";
            employeeName.Text = "";
            contactNumber.Text = "";
            dateOfBirth.Text = "";
            hireDate.Text = "";
            salary.Text = "";

            ClearTextFields(sender, e);
        }

        protected void ClearTextFields(object sender, EventArgs e)
        {
            employeeID.Text = "";
            employeeName.Text = "";
            contactNumber.Text = "";
            dateOfBirth.Text = "";
            hireDate.Text = "";
            salary.Text = "";
        }
    }
}