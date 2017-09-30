using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data.Domain.Reservation;
using Data.ViewModels.Reservation;
using Data.Respository;
using Core.PagedList;
using Newtonsoft.Json.Linq;


namespace BLL.ReservationS
{
    public class ReservationService : IReservationService
    {
        private IRepository<Data.Domain.Reservation.Reservation> _ReservationsRep;
        public ReservationService(IRepository<Data.Domain.Reservation.Reservation> ReservationsRep)
        {
            this._ReservationsRep = ReservationsRep;
        }
        public void DeleteReservation(int id)
        {
            var model = _ReservationsRep.Table.FirstOrDefault(c => c.Id == id);
            _ReservationsRep.Delete(model);
        }

        public ReservationViewModel GetViewModel(int id)
        { 
            var item = _ReservationsRep.Table.FirstOrDefault(c => c.Id == id);
            var model = new ReservationViewModel();

            model.Id = item.Id;
            model.Name = item.Name;
            model.Location = item.Location;
            model.rowGuid = item.rowGuid;
            model.CreateTime = item.CreateTime;

            return model;
        }

        public JObject GetViewModelList (int pageIndex = 1)
        {
            var source = _ReservationsRep.Table;
            List<ReservationViewModel> model = new List<ReservationViewModel>();

            foreach (var item in source)
            {
                var ii = new ReservationViewModel();

                ii.Id = item.Id;
                ii.Name = item.Name;
                ii.Location = item.Location;
                ii.rowGuid = item.rowGuid;
                ii.CreateTime = item.CreateTime;
                model.Add(ii);
            }

            PagedList<ReservationViewModel> list = new PagedList<ReservationViewModel>(model, 3, pageIndex);
            var List = list.ToViewList();
            return List;
        }


        public void InsertReservation(Data.Domain.Reservation.Reservation model)
        {
            _ReservationsRep.Insert(model);
        }

        public void UpdateReservation(ReservationViewModel entity)
        {
            var model = _ReservationsRep.Table.FirstOrDefault(c => c.Id == entity.Id);
            model.Name = entity.Name;
            model.Location = entity.Location;
            _ReservationsRep.Update(model);
        }
    }
}
