using System.ComponentModel.DataAnnotations;

namespace APISiteBTZ.Model
{
    public class Representada
    {
        [Key]
        public int cod { get; set; }
        public string nome { get; set; } = string.Empty;
    }
}