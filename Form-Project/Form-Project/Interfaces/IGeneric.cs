namespace Form_Project.Interfaces
{
    public interface IGeneric <T>
    {
        public Task<T> CreateForm(T form);
        public void UpdateForm(T form);
        public void DeleteForm(int id);
        public List<T> GetForm();
        public T GetFormById(int id);
    }
}
