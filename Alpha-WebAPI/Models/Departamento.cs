namespace Alpha_WebAPI.Models
{
    public class Departamento
    { public Departamento() { }
        public Departamento(int id, String nome, String sigla)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sigla = sigla;

        }
        public int Id { get; set; }
        public String? Nome { get; set; }
        public String? Sigla { get; set; }
        public IEnumerable<Chefe> Chefes { get; set; }

        public IEnumerable<FuncionarioChefe> FuncionariosChefes {get; set;}
    }


}