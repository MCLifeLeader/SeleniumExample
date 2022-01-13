namespace AutomationExample.WebApi.Model;

public class Result<T>
{
    public string Notice { get; set; } = "This project can be used to simulate a project or product application. " +
                                         "Use the existing elements for validating your RESTful automation tests " +
                                         "or add additional ones and experiment with them.";

    public T? Data { get; set; }
}