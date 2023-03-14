using EmployeeVotingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeVotingSystem.Forms.Complex
{
	public partial class EmployeeMonth : System.Web.UI.Page
	{
		private string _month { get; set; }

		private int _employeeID { get; set; }

		private DataLayer _dataLayer = new DataLayer();

		protected void Page_Load(object sender, EventArgs e)
		{
			//SELECT* FROM
			//(SELECT VH.CANDIDATE_ID, E.EMPLOYEE_NAME, COUNT(CANDIDATE_ID) AS "TOTAL_VOTES"
			//FROM "Voting.History" VH
			//JOIN EMPLOYEES E
			//ON VH.CANDIDATE_ID = E.EMPLOYEE_ID
			//WHERE VOTING_MONTH = 'December'
			//GROUP BY VH.CANDIDATE_ID, E.EMPLOYEE_NAME
			//ORDER BY COUNT(VH.CANDIDATE_ID) DESC)
			//WHERE ROWNUM <= 3;

			if (!IsPostBack)
			{
				Page lastPage = (Page)Context.Handler;

				if (lastPage is VotingRecord)
				{
					_month = ((VotingRecord)lastPage).month;
				}
			}

			var employeeQuery = @"SELECT * FROM " +
								@"(SELECT VH.CANDIDATE_ID " +
								@"FROM ""Voting.History"" VH " +
								@"JOIN EMPLOYEES E " +
								 "ON VH.CANDIDATE_ID = E.EMPLOYEE_ID " +
								$"WHERE VOTING_MONTH = '{_month}' " +
								 "GROUP BY VH.CANDIDATE_ID, E.FULL_NAME " +
								 "ORDER BY COUNT(VH.CANDIDATE_ID) DESC, E.FULL_NAME ASC) " +
								 "WHERE ROWNUM <= 1 ";

			_employeeID = Int32.Parse(_dataLayer.ReturnQuery(employeeQuery));

			var employee = _dataLayer.DetailQuery(_employeeID);

			employeeID.Text = employee.ID.ToString();
			employeeName.Text = employee.FullName;
			contactNumber.Text = employee.ContactNumber.ToString();
			salary.Text = employee.Salary.ToString();
			dateOfBirth.Text = (employee.DateOfBirth).ToString("dd MMMM yyyy");
			hireDate.Text = employee.HireDate.ToString("dd MMMM yyyy");
			supervisorID.Text = employee.Supervisor;
			workingMonths.Text = employee.WorkingMonths.ToString();	

			var query = @"SELECT * FROM " +
						@"(SELECT VH.CANDIDATE_ID ""Candidate ID"", E.FULL_NAME ""Candidate Name"", COUNT(CANDIDATE_ID) ""Vote Count"" " +
						@"FROM ""Voting.History"" VH " +
						 "JOIN EMPLOYEES E " +
						 "ON VH.CANDIDATE_ID = E.EMPLOYEE_ID " +
						$"WHERE VOTING_MONTH = '{_month}' " +
						 "GROUP BY VH.CANDIDATE_ID, E.FULL_NAME " +
						 "ORDER BY COUNT(VH.CANDIDATE_ID) DESC, E.FULL_NAME ASC) " +
						 "WHERE ROWNUM <= 3 ";

			_dataLayer.FillGridView(query, gridView);
		}
	}
}