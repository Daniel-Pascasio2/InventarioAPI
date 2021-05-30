using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace InventarioAPI.Controllers
{
    public class DepartamentosController : ApiController
    {
        public class tblDepartamentos
        {

            int id_departamento;
            string departamento;

            public int Id_departamento { get => id_departamento; set => id_departamento = value; }
            public string Departamento { get => departamento; set => departamento = value; }
        }
        [HttpGet]
        [Route("api/Departamentos/")]
        public IHttpActionResult GetMarca()
        {

            List<tblDepartamentos> lst = new List<tblDepartamentos>();

            using (Models.inventario2e db = new Models.inventario2e())
            {
                lst = (from departamentos in db.departamentos

                       select new tblDepartamentos
                       {
                           Id_departamento = departamentos.id_departamento,
                           Departamento = departamentos.departamento

                       }).ToList();
            }
            return Ok(lst);
        }
    }
}