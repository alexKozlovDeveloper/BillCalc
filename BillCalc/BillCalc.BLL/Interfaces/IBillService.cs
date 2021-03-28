using BillCalc.BLL.DTO;
using System.Collections.Generic;

namespace BillCalc.BLL.Interfaces
{
    public interface IBillService
    {
        IEnumerable<ClientDTO> GetClients();
        IEnumerable<HappeningDTO> GetHappenings();
        IEnumerable<DealDTO> GetDeals(int happeningId);
        void Dispose();
    }
}
