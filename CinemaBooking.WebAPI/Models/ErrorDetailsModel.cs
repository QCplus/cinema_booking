using System.Text.Json;
using FluentValidation.Results;

namespace CinemaBooking.WebAPI.Models;

public class ErrorDetailsModel
{
    public string? Message { get; set; }

    public KeyValuePair<string, string>[]? InvalidFields { get; set; }

    public ErrorDetailsModel()
    {

    }

    public ErrorDetailsModel(string message)
    {
        Message = message;
    }

    public ErrorDetailsModel(string message, KeyValuePair<string, string>[] invalidFields) : this(message)
    {
        InvalidFields = invalidFields;
    }

    public ErrorDetailsModel(KeyValuePair<string, string>[] invalidFields)
    {
        InvalidFields = invalidFields;
    }

    public ErrorDetailsModel(ValidationResult validationResult)
    {
        InvalidFields = validationResult.Errors
            .Select(e => new KeyValuePair<string, string>(e.PropertyName, e.ErrorMessage))
            .ToArray();
    }
}
