using Alpha_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Alpha_WebAPI.Data{

    public class Repository : IRepository {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Funcionario[]> GetAllFuncionarioAsync(bool includeChefe = false)
        {
            IQueryable<Funcionario> query = _context.funcionarios;

            if (includeChefe)
            {
                query = query.Include(pe => pe.FuncionariosChefes)
                             .ThenInclude(ad => ad.Chefe)
                             .ThenInclude(d => d.Departamento);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Funcionario> GetFuncionarioAsyncById(int funcionarioId, bool includeChefe)
        {
            IQueryable<Funcionario> query = _context.funcionarios;

            if (includeChefe)
            {
                query = query.Include(a => a.FuncionariosChefes)
                             .ThenInclude(ad => ad.Chefe)
                             .ThenInclude(d => d.Departamento);
            }

            query = query.AsNoTracking()
                         .OrderBy(funcionario => funcionario.Id)
                         .Where(funcionario => funcionario.Id == funcionarioId);

            return await query.FirstOrDefaultAsync(); 
        }
        public async Task<Funcionario[]> GetFuncionarioAsyncByChefeId(int chefeId, bool includeChefe)
        {
            IQueryable<Funcionario> query = _context.funcionarios;

            if (includeChefe)
            {
                query = query.Include(p => p.FuncionariosChefes)
                             .ThenInclude(ad => ad.Chefe)                             
                             .ThenInclude(d => d.Departamento);
            }

            query = query.AsNoTracking()
                         .OrderBy(funcionario => funcionario.Id)
                         .Where(funcionario => funcionario.FuncionariosChefes.Any(ad => ad.ChefeId == chefeId));

            return await query.ToArrayAsync();
        }

        public async Task<Departamento[]> GetDepartamentosAsyncByFuncionarioId(int funcionarioId, bool includeChefe)
        {
            IQueryable<Departamento> query = _context.Departamentos;

            if (includeChefe)
            {
                query = query.Include(p => p.Chefes);
            }

            query = query.AsNoTracking()
                         .OrderBy(Funcionario => Funcionario.Id)
                         .Where(Funcionario => Funcionario.Chefes.Any(d => 
                            d.FuncionariosChefes.Any(ad => ad.FuncionarioId == funcionarioId)));

            return await query.ToArrayAsync();
        }

        public async Task<Departamento[]> GetAllDepartamentosAsync(bool includeChefe = true)
        {
            IQueryable<Departamento> query = _context.Departamentos;

            if (includeChefe)
            {
                query = query.Include(c => c.Chefes);
            }

            query = query.AsNoTracking()
                         .OrderBy(departamento => departamento.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Departamento> GetDepartamentoAsyncById(int departamentoId, bool includeChefe = true)
        {
            IQueryable<Departamento> query = _context.Departamentos;

            if (includeChefe)
            {
                query = query.Include(pe => pe.Chefes);
            }

            query = query.AsNoTracking()
                         .OrderBy(departamento => departamento.Id)
                         .Where(departamento => departamento.Id == departamentoId);

            return await query.FirstOrDefaultAsync();
        }

    };
}