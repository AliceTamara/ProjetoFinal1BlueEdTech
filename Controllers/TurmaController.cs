using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal1BlueEdTech.Contexts;
using ProjetoFinal1BlueEdTech.Models;

namespace ProjetoFinal1BlueEdTech.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurmaController : ControllerBase
    {
        private readonly EscolaContext _context;

        public TurmaController(EscolaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Turma>> ConsultarTodas()
        {
            return await _context.Turmas.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<Turma> ConsultarPeloId(int id)
        {
            return await _context.Turmas.FindAsync(id);
        }
        
        [HttpPost()]
        public async Task<IActionResult> Incluir(Turma turma)
        {
            _context.Turmas.Add(turma);
            await _context.SaveChangesAsync();
        
            return Ok(turma);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);
        
            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();
        
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> Atualizar(Turma turma)
        {
            _context.Entry(turma).State = EntityState.Modified;
        
            await _context.SaveChangesAsync();
        
            return Ok();
        }
    }
}
