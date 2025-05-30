using BsssCommon;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BsssDLogic
{

        public class DBDataService : IBsssDataService
        {
            static string connectionString =
                "Data Source=DESKTOP-6NMMH13\\SQLEXPRESS;Initial Catalog= BSSS;Integrated Security=True;TrustServerCertificate=True;";

            static SqlConnection sqlConnection;

            public DBDataService()
            {
                // used in GetAllBookings
                sqlConnection = new SqlConnection(connectionString);
            }

            public void CreateBooking(Booking booking)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var insertStatement = @"INSERT INTO BookingRecords (Name, Contact, DateTime, Service)
                                        VALUES (@Name, @Contact, @DateTime, @Service)";
                    using (SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Name", booking.Name);
                        insertCommand.Parameters.AddWithValue("@Contact", booking.Contact);
                        insertCommand.Parameters.AddWithValue("@DateTime", booking.DateTime);
                        insertCommand.Parameters.AddWithValue("@Service", booking.Service);

                        connection.Open();
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }

            public List<Booking> GetAllBookings()
            {
                var bookings = new List<Booking>();

                using (SqlCommand selectCommand = new SqlCommand("SELECT Name, Contact, DateTime, Service FROM BookingRecords", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookings.Add(new Booking
                            {
                                Name = reader["Name"].ToString(),
                                Contact = reader["Contact"].ToString(),
                                DateTime = Convert.ToDateTime(reader["DateTime"]),
                                Service = reader["Service"].ToString()
                            });
                        }
                    }
                    sqlConnection.Close();
                }

                return bookings;
            }

            public bool DeleteBooking(Booking booking)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var deleteStatement = @"DELETE FROM BookingRecords
                                        WHERE Name = @Name 
                                          AND Contact = @Contact 
                                          AND DateTime = @DateTime 
                                          AND Service = @Service";

                    using (SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@Name", booking.Name);
                        deleteCommand.Parameters.AddWithValue("@Contact", booking.Contact);
                        deleteCommand.Parameters.AddWithValue("@DateTime", booking.DateTime);
                        deleteCommand.Parameters.AddWithValue("@Service", booking.Service);

                        connection.Open();
                        int rowsAffected = deleteCommand.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }

            public void UpdateBooking(Booking booking)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var updateStatement = @"UPDATE BookingRecords
                                        SET DateTime = @DateTime, Service = @Service
                                        WHERE Name = @Name AND Contact = @Contact";

                    using (SqlCommand updateCommand = new SqlCommand(updateStatement, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@DateTime", booking.DateTime);
                        updateCommand.Parameters.AddWithValue("@Service", booking.Service);
                        updateCommand.Parameters.AddWithValue("@Name", booking.Name);
                        updateCommand.Parameters.AddWithValue("@Contact", booking.Contact);

                        connection.Open();
                        updateCommand.ExecuteNonQuery();
                    }
                }
            }
        }
    }

    
