using System;
using System.Collections.Generic;

#nullable disable

namespace Automoviles.Models.Entities
{
    public partial class Submarca
    {
        public Submarca()
        {
            SubModDes = new HashSet<SubModDes>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdMarca { get; set; }

        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual ICollection<SubModDes> SubModDes { get; set; }
    }
}
