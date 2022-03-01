using Estudos.Hotelaria.Application.Entities;
using Estudos.Hotelaria.Application.Repositories;
using Estudos.Hotelaria.Manager.Models;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.Hotelaria.Manager.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _hotelRepository.Get());
        }

        public async Task<IActionResult> Create(Guid? id)
        {
            var hotelViewModel = new HotelViewModel();
            if (id == null || id == Guid.Empty)
                return View(hotelViewModel);

            var hotel = await _hotelRepository.GetById(id.Value);
            if (hotel != null)
            {
                hotelViewModel = new HotelViewModel
                {
                    Id = hotel.Id,
                    Nome = hotel.Nome,
                    Cidade = hotel.Cidade,
                    TipoAcomodacao = hotel.TipoAcomodacao,
                    ValorDiaria = hotel.ValorDiaria,
                    QuantidadeQuartos = hotel.QuantidadeQuartos,
                    QuantidadeQuartosOcupados = hotel.QuantidadeQuartosOcupados
                };
                return View(hotelViewModel);
            }
            return View(hotelViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HotelViewModel hotelViewModel)
        {
            try
            {
                if (!hotelViewModel.Validate().IsValid)
                {
                    foreach (var erro in hotelViewModel.Validate().Errors)
                        ModelState.AddModelError(erro.PropertyName, erro.ErrorMessage);

                    return View("Create", hotelViewModel);
                }

                var hotel = new Hotel(
                     hotelViewModel.Nome,
                     hotelViewModel.Cidade,
                     hotelViewModel.TipoAcomodacao,
                     hotelViewModel.ValorDiaria,
                     hotelViewModel.QuantidadeQuartos,
                     hotelViewModel.QuantidadeQuartosOcupados
                 );

                if (hotelViewModel.Id != Guid.Empty)
                    hotel.Id = hotelViewModel.Id;

                await _hotelRepository.Save(hotel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var hotel = await _hotelRepository.GetById(id);
            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, IFormCollection collection)
        {
            try
            {
                await _hotelRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
