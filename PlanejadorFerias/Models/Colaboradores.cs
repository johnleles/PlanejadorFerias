namespace PlanejadorFerias.Models
{
    public class Colaboradores
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Setor { get; set;}
        public DateTime DataAdmissao { get; set;}

        public Colaboradores() { }
    }
}
