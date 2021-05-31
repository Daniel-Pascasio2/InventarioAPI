using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace InventarioAPI.Controllers
{
    public class CargosController : ApiController
    {
        public class tblCargos
        {

            int id_cargo;
            string cargo;

            public int Id_cargo { get => id_cargo; set => id_cargo = value; }
            public string Cargo { get => cargo; set => cargo = value; }
        }
        [HttpGet]
        [Route("api/Cargos/")]
        public IHttpActionResult GetCargo()
        {

            List<tblCargos> i = new List<tblCargos>();

            using (Models.inventario2e db = new Models.inventario2e())
            {
                i = (from cargos in db.cargos

                     select new tblCargos
                     {
                         Id_cargo = cargos.id_cargo,
                         Cargo = cargos.cargo

                     }).ToList();
            }
            return Ok(i);
        }
    }
}