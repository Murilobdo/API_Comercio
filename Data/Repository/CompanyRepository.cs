using System;
using System.Collections.Generic;
using System.Linq;
using API.Interfaces;
using API.Models;
using API_MongoDB.Domain.Company.Models;

namespace API.Data.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;
        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public CompanyEntity FindCompany(string NameCompany, string Password)
        {
            return _context.Company.FirstOrDefault(p => p.NameCompany == NameCompany && p.Password == Password);
        }
    }
}