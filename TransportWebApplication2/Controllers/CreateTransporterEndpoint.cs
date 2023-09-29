/*using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportModel.Data;
using TransportModel.DTO;
using TransportModel.Model;

namespace TransportWebApplication.Controllers
{
    [ApiController]
    [Route("api/Transporter")]
    public class CreateTransporterEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;
        

        public CreateTransporterEndpoint(
          IMediator mediator,
          ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        /// <summary>
        /// Scheduled the Transporter to Instruction.
        /// </summary>
        /// <remarks>
        /// This API Scheduled the Transporter to the Particular product of an Instruction.
        /// </remarks>
        /// <param>
        /// Take the TransporterId,InstructionProductId and the ScheduledDate as a Parameter.
        /// </param>
        /// <returns> 200 Ok status </returns>

        [HttpPost]
        public async Task<IActionResult> CreateTransporter(TransporterScheduledDTO request)
        {
            try
            {

                var newTransporterScheduled = new TransporterScheduledDTO
                {
                    // Populate properties from the request
                    InstructionProductId = request.InstructionProductId,
                    TransporterId = request.TransporterId,
                    ScheduledDate = request.ScheduledDate,
                };

                TransportScheduled transportScheuled = new TransportScheduled()
                {
                    InstructionProductId = newTransporterScheduled.InstructionProductId,
                    TransporterId = newTransporterScheduled.TransporterId,
                    ScheduledDate = newTransporterScheduled.ScheduledDate,
                };


                //  _context.Instruction.Add(instruction);

                //  await _context.SaveChangesAsync();

                // Return the newly created instruction's ID
               // return transportScheuled.Id;


                _context.TransportScheduled.Add(transportScheuled);

                await _context.SaveChangesAsync();

                // Return the newly created instruction's 
                return Ok();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error response
                return BadRequest(ex.Message);
            }
        }

        
    }
}
*/