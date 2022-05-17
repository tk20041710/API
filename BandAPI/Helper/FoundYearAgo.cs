using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Helper
{
    public static class FoundYearAgo
    {
        /// <summary>
        /// Thời gian từ khi thành lập đến nay
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int GetYearsAgo(this DateTime dateTime)
        {
            var currentDate = DateTime.Now;
            int yearsago = currentDate.Year - dateTime.Year;
            return yearsago;
        }
    }
}
