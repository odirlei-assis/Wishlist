using Senai.Wishlist.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Wishlist.WebApi.Interfaces
{
    public interface IDesejosRepository
    {
        void Cadastrar(Desejos desejo);

        List<Desejos>Listar();

        Desejos BuscaDesejoId(int id);
    }
}
