using System;
using System.Collections;
using System.Net;
using Newtonsoft.Json;

namespace HolidayCalendar;
public class HolidayCalendar : IHolidayCalendar
{
    //opretter en liste for min model
    List<HolidayModel> Holidays { get; set; }

    /// <summary>
    /// laver en constructor med min list og indsætter værdier
    /// </summary>
    public HolidayCalendar()
    {
        //istantiere min List
        Holidays = new List<HolidayModel>();

        //indsætter min data i List
        InitializeComponent();
    }

    /// <summary>
    /// laver en metode for at sætte dataen ind i min HolidayModel
    /// </summary>
    /// <returns></returns>
    public void InitializeComponent()
    {
        //laver en variable for min url
        var url = "https://api.sallinggroup.com/v1/holidays?startDate=2022-01-01";

        //laver en webrequest
        var httpRequest = (HttpWebRequest)WebRequest.Create(url);

        //forberedelser til min request
        httpRequest.Headers["Authorization"] = "Bearer e6e63e55-a807-42ec-88a3-d3c7181db9bb";

        //laver min request
        var httpResponse = (HttpWebResponse)httpRequest.GetResponse();

        //læser min request
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            //læser filen til slut
            var result = streamReader.ReadToEnd();

            //converter min JSON fil til List
            Holidays = JsonConvert.DeserializeObject<List<HolidayModel>>(result);
        }
    }

    /// <summary>
    /// Tjekker min liste igennem for date og om den date er holiday date
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public bool IsHoliday(DateTime date)
    {
        //tjekker i min list om den er ens med date.
        return Holidays.Any(h => h.Date == date);
    }

    /// <summary>
    /// Jeg laver en ny list af HolidayModel som indeholde det rigtige sæt af data
    /// Laver så en list der kan convert til det rigtige format sådan så jeg kan returne
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    public ICollection<DateTime> GetHolidays(DateTime startDate, DateTime endDate)
    {
        //laver min liste for holiday start til slut datoer
        List<HolidayModel> easterHolidayDateTime = new();

        //tilføjer dem til min liste som er i mellem startdate og slutdate samt hvis nationalholiday er = true
        easterHolidayDateTime.AddRange(Holidays.Where(x => x.Date > startDate && x.Date < endDate && x.Nationalholiday == true));

        //laver en list af DateTime. Som skal returneres
        List<DateTime> easterHolidayDateTime2 = new();

        //convter national holiday sådan så jeg kan return
        easterHolidayDateTime2.AddRange(easterHolidayDateTime.ConvertAll(x => x.Date));

        return easterHolidayDateTime2;
    }
}

