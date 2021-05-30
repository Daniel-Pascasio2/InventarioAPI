using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace InventarioAPI.Controllers
{
    public class ReporteEmpleadoController : ApiController
    {
        //Esta clase corresponde al REPORTE DE EMPLEADOS
        //Filtra por tipo de encabezado movimientos
        [HttpGet]
        [Route("api/ReporteEmpleado/{enc}/{depa}")]
        public IHttpActionResult GetMovi(string enc, string depa) {

            List<Diseño.ReportesEmpleados> lst = new List<Diseño.ReportesEmpleados>();

            using (Models.inventario2e db = new Models.inventario2e()) {

                lst = (from movimientos in db.movimientos_enquipos join empleados in db.empleados
                        on movimientos.id_empleado equals empleados.id_empleado join departamentos in db.departamentos on empleados.id_departamento equals departamentos.id_departamento
                       join encabezado in db.encabezado_movimientos
                            on movimientos.id_encabezado equals encabezado.id_encabezado
                       join cargos in db.cargos
                            on empleados.id_cargo equals cargos.id_cargo join equipos in db.equipos
                                on movimientos.id_equipo equals equipos.id_equipo join marcas in db.marcas on equipos.id_marca equals marcas.id_marca
                       join modelos in db.modelos on equipos.id_modelo equals modelos.id_modelo where encabezado.encabezado == enc && departamentos.departamento == depa

                       select new Diseño.ReportesEmpleados
                       {
                           Id_empleado = empleados.id_empleado,
                           Nombre_empleado = empleados.nombre + " " + empleados.apellido,
                           Cargo = cargos.cargo,
                           Equipo = marcas.marca + " " + modelos.modelo,
                           Encabezado = encabezado.encabezado,
                           Departamento = departamentos.departamento,
                           Fecha = (DateTime)movimientos.fecha

                       }).ToList();
            }
            return Ok(lst);

        }

        [HttpGet]
        [Route("api/ReporteEmpleado/{enc}")]
        public IHttpActionResult GetMovi(string enc)
        {

            List<Diseño.ReportesEmpleados> lst = new List<Diseño.ReportesEmpleados>();

            using (Models.inventario2e  db = new Models.inventario2e ())
            {

                lst = (from movimientos in db.movimientos_enquipos
                       join empleados in db.empleados
                            on movimientos.id_empleado equals empleados.id_empleado
                       join departamentos in db.departamentos 
                            on empleados.id_departamento equals departamentos.id_departamento
                        join cargos in db.cargos
                            on empleados.id_cargo equals cargos.id_cargo
                       join encabezado in db.encabezado_movimientos
                            on movimientos.id_encabezado equals encabezado.id_encabezado
                       join equipos in db.equipos
                            on movimientos.id_equipo equals equipos.id_equipo
                       join marcas in db.marcas 
                            on equipos.id_marca equals marcas.id_marca
                       join modelos in db.modelos 
                            on equipos.id_modelo equals modelos.id_modelo

                       where encabezado.encabezado == enc

                       select new Diseño.ReportesEmpleados
                       {
                           Id_empleado = empleados.id_empleado,
                           Nombre_empleado = empleados.nombre + " " + empleados.apellido,
                           Cargo = cargos.cargo,
                           Equipo = marcas.marca + " " + modelos.modelo,
                           Encabezado = encabezado.encabezado,
                           Departamento = departamentos.departamento,
                           Fecha = (DateTime)movimientos.fecha

                       }).ToList();
            }
            return Ok(lst);

        }
        [HttpGet]
        [Route("api/ReporteEmpleado/")]
        public IHttpActionResult GetMovi()
        {

            List<Diseño.ReportesEmpleados> lst = new List<Diseño.ReportesEmpleados>();

            using (Models.inventario2e db = new Models.inventario2e())
            {

                lst = (from movimientos in db.movimientos_enquipos
                       join empleados in db.empleados
                            on movimientos.id_empleado equals empleados.id_empleado
                       join departamentos in db.departamentos
                            on empleados.id_departamento equals departamentos.id_departamento
                       join cargos in db.cargos
                           on empleados.id_cargo equals cargos.id_cargo
                       join encabezado in db.encabezado_movimientos
                            on movimientos.id_encabezado equals encabezado.id_encabezado
                       join equipos in db.equipos
                            on movimientos.id_equipo equals equipos.id_equipo
                       join marcas in db.marcas
                            on equipos.id_marca equals marcas.id_marca
                       join modelos in db.modelos
                            on equipos.id_modelo equals modelos.id_modelo


                       select new Diseño.ReportesEmpleados
                       {
                           Id_empleado = empleados.id_empleado,
                           Nombre_empleado = empleados.nombre + " " + empleados.apellido,
                           Cargo = cargos.cargo,
                           Equipo = marcas.marca + " " + modelos.modelo,
                           Encabezado = encabezado.encabezado,
                           Departamento = departamentos.departamento,
                           Fecha = (DateTime)movimientos.fecha

                       }).ToList();
            }
            return Ok(lst);

        }


    }
}