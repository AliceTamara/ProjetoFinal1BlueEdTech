using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal1BlueEdTech.Models
{
    [Table("Aluno", Schema = "dbo")]
    public class Aluno
    {
        [Column("Data_Nascimento")]
        public DateTime DataDeNascimento { get; set; }

        [Column("Turma_Id")]
        public int TurmaId { get; set; }


        [Column("Total_Faltas")]
        public int TotalFaltas { get; set; }

        public int Id { get; set; }
        public string Nome { get; set; }
        public Char Sexo { get; set; }
        public bool Ativo { get; set; }
    }
}