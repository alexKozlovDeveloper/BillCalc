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

        //public void MakeOrder(OrderDTO orderDto)
        //{
        //    Phone phone = Database.Phones.Get(orderDto.PhoneId);

        //    // валидация
        //    if (phone == null)
        //        throw new ValidationException("Телефон не найден", "");
        //    // применяем скидку
        //    decimal sum = new Discount(0.1m).GetDiscountedPrice(phone.Price);
        //    Order order = new Order
        //    {
        //        Date = DateTime.Now,
        //        Address = orderDto.Address,
        //        PhoneId = phone.Id,
        //        Sum = sum,
        //        PhoneNumber = orderDto.PhoneNumber
        //    };
        //    Database.Orders.Create(order);
        //    Database.Save();
        //}

        //public IEnumerable<PhoneDTO> GetPhones()
        //{
        //    // применяем автомаппер для проекции одной коллекции на другую
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Phone, PhoneDTO>()).CreateMapper();
        //    return mapper.Map<IEnumerable<Phone>, List<PhoneDTO>>(Database.Phones.GetAll());
        //}

        //public PhoneDTO GetPhone(int? id)
        //{
        //    if (id == null)
        //        throw new ValidationException("Не установлено id телефона", "");
        //    var phone = Database.Phones.Get(id.Value);
        //    if (phone == null)
        //        throw new ValidationException("Телефон не найден", "");

        //    return new PhoneDTO { Company = phone.Company, Id = phone.Id, Name = phone.Name, Price = phone.Price };
        //}

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

            var deals = Database.Deals.GetAll().Where(a => a.HappeningId == happeningId);

            return mapper.Map<IEnumerable<Deal>, List<DealDTO>>(deals);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
