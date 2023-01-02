using System.ComponentModel.DataAnnotations;

namespace APISiteBTZ.Model
{
    public class Comprador
    {
        [Key]
        public int cod { get; set; }
        public string nome { get; set; } = string.Empty;
        public int cod_cliente { get; set; }
        public string telefone { get; set; } = string.Empty;
    }
}