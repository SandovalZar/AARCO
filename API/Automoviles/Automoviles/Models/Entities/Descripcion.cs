using System;
using System.Collections.Generic;

#nullable disable

namespace Automoviles.Models.Entities
{
    public partial class Descripcion
    {
        public Descripcion()
        {
            SubModDes = new HashSet<SubModDes>();
        }

        public int Id { get; set; }
        public string Detalles { get; set; }
        public string DescripcionId { get; set; }

        public virtual ICollection<SubModDes> SubModDes { get; set; }
    }
}
