using InventarioAPI.Diseño;
using InventarioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace InventarioAPI.Controllers
{
    public class EquiposController : ApiController
    {

        public class tblMarca {

            int id_marca ;
            string marca ;

            public int Id_marca { get => id_marca; set => id_marca = value; } 
            public string Marca { get => marca; set => marca = value; } 
        }
        public class tblModelo
        {

            int id_modelo;
            string modelo;

            public int Id_modelo { get => id_modelo; set => id_modelo = value; }
            public string Modelo { get => modelo; set => modelo = value; }
        }


        [HttpGet]
        [Route("api/Equipos/Marca")]
        public IHttpActionResult GetMarca()
        {

            List<tblMarca> lst = new List<tblMarca>();

            using (Models.inventario2e db = new Models.inventario2e())
            {
                lst = (from marcas in db.marcas

                       select new tblMarca
                       {
                           Id_marca = marcas.id_marca,
                           Marca = marcas.marca

                       }).ToList();
            }
            return Ok(lst);
        }
        [HttpGet]
        [Route("api/Equipos/Modelo/{mar}")]
        public IHttpActionResult GetModelo(string mar)
        {

            List<tblModelo> lst = new List<tblModelo>();

            using (Models.inventario2e db = new Models.inventario2e())
            {
                lst = (from marcas in db.marcas
                       join modelos in db.modelos on marcas.id_marca equals modelos.id_marca

                       where marcas.marca == mar

                       select new tblModelo
                       {
                           Id_modelo = modelos.id_modelo,
                           Modelo = modelos.modelo

                       }).ToList();
            }
            return Ok(lst);
        }

    }
}