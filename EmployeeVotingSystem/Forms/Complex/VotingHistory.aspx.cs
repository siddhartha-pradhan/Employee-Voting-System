using EmployeeVotingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeVotingSystem.Forms.Complex
{
	public partial class VotingHistory : System.Web.UI.Page
	{
		public string employeeID { get; set; }

		private DataLayer _dataLayer = new DataLayer();

		protected void Page_Load(object sender, EventArgs e)
		{
			var query = @"SELECT E.EMPLOYEE_ID ""Employee ID"", E.FULL_NAME ""Employee Name"", E.CONTACT_NUMBER ""Contact Number"", " +
						@"R.ROLE_TYPE ""Role"", D.DEPARTMENT_NAME ""Department"", EMP.FULL_NAME ""Supervisor"" " +
						 "FROM EMPLOYEES E " +
						 "JOIN ROLES R " +
						 "ON E.ROLE_ID = R.ROLE_ID " +
						 "JOIN DEPARTMENTS D " +
						 "ON E.DEPARTMENT_ID = D.DEPARTMENT_ID " +
						 "LEFT JOIN EMPLOYEES EMP " +
						 "ON E.SUPERVISOR_ID = EMP.EMPLOYEE_ID " +
						 "ORDER BY E.EMPLOYEE_ID";

			_dataLayer.FillGridView(query, gridView);
		}

		protected void SelectVotingDetail(object sender, EventArgs e)
		{
			employeeID = gridView.SelectedRow.Cells[1].Text.ToString();

			Server.Transfer("VotingDetail.aspx");
		}

		protected void OnPaging(object sender, GridViewPageEventArgs e)
		{
			gridView.PageIndex = e.NewPageIndex;
			gridView.DataBind();
		}
	}
}