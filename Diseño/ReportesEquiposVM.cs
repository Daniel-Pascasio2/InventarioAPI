using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioAPI.Diseño
{
    public class ReportesEquiposVM
    {
        int id_eq , estado;
        string  equipo, serie, departamento;

        public int Id_eq { get => id_eq; set => id_eq = value; }
        
        public string Equipo { get => equipo; set => equipo = value; }
        public string Serie { get => serie; set => serie = value; }
        public string Departamento { get => departamento; set => departamento = value; }

        public int Estado { get => estado; set => estado = value; }
    }
}