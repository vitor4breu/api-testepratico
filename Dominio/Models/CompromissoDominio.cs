namespace Dominio.Models
{
    public class CompromissoDominio
    {
        public int? Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime? DataInclusao { get; set; }
        public string Texto { get; set; }
    }
}
