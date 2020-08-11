using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ProductManager2._0.Models.Data
{
    public class DataUser
    {
        //conecccion
        private SqlConnection connection= new SqlConnection(
            WebConfigurationManager.ConnectionStrings["Conecction"].ConnectionString);


        //recibe correo y contraseña y valida en la db
        public DataTable _ConfirmUser(string email, string password)
        {
            try
            {
                DataTable dataTable = new DataTable();

                SqlCommand sqlCommand = new SqlCommand("Confirm_User", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@password", password);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }

        }

        //Este metodo recibe los datos para crear usuario y guarda en la base de datos
        public object _RegisterUser(string email, string password, string name, string lastName, string phone)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Create_User", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@password", password);
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@lastName", lastName);
                sqlCommand.Parameters.AddWithValue("@phone", phone);
                connection.Open();
                int result = sqlCommand.ExecuteNonQuery();
                connection.Close();

                return result;

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }

        }

        //Este metodo recibe los datos del usuario y los actualiza en la db
        public object _EditUser(int id, string email, string password, string name, string lastName, string phone)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Update_UserAdmin", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@password", password);
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@lastName", lastName);
                sqlCommand.Parameters.AddWithValue("@phone", phone);
                connection.Open();
                var result = sqlCommand.ExecuteNonQuery();
                connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }

        }

        //recibe id y busca parecido en la base de datos, devuelve el resultado en una tabla
        public object _SearchUser(int id)
        {
            try
            {
                DataTable dataTable = new DataTable();

                SqlCommand sqlCommand = new SqlCommand("Search_User", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@id", id);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                connection.Close();
                sqlDataAdapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }


        }
    }
}