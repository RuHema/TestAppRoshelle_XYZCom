using TestAppRoshelle.DataAccess.Repository.IRepository;
using TestAppRoshelle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestAppRoshelle.DataAccess.Repository
{
    public class SupplierRepository : RepositoryAsync<Supplier>, ISupplierRepository
    {
        private readonly ApplicationDbContext _db;

        public SupplierRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Supplier supplier)
        {
            var objFromDb = _db.Suppliers.FirstOrDefault(s => s.Id == supplier.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = supplier.Name;
                objFromDb.PortOfDischarge = supplier.PortOfDischarge;
                objFromDb.ImportId = supplier.ImportId;
                objFromDb.ForwarderName = supplier.ForwarderName;
                objFromDb.CategoryId = supplier.CategoryId;
                objFromDb.TelephoneNumber = supplier.TelephoneNumber;
                objFromDb.Fax = supplier.Fax;
                objFromDb.Email = supplier.Email;
                objFromDb.City = supplier.City;
                objFromDb.Country = supplier.Country;
               

            }
        }
    }
}
