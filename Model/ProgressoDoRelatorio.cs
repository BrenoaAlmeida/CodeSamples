namespace Model
{
    public class ProgressoDoRelatorio
    {
        public int PorcemtagemCompleta { get; set; } = 0;
        public List<Website> SitesBaixados { get; set; } = new List<Website>();
    }
}
