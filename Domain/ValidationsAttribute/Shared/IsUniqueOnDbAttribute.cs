using System.ComponentModel.DataAnnotations;
using API.Interfaces;
using API_MongoDB.Domain.Enums;

namespace API_MongoDB.Domain.ValidationsAttribute.Shared
{
    public class IsUniqueOnDbAttribute : ValidationAttribute
    {
        public TableName NameTable;
        
        private readonly ICompanyRepository _companyRepo;

        public IsUniqueOnDbAttribute(TableName nameTable)
        {
            this.NameTable = nameTable;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            switch (this.NameTable)
            {
                case TableName.Company:
                    break;
                case TableName.Product:
                    break;
                default:
                    break;
            }
            
            return null;
        }

    }
}