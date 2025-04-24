namespace App.Models
{
    public interface INotificador
    {
        void Notificar(string mensagem);
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();

        public void AdicionarPedido(Pedido pedido, INotificador notificador = null)
        {
            if (pedido == null)
                throw new ArgumentNullException(nameof(pedido));
            if (!pedido.Validar())
                throw new InvalidOperationException("Pedido inválido");
            pedido.Usuario = this;
            pedido.UsuarioId = this.Id;
            Pedidos.Add(pedido);
            notificador?.Notificar($"Pedido {pedido.Produto} adicionado para {Nome}");
        }
    }
}