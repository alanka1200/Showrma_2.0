using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Showrma.Model
{
    public partial class ClientService
    {
        public string CollorEnd
        {
            get
            {
                if ((StartTime - DateTime.Now) < TimeSpan.FromHours(5))
                {
                    return $"#FFE7FABF";
                }
                else
                {
                    return "";
                }

            }

        }
        public string TimeStart
        {
            get
            {
                TimeSpan time = (DateTime)StartTime - DateTime.Now;
                DateTime time1 = (DateTime)StartTime;
                return $"Начало в {time1.ToString("F")}.  осталось: {time.ToString(@"dd")} дней {time.ToString(@"hh")} ч {time.ToString(@"mm")} мин.";
            }
        }

        public string ColorRed
        {
            get
            {
                if (StartTime - DateTime.Now < TimeSpan.FromHours(1))
                {
                    return "red";
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
