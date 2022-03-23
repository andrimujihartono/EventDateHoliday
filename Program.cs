// See https://aka.ms/new-console-template for more informationus
var customDate = DateTime.Now.AddDays(+1);
DateTime reconDate = customDate.AddDays(-1);

int countDay = checkHolidays(reconDate.ToString("yyyy-MM-dd"), -1, reconDate.ToString("yyyy-MM-dd"));
Console.WriteLine(reconDate.AddDays(countDay));
static int checkHolidays(string reconDate, int diff , string value)
{

    var dayOfWeek = DateTime.Now.DayOfWeek;
    var dayOfWeekEnd = Convert.ToDateTime(value).DayOfWeek;

    if(dayOfWeek.ToString() == "Monday") { return -3;}

    bool dateHolidays = isHoliday(value);
    if(dateHolidays == false && dayOfWeekEnd.ToString() != "Sunday" && dayOfWeekEnd.ToString() != "Saturday")
    {
        Console.WriteLine("bukan hari libur " + value);
        return diff;

    }else{

        TimeSpan totalDays   = DateTime.Now.AddDays(+1) - Convert.ToDateTime(value);
        diff   = -totalDays.Days;
        var newDate     = Convert.ToDateTime(reconDate).AddDays(diff);
        
        Console.WriteLine("hari libur " +  diff);
        return checkHolidays(reconDate, diff , newDate.ToString("yyyy-MM-dd"));
       
    }

    
    
}
static bool isHoliday(string value)
{
        var dateEvent = new List<string>{
            "2022-03-23",
            "2022-03-22",
            "2022-03-21",
        };
        var dateHolidays = dateEvent.Where(x => 
                            x.Contains(value)).FirstOrDefault();

        return dateHolidays == null ? false : true;
}
static string getDate(string value){
    var dateEvent = new List<string>{
        "2022-03-17",
        "2022-03-18",
        "2022-03-23",
        "2022-03-21"
    };
        
    var dateHolidays = dateEvent.Where(x => 
                    x.Contains(value)).FirstOrDefault();
    return dateHolidays == null?  value: dateHolidays;

}

