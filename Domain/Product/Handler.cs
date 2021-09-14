using System.Threading;
using System.Threading.Tasks;
using API.Domain.Product.Command;
using API.Models;
using API.Interfaces;
using AutoMapper;
using MediatR;

namespace API.Domain.Product
{
    public class Handler : 
        IRequestHandler<AddProductCommand, string>,
        IRequestHandler<UpdateProductCommand, string>,
        IRequestHandler<DeleteProductCommand, string>
    {
        private readonly IProductRepository _repository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public Handler(IProductRepository repo, IMediator mediator, IMapper mapper)
        {
            _repository = repo;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<string> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            _repository.AddProduct(_mapper.Map<ProductEntity>(request));
            return await Task.FromResult("Produto cadastro com sucesso.");
        }

        public Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}