namespace Alpha_WebAPI.Models
{
    public class Funcionario
    {
        public Funcionario() { }
        public Funcionario(int id, String nome, String sobrenome, String documento)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Documento = documento;

        }
        public int Id { get; set; }
        public String? Nome { get; set; }
        public String? Sobrenome { get; set; }
        public String? Documento { get; set; }

        public IEnumerable<FuncionarioChefe> FuncionariosChefes {get; set;}
    }
}