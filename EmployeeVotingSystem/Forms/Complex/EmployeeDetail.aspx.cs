using System;
using System.Web.UI;
using EmployeeVotingSystem.Data;
using EmployeeVotingSystem.Forms.Simple;

namespace EmployeeVotingSystem.Forms.Complex
{
	public partial class EmployeeDetail : System.Web.UI.Page
	{
		private DataLayer _dataLayer = new DataLayer();

		private int _employeeID;

		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				Page lastPage = (Page)Context.Handler;

				if(lastPage is JobHistory)
				{
					_employeeID = Int32.Parse(((JobHistory)lastPage).employeeID);
				}
			}

			var employee = _dataLayer.DetailQuery(_employeeID);

			employeeID.Text = employee.ID.ToString();
			employeeName.Text = employee.FullName;
			contactNumber.Text = employee.ContactNumber.ToString();
			salary.Text = employee.Salary.ToString();
			dateOfBirth.Text = (employee.DateOfBirth).ToString("dd MMMM yyyy");
			hireDate.Text = employee.HireDate.ToString("dd MMMM yyyy");
			workingMonths.Text = employee.WorkingMonths.ToString();
			supervisorID.Text = employee.Supervisor; 

			var detail = @"SELECT R.ROLE_ID ""Role ID"", R.ROLE_TYPE ""Role Type"", J.JOB_ID ""Job ID"", J.JOB_TITLE ""Job Title"", " + 
						 @"D.DEPARTMENT_ID ""Department ID"", D.DEPARTMENT_NAME ""Department Name"", EH.START_DATE ""Start Date"", EH.END_DATE ""End Date"", " +
                         @"(TRUNC(TO_DATE(END_DATE, 'DD-MON-YYYY') - TO_DATE(START_DATE, 'DD-MON-YYYY'))) ""Days Between"" " +
                         @"FROM EMPLOYEES E " +
						 @"JOIN ""Employee.History"" EH " +
						  "ON E.EMPLOYEE_ID = EH.EMPLOYEE_ID " +
						  "JOIN ROLES R " + 
						  "ON R.ROLE_ID = EH.ROLE_ID " +
						  "JOIN JOBS J " +
						  "ON J.JOB_ID = R.JOB_ID " +
						  "JOIN DEPARTMENTS D " +
						  "ON D.DEPARTMENT_ID = EH.DEPARTMENT_ID " +
						 $"WHERE E.DEPARTMENT_ID != EH.DEPARTMENT_ID AND E.ROLE_ID != EH.ROLE_ID AND EH.EMPLOYEE_ID = {_employeeID} " + 
						 @"ORDER BY ""Start Date"" ";

            _dataLayer.FillGridView(detail, gridView);
		}
	}
}