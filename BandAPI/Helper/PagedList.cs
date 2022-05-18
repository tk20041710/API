using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }


        public PagedList(List<T> items, int totalCount, int currentPage, int pagesize)
        {
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pagesize;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pagesize);
            AddRange(items);
        }

        public static PagedList<T> Create(IQueryable<T> source, int page1, int size1)
        {
            var count = source.Count();
            var items = source.Skip((page1 - 1) * size1).Take(size1).ToList();
            return new PagedList<T>(items, count, page1, size1);
        }
    }
}
