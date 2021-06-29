using TestAppRoshelle.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAppRoshelle.DataAccess.Repository.IRepository
{
    public interface ISupplierRepository : IRepositoryAsync<Supplier>
    {
        void Update(Supplier supplier);
    }
}
