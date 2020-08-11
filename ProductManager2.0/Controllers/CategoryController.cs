using Newtonsoft.Json;
using ProductManager2._0.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManager2._0.Controllers
{
    public class CategoryController : Controller
    {
        //Coneccion a la bd
        DataCategory database = new DataCategory();


        //Retorna lista de categorias  y a su vez llama de forma asincrona al medtdo Categories para retornar datos en la vista
        public ActionResult ListingCategory()
        {

            return View();
        }

        //metdodo que se comunica con la base de datos y retorna los datos

        [HttpGet]
        public string Categories()
        {
            try
            {
                var datos = database._ListingCategory();
                string json = JsonConvert.SerializeObject(datos, Formatting.Indented);

                return json;

            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }

        }


        //Al momento de escribir en el buscador de la vista, es la encargada de traer los datos de forma asincrona
        public object SearchByNameCategory(string search)
        {
            try
            {
                var datos = database._SearchByNameCategory(search);
                string json = JsonConvert.SerializeObject(datos, Formatting.Indented);

                return json;

            }
            catch (Exception)
            {

                throw;
            }
        }


        //retorna formulario para crear categoria
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }


        //Envia los datos a la db
        [HttpPost]
        public object CreateCategory(string name, string details)
        {
            try
            {
                var result = database._CreateCategory(name.Trim(), details.Trim());

                return result;

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }
        }

        //Retorna formulario con los datos de la categoria selecionada
        [HttpGet]
        public ActionResult EditCategory( int id)
        {
            try
            {
                return View(database._SearchCategoryById(id));
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        //Metodo llamado para enviar los registros nuevos y actualizar el registro
        [HttpPost]
        public object UpdateCategory(int id, string name, string details)
        {
            try
            {
                int result = Convert.ToInt32(database._EditCategory(id, name, details));

                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Es llamado de forma asincrona para eliminar registro en la db
        public object DeleteCategory(int id)
        {
            try
            {
                var result = database._DeleteCategory(id);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }
        }

    }
}