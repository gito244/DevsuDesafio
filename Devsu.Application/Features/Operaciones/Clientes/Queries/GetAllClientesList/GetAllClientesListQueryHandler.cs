using AutoMapper;
using Devsu.Application.Contracts.Persistence;
using Devsu.Application.Features.Operaciones.Clientes.Queries.Vms;
using Devsu.Domain.Operaciones;
using MediatR;
using System.Linq.Expressions;

namespace Devsu.Application.Features.Operaciones.Clientes.Queries.GetAllClientesList
{
    public class GetAllClientesListQueryHandler : IRequestHandler<GetAllClientesListQuery, List<ClienteWithIncludeVmResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllClientesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ClienteWithIncludeVmResponse>> Handle(GetAllClientesListQuery request, CancellationToken cancellationToken)
        {
            var includes = new List<Expression<Func<Cliente, object>>>();
            includes.Add(p => p.Persona!);

            var clienteList = await _unitOfWork.Repository<Cliente>().GetAsync(
                b => b.ClienteId >= 0,
                b => b.OrderBy(x => x.ClienteId),
                includes,
                true);

            return _mapper.Map<List<ClienteWithIncludeVmResponse>>(clienteList);
        }
    }
}
