using EmployeeVotingSystem.Data;
using EmployeeVotingSystem.Forms.Simple;
using Syncfusion.EJ2.ImageEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeVotingSystem.Forms.Complex
{
	public partial class VotingRecord : System.Web.UI.Page
	{
		public string month { get; set; }

		private DataLayer _dataLayer = new DataLayer();

		protected void Page_Load(object sender, EventArgs e)
		{
			//var query = @"SELECT * FROM " +
			//			@"(SELECT VH.VOTING_YEAR ""Voting Year"", VH.VOTING_MONTH ""Voting Month"", " +
			//			@"VH.CANDIDATE_ID ""Candidate ID"", E.EMPLOYEE_NAME ""Candidate Name"" " +
			//			@"FROM ""Voting.History"" VH " +
			//			"JOIN EMPLOYEES E " +
			//			"ON VH.CANDIDATE_ID = E.EMPLOYEE_ID " +
			//			"GROUP BY VH.CANDIDATE_ID, E.EMPLOYEE_NAME, VH.VOTING_YEAR, VH.VOTING_MONTH " +
			//			"ORDER BY COUNT(VH.CANDIDATE_ID) DESC) " +
			//			"WHERE ROWNUM == 1";

			var query = @"SELECT UNIQUE(VOTING_MONTH) ""Month"", COUNT(VOTER_ID) ""Total Votes"" FROM ""Voting.History"" " +
						 "GROUP BY VOTING_MONTH " +
						 "ORDER BY DECODE(VOTING_MONTH, 'January', 1, 'February', 2, 'March', 3, 'April', 4, 'May', 5, " + 
						 "'June', 6, 'July', 7, 'August', 8, 'September', 9, 'October', 10, 'November', 11, 'December', 12)";

			_dataLayer.FillGridView(query, gridView);
		}

		protected void SelectMonthRecord(object sender, EventArgs e)
		{
			month = gridView.SelectedRow.Cells[1].Text.ToString();

			Server.Transfer("EmployeeMonth.aspx");
		}
	}
}