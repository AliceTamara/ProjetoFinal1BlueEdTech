using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal1BlueEdTech.Contexts;
using ProjetoFinal1BlueEdTech.Models;

namespace ProjetoFinal1BlueEdTech.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly EscolaContext _context;

        public AlunoController(EscolaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Aluno>> ConsultarTodas()
        {
            return await _context.Alunos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Aluno> ConsultarPeloId(int id)
        {
            return await _context.Alunos.FindAsync(id);
        }

        [HttpPost()]
        public async Task<IActionResult> Incluir(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
