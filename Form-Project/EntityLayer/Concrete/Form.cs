namespace EntityLayer.Concrete
{
    public class Form
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }
        public List<Field> Fields { get; set; }      

    }
}
