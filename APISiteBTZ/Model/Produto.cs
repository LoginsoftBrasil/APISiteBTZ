using System.ComponentModel.DataAnnotations;

namespace APISiteBTZ.Model
{
    public class Produto
    {
        [Key]
        public int cod { get; set; }
        public string nome { get; set; } = string.Empty;
        public decimal valor_unitario { get; set; }
    }
}