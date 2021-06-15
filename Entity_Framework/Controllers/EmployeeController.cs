using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using SQliteFromScratch;

namespace SqliteFromScratch.Controllers
{
	// MVC is handling the route for you 
	[Route("api/[Controller]")]
	public class EmployeeController : Controller
	{
		// api/controller
		[HttpGet]
		public List<Employee> GetData()
		{
			// will contain the query result
			List<Employee> employees = new List<Employee>();

			// GetFullPath will return a string to complete the absolute path
			string dataSource = "Data Source=" + Path.GetFullPath("chinook.db");
			// using will make sure that the resource is cleaned up from memory after it exits
			// conn initializes the connection to the .db file
			using (SqliteConnection conn = new SqliteConnection(dataSource))
			{
				conn.Open();
				// sql is the string that will be run as an sql command
				string sql = $"select * from employees where HireDate < '2003-01-01';";
				// command combines the connection and the command string and creates the query
				using (SqliteCommand command = new SqliteCommand(sql, conn))
				{

					// reader allows you to read each value that comes back and do something to it
					using (SqliteDataReader reader = command.ExecuteReader())
					{
						// read returns true while there are more rows to advance to, then false when done
						while (reader.Read())
						{
							// map data to model
							Employee newEmployee = new Employee()
							{
								Id = reader.GetInt32(0),
								Firstname = reader.GetString(1),
								LastName = reader.GetString(2),
								Title = reader.GetString(3),
								ReportsTo = reader.IsDBNull(4) ? null : reader.GetInt32(4),
								BirthDate = reader.GetDateTime(5),
								HireDate = reader.GetDateTime(6),
								Address = reader.GetString(7),
								City = reader.GetString(8),
								State = reader.GetString(9),
								Country = reader.GetString(10),
								PostalCode = reader.GetString(11),
								Phone = reader.GetString(12),
								Fax = reader.GetString(13),
								Email = reader.GetString(14),
							};

							// add each one to the list
							employees.Add(newEmployee);
						}
					}
				}
				conn.Close();
			}

			return employees;
		}
	}
}
