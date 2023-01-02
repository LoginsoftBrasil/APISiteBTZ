using System.ComponentModel.DataAnnotations;

namespace APISiteBTZ.Model
{
    public class Cliente
    {
        [Key]
        public int cod { get; set; }
        public string nome { get; set; } = string.Empty;
        public double contrato { get; set; } 
        public string prazo { get; set; } = string.Empty; 
        public string fantasia { get; set; } = string.Empty;
        public bool usado { get; set; }
    }
}