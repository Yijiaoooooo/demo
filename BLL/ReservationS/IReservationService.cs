using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Domain;
using Data.ViewModels.Reservation;
using Newtonsoft.Json.Linq;

namespace BLL.ReservationS
{
    public interface IReservationService
    {
        ReservationViewModel GetViewModel(int id);

        JObject GetViewModelList(int pageIndex = 1, int pageNum = 3);

        void InsertReservation(Data.Domain.Reservation.Reservation model);

        void DeleteReservation(int id);

        void DeleteReservations(List<int> ids);

        void UpdateReservation(ReservationViewModel entity);
        
    }
}
