using Newtonsoft.Json;
using ProductManager2._0.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace ProductManager2._0.Controllers
{
    public class ProductController : Controller
    {
        //coneccion a la db
        DataProduct database = new DataProduct();


        //Retorna listado de productos
        public ActionResult ListingProducts()
        {
            return View();
        }

        //De este metodo vienen los productos solicitados con ajax al momento de cargar la pagina anterior
        public object GetProducts()
        {
            try
            {
                var datos = database._ListingProducts();
                string json = JsonConvert.SerializeObject(datos, Formatting.Indented);

                return json;

            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }

        }


        //es llamado de forma asincrona por la vista de listingProducts al momento de buscar 
        public string Search_ByNameProduct(string search)
        {
            try
            {
                var datos = database._Search_ByNameProduct(search);

                string json = JsonConvert.SerializeObject(datos, Formatting.Indented);

                return json;
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }


        //Retorna formulario con datos del producto seleccionado

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            try
            {

                return View(database._Search_ProductById(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        //recibe datos del formulario y los actualiza en la db
        [HttpPost]
        public object EditProduct(int id, string name, int price, string detail, int categoryId)
        {
            
            try
            {
                 int result = Convert.ToInt32(database._EditProduct(id, name, price, detail, categoryId));

                return result;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();

                throw;
            }
            

        }
       
        //Metodo que es llamado mediante ajax y elimina registro seleccionado
        public object DeleteProduct(int id)
        {

            try
            {
                var result = database._DeleteProduct(id);

                return result;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }
        }


        //Retorna formulario para crear producto
        public ActionResult CreateProduct()
        {
            return View();
        }


        //recibe los datos del formulario anterior y los envia a la db
        [HttpPost]
        public object CreateProduct(string name, double price, string detail, int idCategory)
        {
            try
            {
                var result = database._CreateProduct(name.Trim(), price, detail.Trim(), idCategory);

                return result;


            }
            catch (Exception ex)
            {
                return ex.Message.ToString();

                throw;
            }

        }

        //Es llamado mediante Ajax para rellenar Select en la vista de crear producto
        public object ListingCategories()
        {
            try
            {

                DataCategory category = new DataCategory();

                var datos = category._ListingCategory();

                string json = JsonConvert.SerializeObject(datos, Formatting.Indented);

                return json;


            }
            catch (Exception)
            {

                throw;
            }


        }



        }
    }