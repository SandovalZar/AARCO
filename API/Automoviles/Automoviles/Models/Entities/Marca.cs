using System;
using System.Collections.Generic;

#nullable disable

namespace Automoviles.Models.Entities
{
    public partial class Marca
    {
        public Marca()
        {
            Submarca = new HashSet<Submarca>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Submarca> Submarca { get; set; }
    }
}
