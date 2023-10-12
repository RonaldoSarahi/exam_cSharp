using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using csharp_web.Models;

namespace csharp_web.Controllers
{
    public class ArticulosController : Controller
    {
        // GET: Articulo
        public async Task<ActionResult> Index()
        {
            List<Articulos> articulos = new List<Articulos>();
            articulos = (await getArticulos()).ToList();
            return View(articulos);
        }

        public async Task<ActionResult> partialGridView()
        {
            List<Articulos> articulos = new List<Articulos>();
            articulos = (await getArticulos()).ToList();
            return PartialView("_GridView", articulos);
        }


        [HttpGet]
        public async Task<ActionResult> ShowArticulo()
        {
            int artId = string.IsNullOrEmpty(Request.Params["articuloId"]) ? 0 : Convert.ToInt32(Request.Params["articuloId"]);
            return PartialView("UpdateModal", await show(artId));
        }

        private async Task<Articulos> show(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    string url = "http://localhost:5002/api/articulos/" + id;

                    // Realizar la solicitud GET
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Articulos>(await response.Content.ReadAsStringAsync()) : new Articulos();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al realizar la solicitud: " + ex.Message);
                }
                return new Articulos();
            }
        }

        private async Task<IEnumerable<Articulos>> getArticulos()
        {
            List<Articulos> articulos = new List<Articulos>();
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // URL de la solicitud GET
                    string url = "http://localhost:5002/api/articulos";

                    // Realizar la solicitud GET
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<Articulos>>(await response.Content.ReadAsStringAsync()) : new List<Articulos>();
                }
                catch (Exception ex)
                {
                    // Manejar excepciones, como problemas de red
                    Console.WriteLine("Error al realizar la solicitud: " + ex.Message);
                }
                return new List<Articulos>();
            }
        }
    }
}