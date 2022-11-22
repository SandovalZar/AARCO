using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAuto.Models
{
    public class CodigoPostal 
    {
        public Municipio Municipio { get; set; }
        public Ubicacion[] Ubicacion { get; set; }
    }
    public class Catalogo 
    {
        public string CatalogoJsonString { get; set; }
        public int? Error { get; set; }
    }
    public class Municipio
    {
        public int iIdMunicipio { get; set; }
        public Estado Estado { get; set; }
        public int iMunicipioEstado { get; set; }
        public int iClaveMunicipioCepomex { get; set; }
        public string sMunicipio { get; set; }
    }

    public class Estado
    {
        public int iIdEstado { get; set; }
        public int? Pais { get; set; }
        public int iEstadoPais { get; set; }
        public int iClaveEstadoCepomex { get; set; }
        public string sEstado { get; set; }

    }

    public class Ubicacion
    {
        public int iIdUbicacion { get; set; }
        public int? CodigoPostal { get; set; }
        public int iUbicacionCodigoPostal { get; set; }
        public int? TipoUbicacion { get; set; }
        public int iClaveUbicacionCepomex { get; set; }
        public int? Ciudad { get; set; }
        public string sUbicacion { get; set; }
    }
}
