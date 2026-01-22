namespace GeoService.Application.Exceptions;

public class HandledException(string title, string message) : Exception(message)
{
    public string Title => title;
}