using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ProductManager2._0.Models.Data
{
    public class DataCategory
    {
        //Cadena de conecction
        private SqlConnection connection = new SqlConnection(
          WebConfigurationManager.ConnectionStrings["Conecction"].ConnectionString);


        //Este metodo busca en la db todas las categorias
        public object _ListingCategory()
        {
            try
            {
                DataTable dataTable = new DataTable();

                SqlCommand sqlCommand = new SqlCommand("Categories_Listing", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }
        }

        //Este metodo busca por caracteres del nombre de todos los registros en la tabla categoria
        public object _SearchByNameCategory(string name)
        {
            try
            {

                DataTable dataTable = new DataTable();

                SqlCommand sqlCommand = new SqlCommand("Search_ByNameCategory", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@name", name);
                connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }
        }
        
        //Recibe datos para crear categoria
        public object _CreateCategory(string name, string details)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Create_Category", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@details", details);
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


        public object _EditCategory(int id, string name, string details)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Update_Category", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@details", details);
                connection.Open();
                var result = sqlCommand.ExecuteNonQuery();
                connection.Close();

                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Recibe id y busca en la db coincidencias
        public object _SearchCategoryById(int id)
        {
            try
            {
                DataTable dataTable = new DataTable();

                SqlCommand sqlCommand = new SqlCommand("Search_CategoryById", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@id", id);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }

        }

        //mediante el id elimina registro igual en la db
        public object _DeleteCategory(int id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Delete_Category", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@id", id);
                connection.Open();
                var result = sqlCommand.ExecuteNonQuery();
                connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString(); ;
                throw;
            }


        }



    }
}