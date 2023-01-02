using System.ComponentModel.DataAnnotations;

namespace APISiteBTZ.Model
{
    public class ItemDoPedido
    {
        [Key]
        public int id { get; set; }
        public int cd_ped { get; set; }
        public int cd_prod { get; set; }
        public string descr { get; set; } = string.Empty;
        public int qtde { get; set; }
        public decimal valor_unit { get; set; }
        public decimal valor_total { get; set; }
    }
}
