namespace ProjetoFinal1BlueEdTech.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public Char Sexo { get; set; }
        public int TurmaId { get; set; }
        public int TotalFaltas { get; set; }
    }
}