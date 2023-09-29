using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportModel.Model.Enum;
using TransportModel.Model;
using TransportModel.Data;

namespace TransportModel.Data
{
    public class InstructionDataAcess : IInstructionDataAcess
    {
        private readonly ApplicationDbContext _context;

        public InstructionDataAcess(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateInstructionAsync(DateTime Instructiondate, string ClientName, string PickupAdress, string DeliveryAdress, int ClientId)
        {
            var newInstruction = new Instruction
            {
                CreatedDate = Instructiondate,
                //ClientName = ClientName,
                PickupAddress = PickupAdress,
                DeliveryAddress = DeliveryAdress,
                ClientsId = ClientId,
                // TotalQuantity = TotalQuantity,
                // Status = StatusEnum.Pending, // Set the initial status as "Pending"
                /* IsActive = IsActiveEnum.yes, // Set the initial isActive status
                IsDeleted = IsDeletedEnum.No, // Set the initial isDeleted status
                CreatedBy = "Admin", // Provide the default created by value
                ModifiedBy = "Admin", // Provide the default modified by value
                ModifiedIpConfig = "127.00.23.24", // Provide the default IP config value */

            };


            _context.Instruction.Add(newInstruction);
            await _context.SaveChangesAsync();

            return newInstruction.Id;
        }

        public async Task<int> GetMaxInstructionIdAsync()
        {
            // Use Entity Framework to query the maximum Id from the Instruction table
            var maxId = await _context.Instruction.MaxAsync(i => (int?)i.Id) ?? 0;

            return maxId;
        }

        public async Task<int> CreateInstructionAsync(Instruction instruction)
        {
            _context.Instruction.Add(instruction);
            await _context.SaveChangesAsync();
            return instruction.Id;
        }

        public async Task<int?> GetClientIdByClientNameAsync(string clientName)
        {
            // Use Entity Framework to query the database for the ClientId based on ClientName
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Name == clientName);

            // If the client is found, return its ClientId; otherwise, return null
            return client?.Id;
        }

        public async Task<Instruction> GetInstructionAsync(int id)
        {

            return await _context.Instruction.FindAsync(id);
        }

        public async Task<IEnumerable<Instruction>> GetAllInstructionsAsync()
        {
            return await _context.Instruction.ToListAsync();
        }




        /* // You can implement Update and Delete methods as needed
         public async Task<bool> UpdateInstructionAsync(Instruction instruction)
         {
             _context.Entry(instruction).State = EntityState.Modified;
             await _context.SaveChangesAsync();
             return true;
         }

         public async Task<bool> DeleteInstructionAsync(int id)
         {
             var instruction = await _context.Instructions.FindAsync(id);
             if (instruction == null)
                 return false;

             _context.Instructions.Remove(instruction);
             await _context.SaveChangesAsync();
             return true;
         } */
    }
}
