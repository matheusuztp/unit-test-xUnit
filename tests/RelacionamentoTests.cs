using Xunit;
using App.Models;
using System.Linq;
using System;
using Moq;

namespace Tests
{
    public class RelacionamentoTests
    {
        [Fact]
        public void User_Should_Have_Multiple_Orders()
        {
            var usuario = new Usuario { Id = 1, Nome = "Carlos" };
            usuario.AdicionarPedido(new Pedido { Id = 1, Produto = "Caderno", Valor = 15 });
            usuario.AdicionarPedido(new Pedido { Id = 2, Produto = "Lapis", Valor = 1.5M });
            Assert.Equal(2, usuario.Pedidos.Count);
            Assert.All(usuario.Pedidos, p => Assert.Equal(usuario, p.Usuario));
        }

        [Fact]
        public void Order_Should_Reference_User()
        {
            var usuario = new Usuario { Id = 2, Nome = "Ana" };
            var pedido = new Pedido { Id = 3, Produto = "Borracha", Valor = 0.99M };
            usuario.AdicionarPedido(pedido);
            Assert.Equal(usuario, pedido.Usuario);
            Assert.Equal(usuario.Id, pedido.UsuarioId);
        }

        [Fact]
        public void AddOrder_Should_Call_Notifier()
        {
            var usuario = new Usuario { Id = 3, Nome = "Lucas" };
            var pedido = new Pedido { Id = 4, Produto = "Apontador", Valor = 3 };
            var mockNotificador = new Mock<INotificador>();
            usuario.AdicionarPedido(pedido, mockNotificador.Object);
            mockNotificador.Verify(n => n.Notificar(It.Is<string>(msg => msg.Contains("Apontador") && msg.Contains("Lucas"))), Times.Once);
        }
    }
}