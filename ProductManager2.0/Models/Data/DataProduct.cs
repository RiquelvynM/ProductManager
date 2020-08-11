using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ProductManager2._0.Models.Data
{
    public class DataProduct
    {
        //Coneccion
        private SqlConnection connection = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["Conecction"].ConnectionString);


        //Listado de productos
        public object _ListingProducts()
        {
            try
            {
                DataSet table = new DataSet();


                SqlCommand sqlCommand = new SqlCommand("Product_Listing", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(table);
                connection.Close();

                return table;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }



        }

        //Recibe los datos para crear producto y los envia a la base de datos
        public object _CreateProduct(string name, double price, string detail, int categoryId)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("[Create_Product]", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@price", price);
                sqlCommand.Parameters.AddWithValue("@detail", detail);
                sqlCommand.Parameters.AddWithValue("@categoryId", categoryId);
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

        //Recibe los mismos datos y los actualiza en la base de datos

        public object _EditProduct(int id, string name, double price, string detail, int categoryId)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Update_Product", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@price", price);
                sqlCommand.Parameters.AddWithValue("@detail", detail);
                sqlCommand.Parameters.AddWithValue("@categoryId", categoryId);
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

        //Recibe id y busca en la base de datos, devuelve tabla 
        public object _Search_ProductById(int id)
        {
            try
            {
                DataTable dataTable = new DataTable();

                SqlCommand sqlCommand = new SqlCommand("Search_ProductById", connection);
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

        //recibe id y elimina tabla con id igual
        public object _DeleteProduct(int id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Delete_Product", connection);
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

        //Busca por caracter que se digite, al coincidir lo devuelve en un table
        public object _Search_ByNameProduct(string search)
        {
            try
            {
                DataSet dataSet = new DataSet();


                SqlCommand sqlCommand = new SqlCommand("Search_ByNameProduct", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Name", search);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataSet);

                return dataSet;

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }



        }
    }
}