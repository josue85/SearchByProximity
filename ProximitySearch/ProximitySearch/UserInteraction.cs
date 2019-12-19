using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    //Define how to interact with the end user. This gives us some flexibility if we move from being a console app, to a full fledged GUI
    interface UserInteraction
    {
        void Message(string message);
    }
}
