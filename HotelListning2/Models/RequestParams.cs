using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListning2.Models
{
    public class RequestParams
    {

        const int maxPageSize = 50;

        public int PageNum { get; set; } = 1;
        private int _PageSize = 10;

        public int PageSize
        {
            get
            {
                return _PageSize;
            }
            set
            {
                _PageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }


    }
}
