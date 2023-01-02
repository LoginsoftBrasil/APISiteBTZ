using System.ComponentModel.DataAnnotations;

namespace APISiteBTZ.Model
{
    public class Pedido
    {
        [Key]
        public int cd_ped { get; set; }
        public string data_reg { get; set; } = string.Empty;
        public int cd_cl { get; set; }
        public string status_ped { get; set; } = string.Empty;
        public int cd_vend { get; set; }
        public decimal valor_total { get; set; }
        public int cd_repr { get; set; }
        public string data_prazo { get; set; } = string.Empty;
        public decimal comissao_vendedor { get; set; }
        public string obs_gerais { get; set; } = string.Empty;
        public int cd_comprador { get; set; }
        public string etiqueta { get; set; } = string.Empty;
        public string telefone { get; set; } = string.Empty;
    }
}
