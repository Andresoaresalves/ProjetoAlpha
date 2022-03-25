using Alpha_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Alpha_WebAPI.Data{
public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public DbSet<Funcionario> funcionarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Chefe> Chefes { get; set; }
        public DbSet<FuncionarioChefe> FuncionariosChefes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FuncionarioChefe>()
                .HasKey(AD => new { AD.FuncionarioId, AD.ChefeId });

            builder.Entity<Departamento>()
                .HasData(new List<Departamento>(){
                    new Departamento(1, "Administrativo", "ADM"),
                    new Departamento(2, "Financeiro", "FIN"),

                });
                
                builder.Entity<Chefe>()
                .HasData(new List<Chefe>{
                    new Chefe(1, "Rodrigo", 1),
                    new Chefe(2, "Silvana", 2),

                });

            builder.Entity<Funcionario>()
                .HasData(new List<Funcionario>(){
                    new Funcionario(1, "Marta", "Silva", "113247897"),
                    new Funcionario(2, "Paula", "Souza", "124567415"),
                    new Funcionario(3, "Laura", "Santos", "135218795"),
                    new Funcionario(4, "Luisa", "Kent", "115155482"),
                    new Funcionario(5, "Lucas", "Alves", "135654357"),
                    new Funcionario(6, "Pedro", "Rocha", "548468455"),
                    new Funcionario(7, "Paulo", "Silveira", "213546518")
                });

                 builder.Entity<FuncionarioChefe>()
                .HasData(new List<FuncionarioChefe>() {
                    new FuncionarioChefe() {FuncionarioId = 1, ChefeId = 1 },
                    new FuncionarioChefe() {FuncionarioId = 2, ChefeId = 2 },
                    new FuncionarioChefe() {FuncionarioId = 3, ChefeId = 2 },
                    new FuncionarioChefe() {FuncionarioId = 4, ChefeId = 2 },
                    new FuncionarioChefe() {FuncionarioId = 5, ChefeId = 2 },
                    new FuncionarioChefe() {FuncionarioId = 6, ChefeId = 1 },
                    new FuncionarioChefe() {FuncionarioId = 7, ChefeId = 1 },
                    
                    
                });

            
        }
    }

}