using AutoMapper;
using BillCalc.BLL.DTO;
using BillCalc.BLL.Interfaces;
using BillCalc.DAL.Entities;
using BillCalc.DAL.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace BillCalc.BLL.Services
{
    public class BillService : IBillService
    {
        IUnitOfWork Database { get; set; }

        public BillService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<ClientDTO> GetClients()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Client>, List<ClientDTO>>(Database.Clients.GetAll());
        }

        public IEnumerable<HappeningDTO> GetHappenings()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Happening, HappeningDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Happening>, List<HappeningDTO>>(Database.Happenings.GetAll());
        }

        public IEnumerable<DealDTO> GetDeals(int happeningId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Deal, DealDTO>()).CreateMapper();

            var deals = Database.Deals.Find(a => a.HappeningId == happeningId);

            return mapper.Map<IEnumerable<Deal>, List<DealDTO>>(deals);
        }

        public void AddHappening(HappeningDTO happeningDto)
        {
            var happening = new Happening
            {
                Name = happeningDto.Name,
                Date = happeningDto.Date
            };

            Database.Happenings.Create(happening);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
