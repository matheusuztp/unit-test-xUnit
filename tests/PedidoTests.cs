using Xunit;
using App.Models;

namespace Tests
{
    public class PedidoTests
    {
        [Fact]
        public void Order_Should_Be_Created_With_Product_And_Value()
        {
            var pedido = new Pedido { Id = 1, Produto = "Caneta", Valor = 2.5M };
            Assert.Equal("Caneta", pedido.Produto);
            Assert.Equal(2.5M, pedido.Valor);
        }

        [Theory]
        [InlineData("Lapis", 1.0, true)]
        [InlineData("", 1.0, false)]
        [InlineData("Borracha", 0, false)]
        public void Order_Validate_Should_Return_Correct_Result_When_Validating(string produto, decimal valor, bool esperado)
        {
            var pedido = new Pedido { Produto = produto, Valor = valor };
            Assert.Equal(esperado, pedido.Validar());
        }
    }
}