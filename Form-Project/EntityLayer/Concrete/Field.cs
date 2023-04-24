namespace EntityLayer.Concrete
{

    public class Field
    {
        public int Id { get; set; }
        public bool Required { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public int FormId { get; set; }
        public Form Form { get; set; }
    }
}
