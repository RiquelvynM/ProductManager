using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using ProductManager2._0.Models.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManager2._0.Controllers
{
    public class AccessController : Controller
    {
        //Acceso a la base de datos 
        DataUser database = new DataUser();


        //Retorna vista home
        public ActionResult Home()
        {
            return View();
        }


        //Desde la vista Home hace un llamado mediante Ajax y trae los datos de este metodo
        public string GetProducts()
        {
            try
            {

                //Se instancia de manera individual para que traiga los productos y los convierta a formato JSON

                DataProduct data = new DataProduct();

                var datos = data._ListingProducts();

                string json = JsonConvert.SerializeObject(datos, Formatting.Indented);

                return json;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }

        }


        //Este es otro metodo que es llamado de forma asincrona con AJAX, al escribir en el buscador de la vista, busca en la db
        public string Search_ByNameProduct(string search)
        {
            //Por igual busca los datos y los convierte en Json

            DataProduct data = new DataProduct();

            var datos = data._Search_ByNameProduct(search);

            string json = JsonConvert.SerializeObject(datos, Formatting.Indented);

            return json;
        }

        //Solo devuelve una vista con el formulario
        public ActionResult Login()
        {

            return View();

        }


        //Al ingresar los datos en el formulario anterior, mediante ajax envia los datos del formulario y confirma en el mismo metodo Ajax
        [HttpPost]
        public object Login(string email, string password)
        {
            try
            {
                DataTable User = new DataTable();

                User = database._ConfirmUser(email, password);

                if (User.Rows.Count != 0)
                {

                    //Guardo datos en esta variable para luego obtener los datos del usuario registrado
                    Session["idCliente"] = User.Rows[0][0].ToString();
            
                }

                //Retorno resultado de la consulta y lo convierto a Json
                var data = database._ConfirmUser(email, password);

                string json = JsonConvert.SerializeObject(data, Formatting.Indented);


                return json;


            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message.ToString();
                throw;
            }

        }

        //Retorna formulario para crear Usuario
        public ActionResult RegistrerUser()
        {
            return View();
        }

        //Recibe los datos del formulario mediante AJAX y retorna el valor de la consulta, es decir las filas afectadas

        [HttpPost]
        public object RegistrerUser(string email, string password, string name, string lastName, string phone)
        {
            try
            {
                var result = database._RegisterUser(email.Trim(), password.Trim(), name.Trim(), lastName.Trim(), phone.Trim());

                return result;

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }

        }

        //Retorna formulario con el Id del cliente registrado al momento
        [HttpGet]
        public ActionResult EditUser()
        {
            try
            {
                //Aqui se utiliza la variable crada en Login con el mismo nombre
                return View(database._SearchUser(Convert.ToInt32(Session["idCliente"].ToString())));
            }
            catch (Exception )
            {
               
                throw;
            }
            
        }

        //Una vez editado accede con ajax y retorna las filas afectadas

        [HttpPost]
        public object UpdateUser(int id, string email, string password, string name, string lastName, string phone)
        {
            try
            {
                return database._EditUser(id,email,password,name,lastName,phone);
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }


        }




    }
}