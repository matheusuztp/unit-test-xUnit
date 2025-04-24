namespace App.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public decimal Valor { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public bool Validar()
        {
            return !string.IsNullOrWhiteSpace(Produto) && Valor > 0;
        }
    }
}