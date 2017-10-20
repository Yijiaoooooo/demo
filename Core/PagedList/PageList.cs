using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Data.Domain;
using Newtonsoft.Json.Linq;

namespace Core.PagedList
{
    /// <summary>
    /// Paged list
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    [Serializable]
    [KnownType(typeof(BaseEntity))]
    public class PagedList<T> : List<T>, IPagedList<T>
    {

        /*public PagedList(IQueryable<T> source, ISearchCriteria criteria) : this(source, criteria.PageIndex, criteria.PageSize, criteria.TotalCount)
        {

        }*/

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(IQueryable<T> source, int pageSize, int pageIndex = 1)
        {
            int total = source.Count();
            this.TotalCount = total;
            this.TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;

            if (pageIndex == 0)
                pageIndex = 1;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.AddRange(source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
        }


        /*public PagedList(IList<T> source, ISearchCriteria criteria) : this(source, criteria.PageIndex, criteria.PageSize, criteria.TotalCount)
        {

        }*/

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(IList<T> source, int pageSize, int pageIndex = 1)
        {
            if (pageIndex == 0)
                pageIndex = 1;

            if (pageSize != 0)
            {
                TotalCount = source.Count();
                TotalPages = TotalCount / pageSize;

                if (TotalCount % pageSize > 0)
                    TotalPages++;

                this.PageSize = pageSize;
                this.PageIndex = pageIndex;
                this.AddRange(source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
            }
            else
            {
                this.PageIndex = pageIndex;
                this.PageSize = pageSize;
                TotalCount = 0;
                TotalPages = 0;
            }
        }


        /*public PagedList(IEnumerable<T> source, ISearchCriteria criteria, int totalCount) : this(source, criteria.PageIndex, criteria.PageSize, totalCount)
        {

        }*/

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="totalCount">Total count</param>
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            if (pageIndex == 0)
                pageIndex = 1;


            TotalCount = totalCount;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.AddRange(source);
        }

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public IEnumerable<T> result { get; set; }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }
        public JObject ToViewList(bool success = true)
        {
            var a = typeof(T);
            if (this == null)
            {
                return null;
            }
            JObject list = new JObject();

            list.Add("TotalPages", this.TotalPages);

            JArray model = JArray.FromObject(this.ToList());

            list.Add("model", model);
            list.Add("success", success);
            return list;
        }
    }
}
