using Xunit;
using App.Models;
using System.Linq;
using System;

namespace Tests
{
    public class UsuarioTests
    {
        [Fact]
        public void User_Should_Be_Created_With_Name()
        {
            var usuario = new Usuario { Id = 1, Nome = "Joao" };
            Assert.Equal("Joao", usuario.Nome);
        }

        [Fact]
        public void User_Should_Add_Valid_Order()
        {
            var usuario = new Usuario { Id = 1, Nome = "Maria" };
            var pedido = new Pedido { Id = 1, Produto = "Livro", Valor = 50 };
            usuario.AdicionarPedido(pedido);
            Assert.Single(usuario.Pedidos);
            Assert.Equal(usuario, pedido.Usuario);
        }

        [Fact]
        public void User_Should_Throw_When_Adding_Invalid_Order()
        {
            var usuario = new Usuario { Id = 1, Nome = "Maria" };
            var pedido = new Pedido { Id = 2, Produto = "", Valor = 0 };
            Assert.Throws<InvalidOperationException>(() => usuario.AdicionarPedido(pedido));
        }
    }
}