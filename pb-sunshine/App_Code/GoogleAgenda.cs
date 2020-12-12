using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Util.Store;
using System.Security.Cryptography.X509Certificates;
using System.Net.Mail;
using System.IO;
using Google.Apis.Services;

/// <summary>
/// Summary description for GoogleAgenda
/// </summary>
public class GoogleAgenda 
{
    
    TimeZoneInfo timezoneinfo = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
    String calendarname;
    String calendarId;
    String serviceaccountemail = "songbird@pure-hydra-786.iam.gserviceaccount.com";
    String applicationname = "Sunshine";
    

	public GoogleAgenda(string calendarName)
	{
        if (calendarName == "Sunshine")
        {
            calendarId = "pfd60vq5ahf007fhiv8g6b2jsg@group.calendar.google.com";
        }
        if (calendarName == "KleintjeSunshine")
        {
            calendarId = "arbpt32ml6olgf4o14bj8sk29o@group.calendar.google.com";
        }

    }

    private CalendarService GAuthenticate()
    {
        string serviceAccountCredentialFilePath = @"h:\root\home\pbsunshi-001\www\db\credentials.json";
        string[] scopes = new string[] { CalendarService.Scope.Calendar };
        GoogleCredential credential;
        using (var stream = new FileStream(serviceAccountCredentialFilePath, FileMode.Open, FileAccess.Read))
        {
            credential = GoogleCredential.FromStream(stream)
                             .CreateScoped(scopes);
        }

        // Create the Calendar service.
        var service = new CalendarService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "Sunshine",
        });

        return service;
        
    }

    public string CreateEvent(string title,string content,string location,DateTime datumstart, DateTime datumeind)
    {
        

        //Set Event Entry 
        Event afspraak = new Event();
        afspraak.Summary = title;
        afspraak.Description = content;
        

        //Set Event Location 
        afspraak.Location = location;
        
        //Set Event Time

        DateTime afspraakStartDateTime = new DateTime(datumstart.Year, datumstart.Month, datumstart.Day, datumstart.Hour, datumstart.Minute, datumstart.Second);
        DateTime afspraakEndDateTime = new DateTime(datumeind.Year, datumeind.Month, datumeind.Day, datumeind.Hour, datumeind.Minute, datumeind.Second);

        string afspraakStartJaar = afspraakStartDateTime.Year.ToString();
        string afspraakStartMaand = afspraakStartDateTime.Month.ToString("00");
        string afspraakStartDag = afspraakStartDateTime.Day.ToString("00");

        string afspraakStartUur = afspraakStartDateTime.Hour.ToString("00");
        string afspraakStartMinuut = afspraakStartDateTime.Minute.ToString("00");
        string afspraakStartSecond = afspraakStartDateTime.Second.ToString("00");

        string afspraakStartRawString = afspraakStartJaar + "-" + afspraakStartMaand + "-" + afspraakStartDag + "T" + afspraakStartUur + ":" + afspraakStartMinuut + ":" + afspraakStartSecond;

        string afspraakEndJaar = afspraakEndDateTime.Year.ToString();
        string afspraakEndMaand = afspraakEndDateTime.Month.ToString("00");
        string afspraakEndDag = afspraakEndDateTime.Day.ToString("00");

        string afspraakEndUur = afspraakEndDateTime.Hour.ToString("00");
        string afspraakEndMinuut = afspraakEndDateTime.Minute.ToString("00");
        string afspraakEndSecond = afspraakEndDateTime.Second.ToString("00");

        string afspraakEndRawString = afspraakEndJaar + "-" + afspraakEndMaand + "-" + afspraakEndDag + "T" + afspraakEndUur + ":" + afspraakEndMinuut + ":" + afspraakEndSecond;

        
        afspraak.Start = new EventDateTime() {
            // DateTime = afspraakStartDateTime
            TimeZone = "Europe/Amsterdam",
            DateTimeRaw = afspraakStartRawString
        };

        afspraak.End = new EventDateTime() {
            // DateTime = afspraakEndDateTime
            TimeZone = "Europe/Amsterdam",
            DateTimeRaw = afspraakEndRawString
        };
        

        CalendarService service = GAuthenticate();

        afspraak = service.Events.Insert(afspraak, calendarId).Execute();
        
        return afspraak.Id;
    }

    public void UpdateEvent(string title, string content, string location, DateTime datumstart, DateTime datumeind, string googleAgendaSynchId)
    {       

        CalendarService service = GAuthenticate();

        //Search for Event

        
        Event afspraak = service.Events.Get(calendarId, googleAgendaSynchId).Execute();
                
                        
        //Update Related Events

        afspraak.Summary = title;
        afspraak.Description = content;
        afspraak.Location = location;

        DateTime afspraakStartDateTime = new DateTime(datumstart.Year, datumstart.Month, datumstart.Day, datumstart.Hour, datumstart.Minute, datumstart.Second);
        DateTime afspraakEndDateTime = new DateTime(datumeind.Year, datumeind.Month, datumeind.Day, datumeind.Hour, datumeind.Minute, datumeind.Second);

        string afspraakStartJaar = afspraakStartDateTime.Year.ToString();
        string afspraakStartMaand = afspraakStartDateTime.Month.ToString("00");
        string afspraakStartDag = afspraakStartDateTime.Day.ToString("00");

        string afspraakStartUur = afspraakStartDateTime.Hour.ToString("00");
        string afspraakStartMinuut = afspraakStartDateTime.Minute.ToString("00");
        string afspraakStartSecond = afspraakStartDateTime.Second.ToString("00");

        string afspraakStartRawString = afspraakStartJaar + "-" + afspraakStartMaand + "-" + afspraakStartDag + "T" + afspraakStartUur + ":" + afspraakStartMinuut + ":" + afspraakStartSecond;

        string afspraakEndJaar = afspraakEndDateTime.Year.ToString();
        string afspraakEndMaand = afspraakEndDateTime.Month.ToString("00");
        string afspraakEndDag = afspraakEndDateTime.Day.ToString("00");

        string afspraakEndUur = afspraakEndDateTime.Hour.ToString("00");
        string afspraakEndMinuut = afspraakEndDateTime.Minute.ToString("00");
        string afspraakEndSecond = afspraakEndDateTime.Second.ToString("00");

        string afspraakEndRawString = afspraakEndJaar + "-" + afspraakEndMaand + "-" + afspraakEndDag + "T" + afspraakEndUur + ":" + afspraakEndMinuut + ":" + afspraakEndSecond;


        afspraak.Start = new EventDateTime()
        {
            // DateTime = afspraakStartDateTime
            TimeZone = "Europe/Amsterdam",
            DateTimeRaw = afspraakStartRawString
        };

        afspraak.End = new EventDateTime()
        {
            // DateTime = afspraakEndDateTime
            TimeZone = "Europe/Amsterdam",
            DateTimeRaw = afspraakEndRawString
        };

       

        afspraak = service.Events.Update(afspraak, calendarId, afspraak.Id).Execute();
        
    }

    public void DeleteEvent(string googleAgendaSynchId)
    {
        CalendarService service = GAuthenticate();

        //Search for Event
        
        String deleteafspraak = service.Events.Delete(calendarId, googleAgendaSynchId).Execute();

    }

}