using TestAppRoshelle.DataAccess.Repository.IRepository;
using TestAppRoshelle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestAppRoshelle.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
