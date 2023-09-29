using MediatR;
using TransportModel.DTO;


namespace TransportModel.Queries
{
    public class GetInstructionQuery : IRequest<InstructionNameDTO>
    {
        public int Id { get; set; }
    }
}
