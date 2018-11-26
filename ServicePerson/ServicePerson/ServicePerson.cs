using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace ServicePerson
{

    public class ServicePerson : IServicePerson
    {
        // Authentication variable that provided by ServicePerson database
        // If Auth1 variable will not match with ServicePerson database, service are not consumed.
        // Client should use the credintial that service provider give them;
        public Person GetPerson(int Id, String Auth1)
        {
            Person person = new Person();
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spGetPerson", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameterId = new SqlParameter();
                    parameterId.ParameterName = "@Id";
                    parameterId.Value = Id;
                    cmd.Parameters.Add(parameterId);

                    SqlParameter Auth = new SqlParameter();
                    Auth.ParameterName = "@Auth";
                    Auth.Value = Auth1;
                    cmd.Parameters.Add(Auth);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        person.Id = Convert.ToInt32(reader["Id"]);
                        person.Name = reader["Name"].ToString();
                        person.Gender = reader["Gender"].ToString();
                        person.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    }
                }
                return person;
            }
            catch (System.Data.SqlTypes.SqlTypeException exception)
            {
                // Output expected SqlTypeExceptions.
                return null;
            }
            catch (SqlException exception)
            {
                // Output unexpected SqlExceptions.
                return null;
            }
            catch (Exception exception)
            {
                return null;

            }
        }

        public void SavePerson(Person person, String Auth1)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spSavePerson", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameterId = new SqlParameter
                    {
                        ParameterName = "@Id",
                        Value = person.Id
                    };
                    cmd.Parameters.Add(parameterId);

                    SqlParameter parameterName = new SqlParameter
                    {
                        ParameterName = "@Name",
                        Value = person.Name
                    };
                    cmd.Parameters.Add(parameterName);

                    SqlParameter parameterGender = new SqlParameter
                    {
                        ParameterName = "@Gender",
                        Value = person.Gender
                    };
                    cmd.Parameters.Add(parameterGender);

                    SqlParameter parameterDOB = new SqlParameter
                    {
                        ParameterName = "@DateOfBirth",
                        Value = person.DateOfBirth
                    };
                    cmd.Parameters.Add(parameterDOB);

                    SqlParameter Auth = new SqlParameter();
                    Auth.ParameterName = "@Auth";
                    Auth.Value = Auth1;
                    cmd.Parameters.Add(Auth);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (System.Data.SqlTypes.SqlTypeException exception)
            {
                // Output expected SqlTypeExceptions.
            }
            catch (SqlException exception)
            {
                // Output unexpected SqlExceptions.
            }
            catch (Exception exception)
            {
                // Output unexpected Exceptions.
            }
        }
    }
}

