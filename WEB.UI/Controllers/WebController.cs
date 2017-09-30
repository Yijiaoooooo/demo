using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data.Domain.Reservation;
using Data.Respository;

using Newtonsoft.Json.Linq;
using BLL.ReservationS;
using Data.ViewModels.Reservation;

namespace WEB.UI.Controllers
{
    public class WebController : ApiController
    {
        private readonly IRepository<Reservation> _reservationRepository;
        private readonly IReservationService _reservationService;
        
        public WebController(IRepository<Reservation> reservationRepository, IReservationService reservationService)
        {
            this._reservationRepository = reservationRepository;
            this._reservationService = reservationService;
        }

        public Reservation GetReservation(int id)
        {
            var model = _reservationRepository.GetById(id);
            return model;
        }

        public JObject GetAllReservations(int pageIndex = 1)
        {
            return _reservationService.GetViewModelList(pageIndex);
        }

        [HttpPost]
        public void SaveReservation(Reservation entity)
        {
            _reservationService.InsertReservation(entity);            
        }

        [HttpDelete]
        public void DeleteReservation(dynamic req)
        {
            int id = (int)req.Id;
            _reservationService.DeleteReservation(id);
        }
        public void PutReservation(ReservationViewModel entity)
        {
            _reservationService.UpdateReservation(entity);
        }
    }
}
