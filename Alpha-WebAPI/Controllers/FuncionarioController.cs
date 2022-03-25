using Alpha_WebAPI.Data;
using Alpha_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alpha_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        public readonly IRepository Repo;
        private readonly IRepository _repo;
        private IRepository repo;

        public FuncionarioController(IRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult>Get()

        {
            try
            {   
                var result = await _repo.GetAllFuncionarioAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ex:{ex.Message}");
            }

        }
        [HttpGet("{FuncionarioId}")]
        public async Task<IActionResult> GetByFuncionarioId(int FuncionarioId)
        {
            try
            {
                var result = await _repo.GetFuncionarioAsyncById(FuncionarioId, true);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
    
        }
        [HttpGet("ByChefe/{chefeId}")]
        public async Task<IActionResult> GetByChefeId(int chefeId)
        {
            try
            {
                var result = await _repo.GetFuncionarioAsyncByChefeId(chefeId, false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    [HttpPost]
        public async Task<IActionResult> post(Funcionario model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
        [HttpPut("{funcionarioId}")]
        public async Task<IActionResult> put(int funcionarioId, Funcionario model)
        {
            try
            {
                var funcionario = await _repo.GetFuncionarioAsyncById(funcionarioId, false);
                if(funcionario == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
        [HttpDelete("{funcionarioId}")]
        public async Task<IActionResult> delete(int funcionarioId)
        {
            try
            {
                var funcionario = await _repo.GetFuncionarioAsyncById(funcionarioId, false);
                if(funcionario == null) return NotFound();

                _repo.Delete(funcionario);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(" Funcionario Deletado");
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
    

}