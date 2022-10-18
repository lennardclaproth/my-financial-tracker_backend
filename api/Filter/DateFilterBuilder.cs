namespace MyFinancialTracker.api.Filter;


public static class DateFilterTypes{
    // public static readonly string YTD = "YTD";
    public const string YTD = "YTD";
    public const string W = "1W";
    public const string M = "1M";
    public const string Y = "1Y";  
    public const string MAX = "MAX";
}

public class DateFilter {
    public DateTime? dateStart {get; set;}
    public DateTime dateEnd {get; set;}
}

public class DateFilterBuilder {
    public static DateFilter build(string filter){
        switch(filter){
            case DateFilterTypes.YTD:
                return DateFilterBuilder.buildYTD();
            case DateFilterTypes.MAX:
                return DateFilterBuilder.buildMAX();
            default:
                return DateFilterBuilder.buildMAX();
        }
    }

    public static DateFilter buildYTD(){
        DateFilter dateFilter = new DateFilter();
        dateFilter.dateStart = new DateTime(DateTime.Now.Year, 1, 1);
        dateFilter.dateEnd = DateTime.Now;
        return dateFilter;
    }

    public static DateFilter buildMAX(){
        DateFilter dateFilter = new DateFilter();
        dateFilter.dateStart = DateTime.MinValue;
        dateFilter.dateEnd = DateTime.Now;
        return dateFilter;
    }
}