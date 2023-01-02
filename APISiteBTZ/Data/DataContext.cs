using APISiteBTZ.Model;
using Microsoft.EntityFrameworkCore;

namespace APISiteBTZ.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Cliente> TAB_CLIENTES { get; set; }
        public DbSet<Comprador> TAB_CONTATOS { get; set; }
        public DbSet<Produto> TAB_PRODUTOS { get; set; }
        public DbSet<Representada> TAB_REPRESENTADA { get; set; }
        public DbSet<Usuario> TAB_USUARIOS { get; set; }
        public DbSet<Pedido> Tab_PEDIDOS { get; set; }
        public DbSet<ItemDoPedido> Tab_PED_ITENS { get; set; }
    }
}