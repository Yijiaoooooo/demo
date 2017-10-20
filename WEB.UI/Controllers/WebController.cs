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
using Data.ViewModels.Query;

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
        
        public JObject GetAllReservations(int pageIndex = 1, int pageNum = 3)
        {
            return _reservationService.GetViewModelList(pageIndex, pageNum);
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
        [Route("api/web/more/{id}")]
        public void DeleteReservations(string[] req)
        {
            List<int> ids = new List<int>();
            foreach (var id in req)
            {
                int i = Convert.ToInt32(id);
                ids.Add(i);
            }
            _reservationService.DeleteReservations(ids);
        }
        public void PutReservation(ReservationViewModel entity)
        {
            _reservationService.UpdateReservation(entity);
        }

        [Route("api/web/query")]
        public JObject Query(queryViewModel req)
        {
            return _reservationService.QueryReservation(req);
        }
    }
}
