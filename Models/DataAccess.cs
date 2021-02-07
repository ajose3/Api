using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public class DataAccess
    {
        //Connection to the Database
        private static string connection = "Data Source=socem1.uopnet.plymouth.ac.uk;Database=COMP2001_AJose;User Id=AJose; Password=VelB593*";

        //Validate user method
        public static bool Validate(User user)
        {
            //Calling stored procedure
            SqlConnection connectionToDB = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("ValidateUser", connectionToDB);
            cmd.CommandType = CommandType.StoredProcedure;

            //Adding values to parameters
            cmd.Parameters.AddWithValue("@Mail_e", user.Email);
            cmd.Parameters.AddWithValue("@password", user.PasswordHash);

            //Connection info
            connectionToDB.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connectionToDB.Close();

            return true;
        }

        //Register user method
        public static void Register(User user, string output)
        {
            //Calling stored procedure
            SqlConnection connectionToDB = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("register", connectionToDB);
            cmd.CommandType = CommandType.StoredProcedure;

            //Adding values to parameters
            cmd.Parameters.AddWithValue("@Name_First", user.FirstName);
            cmd.Parameters.AddWithValue("@Name_Last", user.LastName);
            cmd.Parameters.AddWithValue("@Mail_e", user.Email);
            cmd.Parameters.AddWithValue("@password", user.PasswordHash);

            //Connection info
            connectionToDB.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connectionToDB.Close();
        }

        //Update user method
        public static void Update(User user, int id)
        {
            //Calling stored procedure
            SqlConnection connectionToDB = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("UpdateUser", connectionToDB);
            cmd.CommandType = CommandType.StoredProcedure;

            //Adding values to parameters
            cmd.Parameters.AddWithValue("@ID_User", id);
            cmd.Parameters.AddWithValue("@Name_First", user.FirstName);
            cmd.Parameters.AddWithValue("@Name_Last", user.LastName);
            cmd.Parameters.AddWithValue("@Mail_e", user.Email);
            cmd.Parameters.AddWithValue("@password", user.PasswordHash);

            //Connection info
            connectionToDB.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connectionToDB.Close();
        }

        //Delete user method
        public static void Delete(int id)
        {
            //Calling stored procedure
            SqlConnection connectionToDB = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("DeleteUser", connectionToDB);
            cmd.CommandType = CommandType.StoredProcedure;
            
            //Adding values to parameters
            cmd.Parameters.AddWithValue("@ID_User", id);

            //Connection info
            connectionToDB.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connectionToDB.Close();
        }
    }
}
