using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ForTest.Core.Service.Log;

namespace ForTest.Core.Service.Track
{
    public class TrackService : ITrackService
    {
        public void TrackEvents(List<string> events)
        {
            var request = HttpContext.Current.Request;

            var path = HttpContext.Current.ApplicationInstance.Server.MapPath("~/app_data") + "/TrackEvent/";

            var info = new DirectoryInfo(path);

            if (!info.Exists)
                info.Create();

            var fileName = string.Format("track_event_{0}.txt", DateTime.Now.ToString("ddMMyyyy"));

            Logging.Log.Info(string.Format(" Event {2} by {0}. User agent - {1}", request.UserHostAddress, request.UserAgent, events.Aggregate((fstring, sstring) => fstring + ", " + sstring).Trim(' ', ',')));
        }
    }
}
