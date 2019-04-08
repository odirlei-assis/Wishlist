using System;
using System.Collections.Generic;

namespace Senai.Wishlist.WebApi.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Desejos = new HashSet<Desejos>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ICollection<Desejos> Desejos { get; set; }
    }
}
