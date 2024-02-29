using Entities;
using Infrastructure.EF.Repository;

namespace Infrastructure.EF.Services
{
    public class AdminService
    {
        AdminRepository adminRepo = new AdminRepository();
        public Admin CheckLogin(string email, string password)
        {
            var admins = adminRepo.GetAll();
            return admins.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}