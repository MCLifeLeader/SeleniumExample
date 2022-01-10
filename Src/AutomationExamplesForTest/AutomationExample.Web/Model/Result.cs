namespace AutomationExample.Web.Model;

public class Result<T>
{
    public string Notice { get; set; } = "This Web Api application is a template for Unit Test development.";

    public T? Data { get; set; }
}