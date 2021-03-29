using AutoMapper;
using BillCalc.BLL.DTO;
using BillCalc.BLL.Interfaces;
using BillCalc.WEB.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BillCalc.WEB.Controllers
{
    public class HomeController : Controller
    {
        IBillService _billService;

        public HomeController(IBillService service)
        {
            _billService = service;
        }

        public ActionResult Index()
        {
            var happeningDtos = _billService.GetHappenings();

            var happenings = Convert<HappeningDTO, HappeningViewModel>(happeningDtos);

            return View(happenings);        
        }

        public ActionResult CreateHappening()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateHappening(HappeningViewModel happeningViewModel)
        {
            var happeningDto = new HappeningDTO
            {
                Name = happeningViewModel.Name,
                Date = DateTime.Now
            };

            _billService.AddHappening(happeningDto);

            return Redirect("/Home/Index"); ;
        }

        public ActionResult Deals(int happeningId)
        {
            var dealDtos = _billService.GetDeals(happeningId);

            var deals = Convert<DealDTO, DealViewModel>(dealDtos);

            return View(deals);
        }

        protected override void Dispose(bool disposing)
        {
            _billService.Dispose();
            base.Dispose(disposing);
        }

        private IEnumerable<VIEW> Convert<DTO, VIEW> (IEnumerable<DTO> dtos)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DTO, VIEW>()).CreateMapper();

            return mapper.Map<IEnumerable<DTO>, List<VIEW>>(dtos);
        }
    }
}