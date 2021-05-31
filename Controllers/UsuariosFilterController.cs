using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace InventarioAPI.Controllers
{
    public class UsuariosFilterController : ApiController
    {
        public class tblUsuarios
        {
            string correo;
            string clave;

            public string Correo { get => correo; set => correo = value; }
            public string Clave { get => clave; set => clave = value; }
        }
        [HttpGet]
        [Route("api/Usuarios/Filter/{user}/{pass}")]
        public IHttpActionResult GetUsuarios(string user,string pass)
        {

            List<tblUsuarios> j = new List<tblUsuarios>();

            using (Models.inventario2e db = new Models.inventario2e())
            {
                j = (from usuarios in db.usuarios where usuarios.correo==user && usuarios.clave==pass

                     select new tblUsuarios
                     {
                         Correo = usuarios.correo,
                         Clave = usuarios.clave

                     }).ToList();
            }

            if(j.Count > 1){
                j.Clear();
                j.Add(new tblUsuarios { Correo="HOLA",Clave="ADIOS"});
            }

            return Ok(j);
        }
    }
}