namespace Alpha_WebAPI.Models
{
    public class FuncionarioChefe
    {
        public FuncionarioChefe() { }
        public FuncionarioChefe(int funcionarioId,
                                int chefeId)
        {
            this.FuncionarioId = funcionarioId;
            this.ChefeId = chefeId;
        }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int ChefeId { get; set; }
        public Chefe Chefe { get; set; }
    }
}