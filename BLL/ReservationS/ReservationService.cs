using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data.Domain.Reservation;
using Data.ViewModels.Reservation;
using Data.ViewModels.Query;
using Data.Respository;
using Core.PagedList;
using Newtonsoft.Json.Linq;
using Data.Context;
using System.Data.SqlClient;

namespace BLL.ReservationS
{
    public class ReservationService : IReservationService
    {
        private IRepository<Data.Domain.Reservation.Reservation> _ReservationsRep;
        private IDbContext _dbContext;

        public ReservationService(IRepository<Data.Domain.Reservation.Reservation> ReservationsRep, IDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._ReservationsRep = ReservationsRep;
        }
        public void DeleteReservation(int id)
        {
            var model = _ReservationsRep.Table.FirstOrDefault(c => c.Id == id);
            _ReservationsRep.Delete(model);
        }

        public void DeleteReservations(List<int> ids)
        {
            List<Reservation> models = new List<Reservation>();
            foreach (var id in ids)
            {
                var entity = _ReservationsRep.Table.FirstOrDefault(c => c.Id == id);
                models.Add(entity);
            }
            _ReservationsRep.Delete(models);
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

        public JObject GetViewModelList(int pageIndex = 1, int pageNum = 3)
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

            PagedList<ReservationViewModel> list = new PagedList<ReservationViewModel>(model, pageNum, pageIndex);
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

        //查询
        public JObject QueryReservation(queryViewModel query)
        {
            //List<SqlParameter> Query = new List<SqlParameter>();
            //string Sql = "select * from [hello].[dbo].[Reservation] where ";
            IEnumerable<Reservation> model = _ReservationsRep.Table;

            if (!string.IsNullOrEmpty(query.Name))
            {
                model = model.Where(c => c.Name == query.Name);
                //SqlParameter Qname = new SqlParameter("@Name", query.Name);
                //Query.Add(Qname);

                //Sql += " Name = @Name ";
            }
            if (!string.IsNullOrEmpty(query.Location))
            {
                model = model.Where(c => c.Location == query.Location);
                //SqlParameter Qlocation = new SqlParameter("@Location", query.Location);
                //Query.Add(Qlocation);

                //Sql += " and Location = @Location ";
            }
            if (query.StartDate != Convert.ToDateTime("0001/1/1 0:00:00") && query.EndDate != Convert.ToDateTime("0001/1/1 0:00:00"))
            {
                model = model.Where(c => c.CreateTime > query.StartDate);
                model = model.Where(c => c.CreateTime < query.EndDate);
                //SqlParameter QstartDate = new SqlParameter("@StartDate", query.StartDate);
                //SqlParameter QendDate = new SqlParameter("@EndDate", query.EndDate);
                //Query.Add(QstartDate);
                //Query.Add(QendDate);

                //Sql += " and CreateTime Between @StartDate and @ EndDate ";
            }
            else if (query.StartDate != Convert.ToDateTime("0001/1/1 0:00:00") && query.EndDate == Convert.ToDateTime("0001/1/1 0:00:00"))
            {
                model = model.Where(c => c.CreateTime > query.StartDate);
                //SqlParameter QstartDate = new SqlParameter("@StartDate", query.StartDate);
                //Query.Add(QstartDate);

                //Sql += " and CreateTime > @StartDate ";
            }
            else if (query.StartDate == Convert.ToDateTime("0001/1/1 0:00:00") && query.EndDate != Convert.ToDateTime("0001/1/1 0:00:00"))
            {
                model = model.Where(c => c.CreateTime < query.EndDate);
                //SqlParameter QendDate = new SqlParameter("@EndDate", query.EndDate);
                //Query.Add(QendDate);

                //Sql += " and CreateTime < @EndDate ";
            }

            //var model = _dbContext.SqlQuery<Reservation>(Sql, Query);
            List<ReservationViewModel> Model = new List<ReservationViewModel>();

            foreach (var item in model)
            {
                var ii = new ReservationViewModel();

                ii.Id = item.Id;
                ii.Name = item.Name;
                ii.Location = item.Location;
                ii.rowGuid = item.rowGuid;
                ii.CreateTime = item.CreateTime;
                Model.Add(ii);
            }

            PagedList<ReservationViewModel> list = new PagedList<ReservationViewModel>(Model, query.PageNum, query.PageIndex);
            var List = list.ToViewList();
            return List;

        }
    }
}
