using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace OddCalculators.Services
{
    public interface ITimeService
    {
        DateTime GetNetworkTime();
    }


    public class TimeService : ITimeService
    {
        public DateTime WebTime { get; set; }

        public DateTime GetNetworkTime()
        {
            var client = new TcpClient("time.nist.gov", 13);
            using (var streamReader = new StreamReader(client.GetStream()))
            {
                var response = streamReader.ReadToEnd();
                var utcDateTimeString = response.Substring(7, 17);
                var localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                WebTime = localDateTime;
            }
            return WebTime;
        }

       
    }
}
