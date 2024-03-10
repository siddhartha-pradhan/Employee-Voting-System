using System;
using System.Data;
using System.Configuration;
using System.Data.OracleClient;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Messaging;
using System.Web.UI.DataVisualization.Charting;
using System.Collections.Generic;
using System.Collections;

namespace EmployeeVotingSystem.Data
{
    public class DataLayer
    {
        private readonly OracleConnection _connection;
        private readonly OracleCommand _command;
        private readonly OracleDataAdapter _adapter;

        private DataTable _dataTable;
        private string _connectionString;
        private string _message;

        public DataLayer()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _connection = new OracleConnection(_connectionString);
            _command = new OracleCommand();
            _adapter = new OracleDataAdapter();
            _dataTable = new DataTable();
        }

        public bool Connect()
        {
            try
            {
                _connection.Open();
                _message = "Connection Successfully Established";
                return true;
            }
            catch (Exception ex)
            {
                _message = $"Error encountered while establishing connection with Oracle Database: {ex.Message}";
                return false;
                throw ex;
            }
        }

        public bool Disonnect()
        {
            try
            {
                _connection.Close();
                _message = "Connection Successfully Closed";
                return true;
            }
            catch (Exception ex)
            {
                _message = $"Error encountered while closing connection with Oracle Database: {ex.Message}";
                return false;
                throw ex;
            }
        }

        public string QueryExecution(string query, string title)
        {
            var result = "";

            try
            {
                _command.CommandText = query;
                _command.Connection = _connection;

                Connect();
                _command.ExecuteNonQuery();

                if (query.ToLower().Contains("insert"))
                {
                    result = _message = $"{title} Successfully Inserted.";
                }
                if (query.ToLower().Contains("delete"))
                {
                    result = _message = $"{title} Successfully Deleted.";
                }
                if (query.ToLower().Contains("update"))
                {
                    result = _message = $"{title} Successfully Updated.";
                }
            }
            catch (Exception ex)
            {
                if(ex.ToString().ToLower().Contains("unique constraint"))
                {
                    result = _message = $"Unable to add record, record violation found.";
                }
                else
                {
                    result = _message = $"{ex.Message}";
                }

            }
            finally
            {
                Disonnect();
            }

            return result;
        }

