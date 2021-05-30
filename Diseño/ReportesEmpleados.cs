using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioAPI.Diseño
{
    public class ReportesEmpleados
    {
        int id_empleado,id_encabezado, id_equipo;
        string nombre_empleado,encabezado,equipo,cargo,departamento,correo;
        DateTime fecha;

        public int Id_empleado { get => id_empleado; set => id_empleado = value; }
        
        public string Nombre_empleado { get => nombre_empleado; set => nombre_empleado = value; }
        public string Encabezado { get => encabezado; set => encabezado = value; }
        public string Equipo { get => equipo; set => equipo = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}