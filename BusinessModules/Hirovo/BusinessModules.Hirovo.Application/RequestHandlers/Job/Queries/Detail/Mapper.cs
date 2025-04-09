namespace BusinessModules.Hirovo.Application.RequestHandlers.Workers.Queries.Detail;

public class Mapper
{
    public ResponseModel MapToResponse(User user)
    {
        var responseModel = new ResponseModel()
        {
            Id = user.Id,
            PhoneNumber = user.PhoneNumber,
            BirthDate = user.BirthDate,
            City = user.City,
            District = user.District,
            IsAvailable = user.IsAvailable
        };

        return responseModel;
    }
}
