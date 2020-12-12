using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynchDbWithGoogleAgenda
{
    class Program
    {
        

        static void Main(string[] args)
        {
            TimeZoneInfo timezoneinfo = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            String calendarid = "Sunshine";
            String serviceaccountemail = "50533605746-f2uperl82pt6dhf387f5v4incihrchng@developer.gserviceaccount.com";
            String applicationname = "Sunshine Calendar";

            string serviceAccountEmail = serviceaccountemail;
            string[] scopes = new string[] { CalendarService.Scope.Calendar };


            var certificate = new X509Certificate2(@"C:\Users\andre\Downloads\Sunshine Calendar-9788c08de220.p12", "notasecret", X509KeyStorageFlags.Exportable);

            ServiceAccountCredential.Initializer initializer = new ServiceAccountCredential.Initializer(serviceaccountemail)
            {
                // User = "andre.mulder@gmail.com",
                Scopes = scopes
            }.FromCertificate(certificate);
            ServiceAccountCredential credential = new ServiceAccountCredential(initializer);


            // Create the service.
            var service = new CalendarService(new CalendarService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationname
            });
            

            CalendarList calendarlist = service.CalendarList.List().Execute();

            EventsResource.ListRequest request = null;

            foreach (CalendarListEntry cal in calendarlist.Items)
            {
                if (cal.Summary == calendarid)
                {
                    request = service.Events.List(cal.Id);

                }
            }

            IList<Event> events = request.Execute().Items;

            foreach(Event e in events) {

                Console.Write(e.Id);
    
            }
            Console.ReadLine();
            
                
            
            
        }
    }
}
