using EmployeeVotingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeVotingSystem
{
    public partial class _Default : Page
    {
        private DataLayer _dataLayer;

        protected void Page_Load(object sender, EventArgs e)
        {
            string departmentQuery = "SELECT COUNT(*) FROM DEPARTMENTS";
            string employeeQuery = "SELECT COUNT(*) FROM EMPLOYEES";
            string jobQuery = "SELECT COUNT(*) FROM JOBS";
            string roleQuery = "SELECT COUNT(*) FROM ROLES";

			_dataLayer = new DataLayer();

			var departmentCount = _dataLayer.ReturnQuery(departmentQuery);
            var employeeCount = _dataLayer.ReturnQuery(employeeQuery);
            var jobCount = _dataLayer.ReturnQuery(jobQuery);
            var roleCount = _dataLayer.ReturnQuery(roleQuery);
		    
            departments.Text = departmentCount.ToString();
            employees.Text = employeeCount.ToString();
            jobs.Text = jobCount.ToString();
            roles.Text = roleCount.ToString();
        }
    }
}