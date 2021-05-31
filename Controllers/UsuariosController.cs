using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace InventarioAPI.Controllers
{
    public class UsuariosController : ApiController
    {
        public class tblUsuarios
        {

            int id_usuario;
            int id_empleado;
            string correo;
            string clave;
            int tipo;

            public int Id_usuario { get => id_usuario; set => id_usuario = value; }
            public int Id_empleado { get => id_empleado; set => id_empleado = value; }
            public string Correo { get => correo; set => correo = value; }
            public string Clave { get => clave; set => clave = value; }
            public int Tipo { get => tipo; set => tipo = value; }
        }
        [HttpGet]
        [Route("api/Usuarios/")]
        public IHttpActionResult GetUsuarios()
        {

            List<tblUsuarios> j = new List<tblUsuarios>();

            using (Models.inventario2e db = new Models.inventario2e())
            {
                j = (from usuarios in db.usuarios

                     select new tblUsuarios
                     {
                         Id_usuario = usuarios.id_usuario,
                         Correo = usuarios.correo,
                         Clave = usuarios.clave,
                         Tipo = (int)usuarios.tipo

                     }).ToList();
            }
            return Ok(j);
        }
    }
}