﻿using TestAppRoshelle.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAppRoshelle.DataAccess.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company company);
    }
}
