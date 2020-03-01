using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTest.Core.Service.Track
{
    public interface ITrackService
    {
        void TrackEvents(List<string> events);
    }
}
