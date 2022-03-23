// See https://aka.ms/new-console-template for more informationus
var customDate = DateTime.Now.AddDays(+1);
DateTime reconDate = customDate.AddDays(-1);

checkHolidays(reconDate.ToString("yyyy-MM-dd"), -1, reconDate.ToString("yyyy-MM-dd"));

static int checkHolidays(string reconDate, int diff , string value)
{

    var dayOfWeek = DateTime.Now.DayOfWeek;  
    if(dayOfWeek.ToString() == "Monday") { return -3;}

    bool dateHolidays = isHoliday(value);
    if(dateHolidays == false)
    {
        Console.WriteLine("bukan hari libur " + diff);
        return diff;

    }else{

        DateTime dateNow     = DateTime.Now.AddDays(+1);
        TimeSpan totalDays   = DateTime.Now.AddDays(+1) - Convert.ToDateTime(getDate(value));
        int totalDiff   = -totalDays.Days;
        var newDate     = Convert.ToDateTime(reconDate).AddDays(totalDiff);
        
        Console.WriteLine("hari libur " + totalDiff);
        return checkHolidays(reconDate, totalDiff , newDate.ToString("yyyy-MM-dd"));
       
    }

    
    
}
static bool isHoliday(string value)
{
        var dateEvent = new List<string>{
            "2022-03-20",
            "2022-03-18",
            "2022-03-23",
            "2022-03-22",
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
        "2022-03-22"
    };
        
    var dateHolidays = dateEvent.Where(x => 
                    x.Contains(value)).FirstOrDefault();
    return dateHolidays == null?  value: dateHolidays;

}

