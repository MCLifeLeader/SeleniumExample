namespace AutomationExample.Web.Model;

public class WeatherData
{
    public DateTime Date { get; set; }
    public int TempratureC { get; set; }
    public float WindSpeed { get; set; }

    private float _windDirection = 0;
    public float WindDirection
    {
        get => _windDirection;
        set
        {
            if (value >= 0 && value <= 360)
            {
                _windDirection = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(WindDirection), "Valid values are from 0 to 360");
            }
        }
    }

    public string? Summary { get; set; }
}