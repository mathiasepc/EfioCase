using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayCalendar
{
    /// <summary>
    /// laver model som indeholder dataen.
    /// </summary>
    internal class HolidayModel
    {
        public bool Nationalholiday { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
