using System.Threading;
using System.Threading.Tasks;
using API.Interfaces;
using API_MongoDB.Domain.Company.Commands;
using API_MongoDB.Domain.Company.Models;
using API_MongoDB.Services;
using AutoMapper;
using MediatR;

namespace API_MongoDB.Domain.Company
{
    public class CompanyHandler :
        IRequestHandler<LoginCompanyCommand, string>
    {
        private readonly ICompanyRepository _repository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        
        public CompanyHandler(ICompanyRepository repo, IMediator mediator, IMapper mapper)
        {
            _repository = repo;
            _mediator = mediator;
            _mapper = mapper;
        }

        public Task<string> Handle(LoginCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = _repository.FindCompany(request.NameCompany, request.Password);
            if(company is null)
                return Task.FromResult(string.Empty);
            
            var token = TokenService.GenerateToken(company);
            return Task.FromResult(token);
        }
    }
}