using EmployeeVotingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeVotingSystem.Forms.Simple
{
    public partial class Addresses : System.Web.UI.Page
    {
        private string _addressID;

        private DataLayer _dataLayer;

        protected enum MessageType { Success, Error, Info, Warning };

        protected void Page_Load(object sender, EventArgs e)
        {
            var query = @"SELECT ADDRESS_ID ""Address ID"", ADDRESS ""Address"", STATE ""State"", ZIP ""ZIP""" +
                         "FROM ADDRESSES ORDER BY ADDRESS_ID";

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
            _addressID = gridView.SelectedRow.Cells[1].Text.ToString();

            addressID.ReadOnly = true;
            addressID.Text = _addressID;
            address.Text = gridView.SelectedRow.Cells[2].Text.ToString();
            state.Text = gridView.SelectedRow.Cells[3].Text.ToString();
            zip.Text = gridView.SelectedRow.Cells[4].Text.ToString();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            gridView.DataBind();
        }

        protected void AddAddress(object sender, EventArgs e)
        {
            var idQuery = "SELECT MAX(ADDRESS_ID) FROM ADDRESSES";

            var addressId = Int32.Parse(_dataLayer.ReturnQuery(idQuery)) + 1;

            string query = $"INSERT INTO " +
                           $"ADDRESSES (ADDRESS_ID, ADDRESS, STATE, ZIP) " +
                           $"VALUES ({addressId},'{address.Text}', '{state.Text}', {zip.Text})";

            var result = _dataLayer.QueryExecution(query, "Job");

            addressID.Text = "";
            address.Text = "";
            state.Text = "";
            zip.Text = "";
        }

        protected void NotifyFunction(object sender, EventArgs e)
        {
            ShowMessage("Notification Type", MessageType.Success);
        }

        protected void UpdateAddress(object sender, EventArgs e)
        {
            string query = $"UPDATE ADDRESSES " +
                           $"SET ADDRESS = '{address.Text}', " +
                           $"STATE = '{state.Text}', " +
                           $"ZIP = {zip.Text} " +
                           $"WHERE ADDRESS_ID = {addressID.Text} ";

			var result = _dataLayer.QueryExecution(query, "Job");

            addressID.Text = "";
            address.Text = "";
            state.Text = "";
            zip.Text = "";
        }

        protected void DeleteAddress(object sender, EventArgs e)
        {
            string query = $"DELETE FROM ADDRESSES WHERE ADDRESS_ID = {addressID.Text}";

			var result = _dataLayer.QueryExecution(query, "Job");

            addressID.Text = "";
            address.Text = "";
            state.Text = "";
            zip.Text = "";
        }

        protected void ClearTextFields(object sender, EventArgs e)
        {
			addressID.Text = "";
            address.Text = "";
            state.Text = "";
            zip.Text = "";
        }
    }
}