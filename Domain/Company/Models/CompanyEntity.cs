using System;

namespace API_MongoDB.Domain.Company.Models
{
    public class CompanyEntity
    {
        public Guid Id { get; set; }
        public string NameCompany { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}