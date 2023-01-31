namespace CineBookWcfService.ViewModels
{
    public class MovieSeatTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Background { get; set; }
        public string Foreground { get; set; }
        public bool Salable { get; set; }
    }

    public class BlockViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}