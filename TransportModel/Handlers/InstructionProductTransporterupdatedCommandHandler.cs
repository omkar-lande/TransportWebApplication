using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.Commands;
using TransportModel.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TransportModel.Commands;
using TransportModel.Data;

namespace TransportModel.Handlers
{

    public class InstructionProductTransporterupdatedCommandHandler : IRequestHandler<AddTransporterToInstructionProductCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;
        private readonly IInstructionDataAcess _instructionDataAccess;

        public InstructionProductTransporterupdatedCommandHandler(IMediator mediator,
            ApplicationDbContext context,
            IInstructionDataAcess instructionDataAccess)
        {
            _mediator = mediator;
            _context = context;
            _instructionDataAccess = instructionDataAccess;
        }

        public async Task<bool> Handle(AddTransporterToInstructionProductCommand request, CancellationToken cancellationToken)
        {
            {
                var command = new AddTransporterToInstructionProductCommand
                {
                    //InstructionProductId = instructionProductId,
                    //UpdateDTO = updateDTO
                };

                var result = await _mediator.Send(command);

                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }

}
    




