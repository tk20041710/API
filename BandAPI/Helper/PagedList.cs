﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int Size { get; set; }
        public int TotalCount { get; set; }


        public PagedList(List<T> items, int totalCount, int currentPage, int size)
        {
            TotalCount = totalCount;
            CurrentPage = currentPage;
            Size = size;
            TotalPages = (int)Math.Ceiling(totalCount / (double)size);
            AddRange(items);
        }

        public static PagedList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
