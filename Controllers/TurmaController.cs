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
            var turmas = await _context.Turmas.ToListAsync();
            return turmas.Where(_ => _.Ativo).ToList();
        }
        
        [HttpGet("{id}")]
        public async Task<Turma> ConsultarPeloId(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);

            if (turma != null && turma.Ativo)
                return turma;

            return null;
        }
        
        [HttpPost]
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
            var existemAlunosNessaTurma = (_context.Alunos?.Any(e => e.TurmaId == id)).GetValueOrDefault();

            if (turma == null || existemAlunosNessaTurma)
                return StatusCode(StatusCodes.Status406NotAcceptable);
            
            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();
        
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> Atualizar(Turma turma)
        {
            var turmaExiste = (_context.Turmas?.Any(e => e.Id == turma.Id)).GetValueOrDefault();
            if (!turmaExiste)
                return NoContent();
            
            _context.Entry(turma).State = EntityState.Modified;
        
            await _context.SaveChangesAsync();
        
            return Ok();
        }
    }
}