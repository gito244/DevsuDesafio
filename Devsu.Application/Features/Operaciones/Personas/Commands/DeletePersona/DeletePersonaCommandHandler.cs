using AutoMapper;
using Devsu.Application.Contracts.Persistence;
using Devsu.Application.Contracts.Persistence.Operaciones;
using Devsu.Application.Exceptions;
using Devsu.Domain.Operaciones;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Devsu.Application.Features.Operaciones.Personas.Commands.DeletePersona
{
    public class DeletePersonaCommandHandler : IRequestHandler<DeletePersonaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeletePersonaCommandHandler> _logger;

        public DeletePersonaCommandHandler(IUnitOfWork unitOfWork, IPersonaRepository personaRepository, IMapper mapper, ILogger<DeletePersonaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _personaRepository = personaRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeletePersonaCommand request, CancellationToken cancellationToken)
        {
            var personaToDelete = await _unitOfWork.PersonaRepository.GetByIdAsync(request.PersonaId);
            if (personaToDelete == null)
            {
                _logger.LogError($"{request.PersonaId} persona no existe en el sistema.");
                throw new NotFoundException(nameof(Persona), request.PersonaId);
            }

            _unitOfWork.PersonaRepository.DeleteEntity(personaToDelete);

            await _unitOfWork.Complete();

            _logger.LogInformation($"El {request.PersonaId} persona fue eliminado con exito.");

            return Unit.Value;
        }
    }
}
