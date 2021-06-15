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
	public class CustomerController : Controller
	{
		// api/controller
		[HttpGet]
		public List<Customer> GetData()
		{
			// will contain the query result
			List<Customer> customers = new List<Customer>();

			// GetFullPath will return a string to complete the absolute path
			string dataSource = "Data Source=" + Path.GetFullPath("chinook.db");
			// using will make sure that the resource is cleaned up from memory after it exits
			// conn initializes the connection to the .db file
			using (SqliteConnection conn = new SqliteConnection(dataSource))
			{
				conn.Open();
				// sql is the string that will be run as an sql command
				string sql = $"select * from customers limit 20;";
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
							Customer newCustomer = new Customer()
							{
								Id = reader.GetInt32(0),
								Firstname = reader.GetString(1),
								LastName = reader.GetString(2),
								Company = reader.IsDBNull(3) ? null : reader.GetString(3),
								Address = reader.GetString(4),
								City = reader.GetString(5),
								State = reader.IsDBNull(6) ? null : reader.GetString(6),
								Country = reader.GetString(7),
								PostalCode = reader.GetString(8),
								Phone = reader.GetString(9),
								Fax = reader.IsDBNull(10) ? null : reader.GetString(10),
								Email = reader.GetString(11),
								SupportRepId = reader.GetInt32(12),
							};

							// add each one to the list
							customers.Add(newCustomer);
						}
					}
				}
				conn.Close();
			}

			return customers;
		}
	}
}
