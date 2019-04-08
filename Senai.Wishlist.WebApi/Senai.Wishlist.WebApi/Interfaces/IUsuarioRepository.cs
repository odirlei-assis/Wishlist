using Senai.Wishlist.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Wishlist.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuarios usuario);

        List<Usuarios> Listar();

        Usuarios BuscarEmailSenha(string email, string senha);
    }
}
