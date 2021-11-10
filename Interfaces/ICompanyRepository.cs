using System.Collections.Generic;
using API.Models;
using System;
using API_MongoDB.Domain.Company.Models;

namespace API.Interfaces
{
    public interface ICompanyRepository
    {
        CompanyEntity FindCompany(string NameCompany, string Password);
    }
}