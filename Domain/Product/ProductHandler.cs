using System;
using System.Threading;
using System.Threading.Tasks;
using API.Domain.Product.Command;
using API.Models;
using API.Interfaces;
using AutoMapper;
using MediatR;
using API.Extensions;

namespace API.Domain.Product
{
    public class ProductHandler:
        IRequestHandler<AddProductCommand, string>,
        IRequestHandler<UpdateProductCommand, string>,
        IRequestHandler<DeleteProductCommand, string>
    {
        private readonly IProductRepository _repository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductHandler(IProductRepository repo, IMediator mediator, IMapper mapper)
        {
            _repository = repo;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<string> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            if(_repository.IfExist(request.Name))
                return await Task.FromResult("Ja existe um produto cadastrado com esse nome.");
            
            _repository.AddProduct(_mapper.Map<ProductEntity>(request));
            return await Task.FromResult("Produto cadastro com sucesso.");
            
        }

        public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if(request.Id == Guid.Empty) 
               return await Task.FromResult("Nenhum Id foi fornecido.");

            var product = _repository.Find(request.Id);
            _repository.DeleteProduct(product);
            return await Task.FromResult("Produto excluído com sucesso.");
        }

        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Guid id;
            if(!Guid.TryParse(request.Id, out id))
                return await Task.FromResult("Um Id inválido foi fornecido, não e possível efetuar a ação.");

            _repository.UpdateProduct(_mapper.Map<ProductEntity>(request));
            return await Task.FromResult("Produto alterado com sucesso.");
        }
    }
}