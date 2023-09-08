namespace EFCore_Sample.Models
{
    public class Line
    {
        public string Phrase { get; set; }
    }

    public class Root
    {
        public List<Line> Lines { get; set; }
    }
}
