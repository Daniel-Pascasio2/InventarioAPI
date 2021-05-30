using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace InventarioAPI.Controllers
{
    public class ReporteLoteController : ApiController
    {
       
        private class data1 {

            public int id_equipo { get; set; }
            public Nullable<int> id_programacion { get; set; }
            public Nullable<int> cant_equipos { get; set; }
            public Nullable<int> id_marca { get; set; }
            public string marca { get; set; }
            public Nullable<int> id_modelo { get; set; }
            public string modelo { get; set; }
            public string codigo { get; set; }
            public Nullable<decimal> precio_eq { get; set; }
            public Nullable<System.DateTime> fecha_cad { get; set; }
            public string tipo_equipo { get; set; }
            public Nullable<int> estado { get; set; }
            public Nullable<int> id_usuario { get; set; }
            public Nullable<System.DateTime> fecha_modificacion { get; set; }
        }
        private class data2
        {
            public int id_equipo { get; set; }
            public Nullable<int> id_programacion { get; set; }
            public Nullable<int> cant_equipos { get; set; }
            public Nullable<int> id_marca { get; set; }
            public string marca { get; set; }
            public Nullable<int> id_modelo { get; set; }
            public string modelo { get; set; }
            public string codigo { get; set; }
            public Nullable<decimal> precio_eq { get; set; }
            public Nullable<System.DateTime> fecha_cad { get; set; }
            public string tipo_equipo { get; set; }
            public Nullable<int> estado { get; set; }
            public Nullable<int> id_usuario { get; set; }
            public Nullable<System.DateTime> fecha_modificacion { get; set; }
        }

        //Quiero probar si traigo un procedimiento almacenado
        [HttpGet]
        [Route("api/ReporteLote/")]
        public IHttpActionResult GetLote()
        {
            
            List<data1> lst = new List<data1>();

            using (Models.inventario2e db = new Models.inventario2e())
            {
                
                lst = db.Database.SqlQuery<data1>("sp_mostrar_equipos").ToList();
            }
            return Ok(lst);
        }


        //Procedimiento almacenado con variables
        [HttpGet]
        [Route("api/ReporteLote/{tipoeq}")]
        public IHttpActionResult GetLote(string tipoeq)
        {
            
            List<data2> lst = new List<data2>();

            using (Models.inventario2e db = new Models.inventario2e())
            {
                //Mando parametro
                lst = db.Database.SqlQuery<data2>("spbuscar_equipo_tipo @var", new SqlParameter("@var", tipoeq)).ToList();
            }
            return Ok(lst);
        }
    }
}