        public string ReturnQuery(string query)
        {
            using(var connection = new OracleConnection(_connectionString))
            {
                var command = new OracleCommand(query, connection);
                
                connection.Open();

                var reader = command.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        return reader[0].ToString();
                    }

                    return null;
                }
                catch (OracleException exc)
                {
					Console.WriteLine(exc.StackTrace);
					Console.WriteLine(exc.Message);
					throw;
                }
				finally
				{
					reader.Close();
				}
			}
        }

        public Employee DetailQuery(int id)
        {
            var query = "SELECT E.EMPLOYEE_ID, E.FULL_NAME, E.CONTACT_NUMBER, E.SALARY, E.DATE_OF_BIRTH, E.HIRE_DATE, EMP.FULL_NAME, " +
                        "FLOOR(MONTHS_BETWEEN(SYSDATE, E.HIRE_DATE)) " +
                        "FROM EMPLOYEES E " +
                        "LEFT JOIN EMPLOYEES EMP " +
                        "ON E.SUPERVISOR_ID = EMP.EMPLOYEE_ID " +
                       $"WHERE E.EMPLOYEE_ID = {id}";

			using (var connection = new OracleConnection(_connectionString))
			{
				connection.Open();
				
                var command = new OracleCommand(query, connection);

                var employee = new Employee();

                try
                {
					using (var reader = command.ExecuteReader())
					{
						if (reader.HasRows)
						{
							reader.Read();

                            employee.ID = reader.GetInt32(0);
                            employee.FullName = reader.GetString(1);
                            employee.ContactNumber = reader.GetDecimal(2);
                            employee.Salary = reader.GetInt32(3);
                            employee.DateOfBirth = reader.GetDateTime(4);
                            employee.HireDate = reader.GetDateTime(5);
                            employee.Supervisor = reader.GetValue(6) == DBNull.Value ? String.Empty : reader.GetString(6);
                            employee.WorkingMonths = reader.GetDecimal(7);
                        }

						return employee;
					}
				}
                catch (OracleException exc)
				{
					Console.WriteLine(exc.StackTrace);
					Console.WriteLine(exc.Message);
                    throw;
                }
			}
		}

        public List<EmployeeCount> CountQuery()
        {
            var employeeCount = new List<EmployeeCount>();

            var query = "SELECT D.DEPARTMENT_NAME, COUNT(*) AS TOTAL_EMPLOYEES " + 
                        "FROM EMPLOYEES E " +
                        "JOIN DEPARTMENTS D " +
                        "ON E.DEPARTMENT_ID = D.DEPARTMENT_ID " +
                        "GROUP BY E.DEPARTMENT_ID, D.DEPARTMENT_NAME " +
                        "ORDER BY D.DEPARTMENT_NAME";

            using(var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                var command = new OracleCommand(query, connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    employeeCount.Add(new EmployeeCount()
                    {
                        DepartmentName = reader["DEPARTMENT_NAME"].ToString(),
                        Count = Int32.Parse(reader["TOTAL_EMPLOYEES"].ToString())
                    });
                }

                return employeeCount;
            }
        }

		public List<VoteCount> VoteCount()
		{
			var voteCount = new List<VoteCount>();

            var query = @"SELECT E.FULL_NAME, COUNT(CANDIDATE_ID) AS TOTAL_VOTES FROM ""Voting.History"" VH " +
                         "JOIN EMPLOYEES E ON VH.CANDIDATE_ID = E.EMPLOYEE_ID " +
                         "GROUP BY VH.CANDIDATE_ID, E.FULL_NAME ORDER BY VH.CANDIDATE_ID ";

			using (var connection = new OracleConnection(_connectionString))
			{
				connection.Open();

				var command = new OracleCommand(query, connection);

				var reader = command.ExecuteReader();

				while (reader.Read())
				{
					voteCount.Add(new VoteCount()
					{
						EmployeeName = reader["FULL_NAME"].ToString(),
						Count = Int32.Parse(reader["TOTAL_VOTES"].ToString())
					});
				}

				return voteCount;
			}
		}

		public string FillGridView(string query, GridView dataGrid)
        {
            var result = "";

            _dataTable = new DataTable();

            try
            {
                _command.Connection = _connection;
                _command.CommandText = query;

                Connect();

                _adapter.SelectCommand = _command;
                _adapter.Fill(_dataTable);

                dataGrid.DataSource = _dataTable;
                dataGrid.DataBind();

                result = "Successfully executed.";
            }
            catch (Exception ex)
            {
                result = $"Executed failed, {ex.Message}.";
                throw ex;
            }
            finally
            {
                Disonnect();
                _dataTable = null;
            }

            return result;
        }

        public string ReturnEmployees(string query)
        {
            var employeeCount = new List<int>();

            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                var command = new OracleCommand(query, connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    employeeCount.Add(reader.GetInt32(0));
                }

                return string.Join(", ", employeeCount);
            }
        }

        public DataTable FillDropDown(string query, DropDownList dropDown, string title, string value)
		{
			_dataTable = new DataTable();

			try
			{
				_command.Connection = _connection;
				_command.CommandText = query;

				Connect();

				_adapter.SelectCommand = _command;
				_adapter.Fill(_dataTable);

				dropDown.DataSource = _dataTable;
				dropDown.DataBind();
				dropDown.DataTextField = title;
				dropDown.DataValueField = value;
				dropDown.DataBind();

				return _dataTable;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				Disonnect();
			}
		}
	}

    public class Employee
    {
		public int ID { get; set; }

		public string FullName { get; set; }

        public decimal ContactNumber { get; set; }

        public int Salary { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime HireDate { get; set; }

        public decimal WorkingMonths { get; set; }

        public string Supervisor { get; set; }
    }

    public class EmployeeCount
    {
        public string DepartmentName { get; set; }

        public int Count { get; set; }
    }

	public class VoteCount
	{
		public string EmployeeName { get; set; }

		public int Count { get; set; }
	}
}