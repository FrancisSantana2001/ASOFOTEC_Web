using ASOFOTEC_Web.Data;

namespace ASOFOTEC_Web.Services
{
    public class UserService
    {
        private readonly AppdbContext _context;

        public UserService(AppdbContext context)
        {
           _context = context;
        }

    }
}
