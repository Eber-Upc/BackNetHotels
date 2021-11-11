using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.Functions
{
    public class Helper
    {
        public string GetDateChangeFormat(string date)
        {
            string[] parte = null;
            parte = date.Trim().Split("/");
            return (parte[2].Trim() + "-" + parte[1].Trim() + "-" + parte[0].Trim());
        }

        public string GetDateChangeFormatCal(string date)
        {
            string[] parte = null;
            parte = date.Trim().Split("/");
            return (parte[2].Trim() + "-" + parte[1].Trim() + "-" + parte[0].Trim());
        }
    }
}
