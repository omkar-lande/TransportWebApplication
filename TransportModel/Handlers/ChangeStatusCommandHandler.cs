/*using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.Commands;
using TransportModel.Data;
using TransportModel.DTO;
using TransportModel.Queries;

namespace TransportModel.Handlers
{
    public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, List< ChangeStatusDTO>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;

        public ChangeStatusCommandHandler(ApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<List<GetTransporterScheduledDTO>> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var pendingInstructions = await _context.Instruction
                     .Where(i => i.Status == Model.Enum.Status.Pending)
                     .ToListAsync();

            var transporterScheduled = new List<GetTransporterScheduledDTO>();

            foreach (var instruction in pendingInstructions)
            {
                var clientName = _context.Clients.FirstOrDefault(x => x.Id == instruction.ClientsId)?.Name;
                var productQuery = new GetInstructionProductQuery { Id = instruction.Id };
                var productList = await _mediator.Send(productQuery);

                // Check if all products have non-null and non-zero TransporterId
                
                bool allProductsScheduled = productList.All(p => p.TransporterId != null && p.TransporterId != 0);

                if (allProductsScheduled)
                {
                    // Update instruction status to "scheduled" in the database
                    instruction.Status = Model.Enum.Status.Scheduled;
                    _context.Entry(instruction).State = EntityState.Modified;
                }

                var transporterScheduledDTO = new GetTransporterScheduledDTO
                {
                    Id = instruction.Id,
                    PickupAddress = instruction.PickupAddress,
                    DeliveryAddress = instruction.DeliveryAddress,
                    Status = instruction.Status,
                    ClientName = clientName,
                    ProductList = productList
                };

                transporterScheduled.Add(transporterScheduledDTO);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            return transporterScheduled;
        }
    }
}



<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
*/
/*
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransportModel.Commands;
using TransportModel.Data;
using TransportModel.DTO;
using TransportModel.Model;
using TransportModel.Queries;

namespace TransportModel.Handlers
{
    public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, bool>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;

        public ChangeStatusCommandHandler(ApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<bool> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var pendingInstructions = await _context.Instruction
                     .FirstOrDefaultAsync(i => i.Status == Model.Enum.Status.Pending && i.Id == request.instructionid);
            
            
            pendingInstructions.Status = Model.Enum.Status.Scheduled;
           
            
            _context.Entry(pendingInstructions).State = EntityState.Modified;
           
            await _context.SaveChangesAsync();


            //var updatedInstructions = new List<ChangeStatusDTO>();

            //foreach (var instruction in pendingInstructions)
            //{
            //    var productQuery = new GetInstructionProductQuery { Id = instruction.Id };
            //    var productList = await _mediator.Send(productQuery);

            //    // Check if all products have non-null and non-zero TransporterId
            //    bool allProductsScheduled = productList.All(p => p.TransporterName != null  );

            //    if (allProductsScheduled)
            //    {
            //        // Update instruction status to "Scheduled" in the database
            //        instruction.Status = Model.Enum.Status.Scheduled;
            //        _context.Entry(instruction).State = EntityState.Modified;
                    
            //    }
            //}

            //// Save changes to the database
            //await _context.SaveChangesAsync();

            return true;
        }
    }
}
*/


using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransportModel.Commands;
using TransportModel.Data;
using TransportModel.DTO;
using TransportModel.Model;
using TransportModel.Queries;

namespace TransportModel.Handlers
{
    public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, bool>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;

        public ChangeStatusCommandHandler(ApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<bool> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var pendingInstructions = await _context.Instruction
                      .FirstOrDefaultAsync(i => i.Status == Model.Enum.Status.Pending && i.Id== request.instructionid);

                var updatedInstructions = new ChangeStatusDTO();

           
                var productQuery = new GetInstructionProductQuery { Id = pendingInstructions.Id };
                var productList = await _mediator.Send(productQuery);

                // Check if all products have non-null and non-zero TransporterId
                bool allProductsScheduled = productList.All(p => p.TransporterName != null);

                if (allProductsScheduled)
                {
                    // Update instruction status to "Scheduled" in the database
                    pendingInstructions.Status = Model.Enum.Status.Scheduled;
                    _context.Entry(pendingInstructions).State = EntityState.Modified;

                }
            

            // Save changes to the database
            await _context.SaveChangesAsync();

            return true;
        }
    }
}




/*
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using TransportModel.Commands;
using TransportModel.Data;
using TransportModel.DTO;
using TransportModel.Queries;

public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public ChangeStatusCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var pendingInstructions = await _context.Instruction
                    .Where(i => i.Id == request.instructionid)
                    .ToListAsync();
            var updatedInstructions = new ChangeStatusDTO();


            var productQuery = new GetInstructionProductQuery { Id = pendingInstructions.Id };
            var productList = await _mediator.Send(productQuery);

            // Check if all products have non-null and non-zero TransporterId
            bool allProductsScheduled = productList.All(p => p.TransporterName != null);

            if (allProductsScheduled)
            {
                // Update instruction status to "Scheduled" in the database
                pendingInstructions.Status = Model.Enum.Status.Scheduled;
                _context.Entry(pendingInstructions).State = EntityState.Modified;

            }


            // Save changes to the database
            await _context.SaveChangesAsync();





            foreach (var updateDTO in request.TransporterProducts)
            {
                var instructionProduct = await _context.InstructionProduct.FindAsync(updateDTO.InstructionProductId);
                if (instructionProduct == null)
                {
                    continue;
                }

                instructionProduct.ScheduledDate = updateDTO.ScheduledDate.Value;
                instructionProduct.TransporterId = updateDTO.TransporterId.Value;
            }

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            // Handle any exceptions and return an error response
            return false;
        }
    }
}
*/