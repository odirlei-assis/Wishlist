using Microsoft.EntityFrameworkCore;
using Senai.Wishlist.WebApi.Domains;
using Senai.Wishlist.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Wishlist.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios BuscarEmailSenha(string email, string senha)
        {
            using (WishlistContext ctx = new WishlistContext())
            {
                Usuarios usuarioProcurado = ctx.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);

                if (usuarioProcurado == null)
                {
                    return null;
                }
                return usuarioProcurado;
            }
        }

        

        public void Cadastrar(Usuarios usuario)
        {
            using (WishlistContext cadastrar = new WishlistContext())
            {
                cadastrar.Usuarios.Add(usuario);
                cadastrar.SaveChanges();
            }
        }

        public List<Usuarios> Listar()
        {
            using (WishlistContext ctx = new WishlistContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
    }
}
