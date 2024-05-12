namespace Project.BL.Dtos.StatusCode;
public record StatusCodeDTO(statuscode Statuscode,string? message = "",object? data = null);

public enum statuscode
{
    BadRequest=400, NotFound=404,Created=201,Ok=200,NoContent =204
};