using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal1BlueEdTech.Models
{
    [Table("Turma", Schema = "dbo")]
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}