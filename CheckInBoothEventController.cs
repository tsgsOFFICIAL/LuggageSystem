using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuggageSystem
{
    /// <summary>
    /// This class handles the communition of events from CheckInBoothEventArgs to all observants
    /// </summary>
    public class CheckInBoothEventController
    {
        public event EventHandler StateChanged; // Event
        /// <summary>
        /// 
        /// </summary>
        public CheckInBoothEventController()
        {
            // Starts a thread that runs in the background
            new Thread(ReadState).Start();
        }
        //Aflæs temperaturen
        public void ReadState()
        {
            //Dette er en task. En task i C# svarer til en tråd men med lidt højere abstraktionsniveau
            while (true)
            {
                //Der sendes kun beskeder ud, hvis der er en ændring
                if (State != currentTemperature)
                {
                    //sæt den nye temperatur
                    currentTemperature = t;

                    //Send besked afsted til alle dem der lytter
                    //Bemærk at ? gør at vores "lyttere" godt kan være null, men vi får ingen fejl hvis det sker
                    //Invoke er en del af Reflections API'et der giver os mulighed for at invoke en bestemt metode
                    //This er - dette objekt og IKKE klassen
                    // new TemperatureEventArgs er dette objekt der sendes til at "observables"
                    StateChanged?.Invoke(this, new CheckInBoothEventArgs(IOpenClosed.State.Open));

                }
                //Vi lader tråden sove 2 sekunder
                Thread.Sleep(2000);
            }
        }

    }
}
