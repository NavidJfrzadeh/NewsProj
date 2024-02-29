using Entities;
using Infrastructure.EF.DataBases;

namespace Infrastructure.EF.Repository
{
    public class AdminRepository
    {
        AppDbContext Context = new AppDbContext();
        public List<Admin> GetAll() => Context.Admins.ToList();
    }
}
