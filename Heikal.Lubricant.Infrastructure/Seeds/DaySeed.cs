using Heikal.Lubricant.Core.Constant;
using Heikal.Lubricant.Core.Entities;
using Heikal.Lubricant.Infrastructure.Data;
using System.Linq;

namespace Heikal.Lubricant.Infrastructure.Seeds
{
    public class DaySeed
    {
        public static void DaysData(LubricantContext context)
        {
            if (context.Days.SingleOrDefault(day => day.DayName == ArabicDays.SATURDAY) == null) 
                context.Days.Add(new Days { DayName = ArabicDays.SATURDAY });

            if (context.Days.SingleOrDefault(day => day.DayName == ArabicDays.SUNDAY) == null)
                context.Days.Add(new Days { DayName = ArabicDays.SUNDAY });

            if (context.Days.SingleOrDefault(day => day.DayName == ArabicDays.MONDAY) == null)
                context.Days.Add(new Days { DayName = ArabicDays.MONDAY });

            if (context.Days.SingleOrDefault(day => day.DayName == ArabicDays.TUESDAY) == null)
                context.Days.Add(new Days { DayName = ArabicDays.TUESDAY });

            if (context.Days.SingleOrDefault(day => day.DayName == ArabicDays.WEDNESDAY) == null)
                context.Days.Add(new Days { DayName = ArabicDays.WEDNESDAY });

            if (context.Days.SingleOrDefault(day => day.DayName == ArabicDays.THURESDAY) == null)
                context.Days.Add(new Days { DayName = ArabicDays.THURESDAY });

            if (context.Days.SingleOrDefault(day => day.DayName == ArabicDays.FRIDAY) == null)
                context.Days.Add(new Days { DayName = ArabicDays.FRIDAY });
        }
    }
}
