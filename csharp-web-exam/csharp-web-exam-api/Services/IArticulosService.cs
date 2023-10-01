using csharp_api.Models;
using System.Collections.Generic;

namespace csharp_api.Services
{
    public interface IArticulosService
    {
        List<Articulos> GetAll();
        Articulos GetById(string art);
        Articulos Create(Articulos articulo); 
        Articulos Edit(Articulos articulo);
        void Delete(string art);
    
    }
}
