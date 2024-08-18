public class PollenForecast
{
	public string RegionCode { get; set; }
	public List<DailyInfo> DailyInfo { get; set; }
}

public class DailyInfo
{
	public DateInfo Date { get; set; }
	public List<PollenTypeInfo> PollenTypeInfo { get; set; }
	public List<PlantInfo> PlantInfo { get; set; }
}

public class DateInfo
{
	public int Year { get; set; }
	public int Month { get; set; }
	public int Day { get; set; }
}

public class PollenTypeInfo
{
	public string Code { get; set; }
	public string DisplayName { get; set; }
}

public class PlantInfo
{
	public string Code { get; set; }
	public string DisplayName { get; set; }
}
