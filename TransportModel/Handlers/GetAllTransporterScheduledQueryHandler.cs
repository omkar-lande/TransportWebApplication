using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.Data;
using TransportModel.DTO;
using TransportModel.Model;
using TransportModel.Queries;

namespace TransportModel.Handlers
{
    public class GetAllTransporterScheduledQueryHandler : IRequestHandler<GetAllTransporterToScheduledQuery, List<GetTransporterScheduledDTO>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;

        public GetAllTransporterScheduledQueryHandler(ApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }



        /* public async Task<List<GetTransporterScheduledDTO>> Handle(GetAllTransporterScheduledQuery request, CancellationToken cancellationToken)
         {
             var transporterScheduled = await _context.Instruction
                 .AsNoTracking()
                 .Where(i => i.Status == Model.Enum.Status.Pending)
                 .OrderByDescending(i => i.Id)
                 .Select(  async c => new GetTransporterScheduledDTO
                 {
                     Id = c.Id,
                     PickupAddress = c.PickupAddress,
                     DeliveryAddress = c.DeliveryAddress,
                     Status = c.Status,
                     ClientName = _context.Clients.FirstOrDefault(x => x.Id == c.ClientsId).Name,
                     ProductList= await _mediator.Send(new GetInstructionProductQuery { Id = c.Id })
         })
                 .ToListAsync();
             var result = await Task.WhenAll(transporterScheduled);
             return result.ToList();
            // return transporterScheduled;
         }
        */

        public async Task<List<GetTransporterScheduledDTO>> Handle(GetAllTransporterToScheduledQuery request, CancellationToken cancellationToken)
        {
            var instructions = await _context.Instruction
                .AsNoTracking()
                .Where(i => i.Status == Model.Enum.Status.Pending)
                .ToListAsync();

            var transporterScheduled = new List<GetTransporterScheduledDTO>();

            foreach (var instruction in instructions)
            {
                var clientName = _context.Clients.FirstOrDefault(x => x.Id == instruction.ClientsId)?.Name;
                var productQuery = new GetInstructionProductQuery { Id = instruction.Id };
                var productList = await _mediator.Send(productQuery);

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

            return transporterScheduled;
        }


    }
}

