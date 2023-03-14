using EmployeeVotingSystem.Data;
using Syncfusion.EJ2.ImageEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeVotingSystem.Forms.Complex
{
	public partial class VotingDetail : System.Web.UI.Page
	{
		private DataLayer _dataLayer = new DataLayer();

		private int _employeeID { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{
				Page lastPage = (Page)Context.Handler;

				if (lastPage is VotingHistory)
				{
					_employeeID = Int32.Parse(((VotingHistory)lastPage).employeeID);
				}
			}

			var employee = _dataLayer.DetailQuery(_employeeID);

			employeeID.Text = employee.ID.ToString();
			employeeName.Text = employee.FullName;
			contactNumber.Text = employee.ContactNumber.ToString();
			salary.Text = employee.Salary.ToString();
			dateOfBirth.Text = (employee.DateOfBirth).ToString("dd MMMM yyyy");
			hireDate.Text = employee.HireDate.ToString("dd MMMM yyyy");
			supervisorID.Text = employee.Supervisor;
			workingMonths.Text = employee.WorkingMonths.ToString();	

			var detail = @"SELECT VH.VOTING_YEAR ""Voting Year"", VH.VOTING_MONTH ""Voting Month"", VH.CANDIDATE_ID ""Candidate ID"", " +
						 @"E.FULL_NAME ""Employee Name"", E.DEPARTMENT_ID ""Department ID"", D.DEPARTMENT_NAME ""Department Name"", " +
						 @"J.JOB_ID ""Job ID"", J.JOB_TITLE ""Job Title"", R.ROLE_ID ""Role ID"", R.ROLE_TYPE ""Role Type"" " +
						 @"FROM EMPLOYEES E " +
						 @"JOIN ""Voting.History"" VH " +
						 "ON E.EMPLOYEE_ID = VH.CANDIDATE_ID " +
						 "JOIN ROLES R " +
						 "ON R.ROLE_ID = E.ROLE_ID " +
						 "JOIN JOBS J " +
						 "ON J.JOB_ID = R.JOB_ID " +
						 "JOIN DEPARTMENTS D " +
						 "ON D.DEPARTMENT_ID = E.DEPARTMENT_ID " +
						$"WHERE VH.VOTER_ID = {_employeeID} " +
						 "ORDER BY DECODE(VH.VOTING_MONTH, 'January', 1, 'February', 2, 'March', 3, 'April', 4, 'May', 5, " +
						 "'June', 6, 'July', 7, 'August', 8, 'September', 9, 'October', 10, 'November', 11, 'December', 12)";

			_dataLayer.FillGridView(detail, gridView);
		}
	}
}