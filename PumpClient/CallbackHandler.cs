using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PumpClient.PumpServiceReference;

namespace PumpClient
{
    public class CallbackHandler : IPumpServiceCallback
    {
        public void UpdateStatistic(StatisticsService statistics)
        {
            Console.Clear();
            Console.WriteLine("Обновление по статистике выполнения скрипта");
            Console.WriteLine($"Всего     такотов: {statistics.AllTacts}");
            Console.WriteLine($"Успешных  такотов: {statistics.SuccessTacts}");
            Console.WriteLine($"Ошибочных такотов: {statistics.ErrorTacts}");
        }
    }
}
