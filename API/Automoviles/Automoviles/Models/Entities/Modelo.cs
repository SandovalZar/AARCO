using System;
using System.Collections.Generic;

#nullable disable

namespace Automoviles.Models.Entities
{
    public partial class Modelo
    {
        public Modelo()
        {
            SubModDes = new HashSet<SubModDes>();
        }

        public int Id { get; set; }
        public int Anio { get; set; }

        public virtual ICollection<SubModDes> SubModDes { get; set; }
    }
}
