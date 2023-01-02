namespace APISiteBTZ.Model
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; } = string.Empty;
        public string senha { get; set; } = string.Empty;
        public int master { get; set; }
    }
}