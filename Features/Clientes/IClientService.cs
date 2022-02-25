using System;
using System.Collections.Generic;
using Features.Clientes;

namespace Features
{
    public interface IClientService : IDisposable
    {
        IEnumerable<Cliente> ObterTodosAtivos();
        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Remover(Cliente cliente);
        void Inativar(Cliente cliente);
    }
}