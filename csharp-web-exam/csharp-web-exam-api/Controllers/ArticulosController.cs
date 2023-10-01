using csharp_api.Services;
using csharp_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_api.Controllers
{
    [Route("api/articulos")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticulosService articulosService;

        public ArticulosController(IArticulosService articulosService)
        {
            this.articulosService = articulosService;
        }

        // GET api/articulos
        [HttpGet]
        public ActionResult<IEnumerable<Articulos>> GetAll()
        { 
            return articulosService.GetAll();
        }

        // GET api/articulos/'id'
        [HttpGet("{art}")]
        public ActionResult<Articulos> GetById(string art)
        {
            return articulosService.GetById(art);
        }

        // POST api/articulos
        [HttpPost]
        public ActionResult<Articulos> Create([FromBody] Articulos articulo)
        {
            return articulosService.Create(articulo);
        }

        // PUT api/articulos
        [HttpPut]
        public ActionResult<Articulos> Edit([FromBody] Articulos articulo)
        {
            return articulosService.Edit(articulo);
        }

        // DELETE api/articulos/'id'
        [HttpDelete("{art}")]
        public void Borrar(string art)
        {
            articulosService.Delete(art);
        }


    }
}
