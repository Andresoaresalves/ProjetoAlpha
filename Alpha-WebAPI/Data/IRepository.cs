using Alpha_WebAPI.Models;

namespace Alpha_WebAPI.Data{
    public interface IRepository{
         //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //ALUNO
        Task<Funcionario[]> GetAllFuncionarioAsync(bool includeDepartamento);        
        Task<Funcionario[]> GetFuncionarioAsyncByChefeId(int chefeId, bool includeChefe);
        Task<Funcionario> GetFuncionarioAsyncById(int funcionarioId, bool includeProfessor);


        //PROFESSOR
        Task<Departamento[]> GetAllDepartamentosAsync(bool includeFuncionario);
        Task<Departamento> GetDepartamentoAsyncById(int departamentoId, bool includeFuncionario);
        Task<Departamento[]> GetDepartamentosAsyncByFuncionarioId(int funcionarioId, bool includeChefe);
       
    }
}
