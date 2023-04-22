using Form_Project.Data.Contexts;
using Form_Project.Data.Entities;
using Form_Project.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Form_Project.Repositories
{
    public class FormRepository : IForm
    {
        private readonly FormContext _context;
        public FormRepository(FormContext context)
        {
            _context = context;
        }

        public Task<Form> CreateForm(Form form)
        {
            throw new NotImplementedException();
        }

        public void DeleteForm(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Form>> GetForm()
        {
            return await _context.Forms.ToListAsync();
        }

        public Form GetFormById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateForm(Form form)
        {
            throw new NotImplementedException();
        }
    }
}
