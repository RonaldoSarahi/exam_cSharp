using csharp_api.Data;
using csharp_api.Models;
using csharp_api.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp_api.Services
{
    public class ArticulosService : IArticulosService
    {
        private readonly ExamDbContext _db;

        public ArticulosService(ExamDbContext db)
        {
            _db = db;
        }

        public List<Articulos> GetAll()
        {
            return _db.Articulos.ToList();

            //List<Articulos> art = new List<Articulos>();
            //art.Add(new Articulos { Articulo = "Pr",Descripcion = "Par" });
            //return art;

        }

        public Articulos GetById(string art)
        {
            return _db.Articulos.Find(art);
            /*try
            {
                
            }
         
            //return Util.SetHttpResponse(404, "");
            catch (Exception e)
            {
                
            }*/

        }
        
        
        public Articulos Create(Articulos articulo)
        {
            var dbArticulo = _db.Articulos.Find(articulo.Articulo);

            if (dbArticulo == null)
            {
                Articulos newArticulo = new Articulos();
                newArticulo = articulo;
                _db.Add(newArticulo);
               
            }
            _db.SaveChanges();
            return _db.Articulos.Find(articulo.Articulo);
        }
        public Articulos Edit(Articulos articulo)
        {
            var dbArticulo = _db.Articulos.Find(articulo.Articulo);


            dbArticulo.Descripcion = articulo.Descripcion;

            _db.Update(dbArticulo);

            _db.SaveChanges();
            return _db.Articulos.Find(articulo.Articulo);

        }

        public void Delete(string art)
        {
            var dbArt = _db.Articulos.Find(art);
            _db.Remove(dbArt);
            _db.SaveChanges();
        
        }
      
    }
}
