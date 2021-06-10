using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace InventarioAPI.Controllers
{
    public class ReporteEquipoController : ApiController
    {
        //Esta clase corresponde al REPORTE DE EQUIPOS
        
        private class data
        {
            public int ID { get; set; }
            public string Tipo { get; set; }
            public string marca { get; set; }
            public string modelo { get; set; }
            public string codigo { get; set; }
            public string encabezado { get; set; }
            public string Ubicacion { get; set; }
            public DateTime Fecha { get; set; }
            public int Estado { get; set; }
        }
        [HttpGet]
        [Route("api/ReporteEquipo/")]
        public IHttpActionResult GetReporteEquipo()
        {

            List<data> lst = new List<data>();

            using (Models.inventario2e db = new Models.inventario2e())
            {

                lst = (from marcar in db.marcas
                       join equipos in db.equipos on marcar.id_marca equals equipos.id_marca
                       join modelos in db.modelos on equipos.id_modelo equals modelos.id_modelo
                       join movimientos in db.movimientos_enquipos on
                       equipos.id_equipo equals movimientos.id_equipo
                       join encabezado in db.encabezado_movimientos on movimientos.id_encabezado equals encabezado.id_encabezado
                       join departamentos in db.departamentos on movimientos.id_departamento equals departamentos.id_departamento

                       select new data
                       {
                           ID = movimientos.id_mov,
                           Tipo = equipos.tipo_equipo,
                           marca = marcar.marca,
                           modelo = modelos.modelo,
                           codigo = equipos.codigo,
                           encabezado = encabezado.encabezado,
                           Ubicacion = departamentos.departamento,
                           Fecha = (DateTime)movimientos.fecha,
                           Estado = (int)equipos.estado
                       }).ToList();
            }
            return Ok(lst);
        }
        
        [HttpGet]
        [Route("api/ReporteEquipo/xtipo/{tipo}")]
        public IHttpActionResult GetReporteEquipoTipo(string tipo)
        {

            List<data> lst = new List<data>();

            using (Models.inventario2e db = new Models.inventario2e())
            {
                try
                {

                    lst = (
                            from marcar in db.marcas join equipos in db.equipos on marcar.id_marca equals equipos.id_marca
                                join modelos in db.modelos on equipos.id_modelo equals modelos.id_modelo join movimientos in db.movimientos_enquipos on
                                equipos.id_equipo equals movimientos.id_equipo join encabezado in db.encabezado_movimientos on movimientos.id_encabezado equals encabezado.id_encabezado
                                join departamentos in db.departamentos on movimientos.id_departamento equals departamentos.id_departamento

                            where equipos.tipo_equipo==tipo
                            select new data
                            {
                                ID = movimientos.id_mov,
                                Tipo = equipos.tipo_equipo,
                                marca = marcar.marca,
                                modelo = modelos.modelo,
                                codigo = equipos.codigo,
                                encabezado = encabezado.encabezado,
                                Ubicacion = departamentos.departamento,
                                Fecha = (DateTime)movimientos.fecha,
                                Estado = (int)equipos.estado

                            }).ToList();

                }
                catch (Exception e) { Console.WriteLine(e.ToString()) ; }
            }

            return Ok(lst);

        }

        [HttpGet]
        [Route("api/ReporteEquipo/xtipomarca/{tipo}/{idmarca}")]
        public IHttpActionResult GetReporteEquipoTipoMarca(string tipo,int idmarca)
        {

            List<data> lst = new List<data>();

            using (Models.inventario2e db = new Models.inventario2e())
            {
                try
                {

                    lst = (
                            from marcar in db.marcas
                            join equipos in db.equipos on marcar.id_marca equals equipos.id_marca
                            join modelos in db.modelos on equipos.id_modelo equals modelos.id_modelo
                            join movimientos in db.movimientos_enquipos on
                            equipos.id_equipo equals movimientos.id_equipo
                            join encabezado in db.encabezado_movimientos on movimientos.id_encabezado equals encabezado.id_encabezado
                            join departamentos in db.departamentos on movimientos.id_departamento equals departamentos.id_departamento

                            where equipos.tipo_equipo == tipo && equipos.id_marca==idmarca
                            select new data
                            {
                                ID = movimientos.id_mov,
                                Tipo = equipos.tipo_equipo,
                                marca = marcar.marca,
                                modelo = modelos.modelo,
                                codigo = equipos.codigo,
                                encabezado = encabezado.encabezado,
                                Ubicacion = departamentos.departamento,
                                Fecha = (DateTime)movimientos.fecha,
                                Estado = (int)equipos.estado

                            }).ToList();

                }
                catch (Exception e) { Console.WriteLine(e.ToString()); }
            }

            return Ok(lst);

        }
        
        [HttpGet]
        [Route("api/ReporteEquipo/xdepa/{depa}")]
        public IHttpActionResult GetReporteEquipoDepa(string depa)
        {

            List<data> lst = new List<data>();

            using (Models.inventario2e db = new Models.inventario2e())
            {

                lst = (from marcar in db.marcas
                       join equipos in db.equipos on marcar.id_marca equals equipos.id_marca
                       join modelos in db.modelos on equipos.id_modelo equals modelos.id_modelo
                       join movimientos in db.movimientos_enquipos on
                       equipos.id_equipo equals movimientos.id_equipo
                       join encabezado in db.encabezado_movimientos on movimientos.id_encabezado equals encabezado.id_encabezado
                       join departamentos in db.departamentos on movimientos.id_departamento equals departamentos.id_departamento
                       where departamentos.departamento == depa
                       select new data
                       {
                           ID = movimientos.id_mov,
                           Tipo = equipos.tipo_equipo,
                           marca = marcar.marca,
                           modelo = modelos.modelo,
                           codigo = equipos.codigo,
                           encabezado = encabezado.encabezado,
                           Ubicacion = departamentos.departamento,
                           Fecha = (DateTime)movimientos.fecha,
                           Estado = (int)equipos.estado
                       }).ToList();
            }
            return Ok(lst);
        }
        //Filtra por Tipo Equipo y Departamento
        [HttpGet]
        [Route("api/ReporteEquipo/xtipodepa/{tipo}/{depa}")]
        public IHttpActionResult GetReporteEquipoxTipoDepa(string tipo,string depa)
        {

            List<data> lst = new List<data>();

            using (Models.inventario2e db = new Models.inventario2e())
            {

                lst = (from marcar in db.marcas
                       join equipos in db.equipos on marcar.id_marca equals equipos.id_marca
                       join modelos in db.modelos on equipos.id_modelo equals modelos.id_modelo
                       join movimientos in db.movimientos_enquipos on
                       equipos.id_equipo equals movimientos.id_equipo
                       join encabezado in db.encabezado_movimientos on movimientos.id_encabezado equals encabezado.id_encabezado
                       join departamentos in db.departamentos on movimientos.id_departamento equals departamentos.id_departamento
                       where equipos.tipo_equipo==tipo && departamentos.departamento==depa

                       select new data
                       {
                           ID = movimientos.id_mov,
                           Tipo = equipos.tipo_equipo,
                           marca = marcar.marca,
                           modelo = modelos.modelo,
                           codigo = equipos.codigo,
                           encabezado = encabezado.encabezado,
                           Ubicacion = departamentos.departamento,
                           Fecha = (DateTime)movimientos.fecha,
                           Estado = (int)equipos.estado
                       }).ToList();
            }
            return Ok(lst);
        }
    }
}