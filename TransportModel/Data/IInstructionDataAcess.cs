using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportModel.Model;

namespace TransportModel.Data
{
    public interface IInstructionDataAcess
    {
         Task<int> CreateInstructionAsync(Instruction Instruction);
        Task<int> CreateInstructionAsync(DateTime Instructiondate, string ClientName, string PickupAdress, string DeliveryAdress, int ClientId);

        Task<int?> GetClientIdByClientNameAsync(string clientName);
        Task<Instruction> GetInstructionAsync(int id);
        Task<IEnumerable<Instruction>> GetAllInstructionsAsync();
        Task<int> GetMaxInstructionIdAsync();
    }
}
