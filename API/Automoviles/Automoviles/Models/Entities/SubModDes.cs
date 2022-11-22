using System;
using System.Collections.Generic;

#nullable disable

namespace Automoviles.Models.Entities
{
    public partial class SubModDes
    {
        public int Id { get; set; }
        public int IdSubm { get; set; }
        public int IdMod { get; set; }
        public int IdDes { get; set; }

        public virtual Descripcion IdDesNavigation { get; set; }
        public virtual Modelo IdModNavigation { get; set; }
        public virtual Submarca IdSubmNavigation { get; set; }
    }
}
