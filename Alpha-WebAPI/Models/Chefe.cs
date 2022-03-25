namespace Alpha_WebAPI.Models
{
    public class Chefe
    {
        public Chefe() { }
        public Chefe(int id, string nome, int departamentoId)
        {
            this.Id = id;
            this.Nome = nome;
            this.DepartamentoId = departamentoId;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public IEnumerable<FuncionarioChefe> FuncionariosChefes { get; set; }
    }
}