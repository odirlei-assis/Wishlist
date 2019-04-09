using Microsoft.EntityFrameworkCore;
using Senai.Wishlist.WebApi.Domains;
using Senai.Wishlist.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Wishlist.WebApi.Repositories
{
    public class DesejoRepository : IDesejosRepository
    {
        public Desejos BuscaDesejoId(int id)
        {
            using (WishlistContext ctx = new WishlistContext())
            {
                Desejos desejoProcurado = ctx.Desejos.Include(x => x.IdusuarioNavigation).FirstOrDefault(x => x.Id == id);

                if (desejoProcurado == null)
                {
                    return null;
                }
                return desejoProcurado;
            }
        }

        public void Cadastrar(Desejos desejo)
        {
            desejo.Datacriacao = DateTime.Now;

            using (WishlistContext ctx = new WishlistContext())
            {
                ctx.Desejos.Add(desejo);
                ctx.SaveChanges();
            }
        }

        public List<Desejos> Listar()
        {
            using (WishlistContext ctx = new WishlistContext())
            {
                return ctx.Desejos.ToList();
            }
        }
    }
}
