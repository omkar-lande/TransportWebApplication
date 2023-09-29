﻿/*using MediatR;
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
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using TransportModel.Model;
using TransportModel.Data;
using TransportWebApplication.Controllers;

namespace TransportModel.Handlers
{
    [Route("api/instructionproducts")]
    [ApiController]
    public class InstructionProductTransporterupdatedendpoint : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;

        public InstructionProductTransporterupdatedendpoint(IMediator mediator, ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }
        /// <summary>
        /// This API allocate Transporter to  the Products.
        /// </summary>
        /// <remarks>
        /// Allocate the Transporter Id and the Scheduled Date for the product.
        /// </remarks>
        /// <param name="updateDTO">
        /// Take the Transporter Id and the Scheduled Date.
        /// </param>
        /// <returns> 200 success for successfully added the Transporter. </returns>
        [HttpPost("addTransporter")]
        public async Task<IActionResult> AddTransporterToInstructionProduct( InstructionProductUpdateListDTO request)
        {
            /* var command = new AddTransporterToInstructionProductCommand
             {
                 InstructionProductId=updateDTO.InstructionProductId,
                 UpdateDTO = updateDTO
             };

             var result = await _mediator.Send(command);

             if (result)
             {
                 return Ok($"Transporter added.");
             }
             else
             {
                 return NotFound($" not found.");
             }
            *//*
            try
            {
                List<InstructionProductUpdateDTO> AddTransporters = new List<InstructionProductUpdateDTO>();

                foreach (var updateDTO in request.TransporterProduct)
                {
                    var instructionProduct = await _context.InstructionProduct.FindAsync(updateDTO.InstructionProductId);
                    if (instructionProduct == null)
                    {
                        // Handle the case where the instruction product is not found
                        // You can choose to skip or log this particular update
                        continue;
                    }
                    InstructionProductUpdateDTO AddTransporter = new InstructionProductUpdateDTO();

                    instructionProduct.ScheduledDate = updateDTO.ScheduledDate.Value;
                    instructionProduct.TransporterId = updateDTO.TransporterId.Value;
                   // AddTransporter.ScheduledDate = updateDTO.ScheduledDate.Value;
                   // AddTransporter.TransporterId = updateDTO.TransporterId.Value;
                   // AddTransporters.Add(AddTransporter);
                    await _context.SaveChangesAsync();
                }
                await _context.SaveChangesAsync();

                var changeStatusEndpoint = new ChangeStatusEndpoint(_mediator);
                await changeStatusEndpoint.GetAllTransporterScheduled();
                //new ChangeStatusEndpoint(_mediator).GetAllTransporterScheduled();
               // await _context.SaveChangesAsync();
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

using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TransportModel.Commands;
using TransportModel.DTO;

[Route("api/instructionproducts")]
[ApiController]
public class InstructionProductTransporterupdatedendpoint : ControllerBase
{
    private readonly IMediator _mediator;

    public InstructionProductTransporterupdatedendpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    /*
    [HttpPost("addTransporter")]
    public async Task<IActionResult> AddTransporterToInstructionProduct(InstructionProductUpdateListDTO request)
    {
        // Create a specific command for this operation
        var command = new AddTransporterToInstructionProductCommand
        {
            UpdateDTO = request.TransporterProduct
        };

        // Send the command to the MediatR pipeline
        var result = await _mediator.Send(command);

        if (result)
        {
            return Ok("Transporters added.");
        }
        else
        {
            return BadRequest("Error adding transporters.");
        }
    }
    */


    [HttpPost("addTransporter")]
    public async Task<bool> AddTransporterToInstructionProduct(InstructionProductUpdateListDTO request)
    {
        // Create a list of commands for this operation
        var commands = request.TransporterProducts.Select(update => new AddTransporterToInstructionProductCommand
        {
            UpdateDTO = update
        }).ToList();

        // Send the commands to the MediatR pipeline
        var results = await Task.WhenAll(commands.Select(command => _mediator.Send(command)));

        if (results.All(result => result))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
