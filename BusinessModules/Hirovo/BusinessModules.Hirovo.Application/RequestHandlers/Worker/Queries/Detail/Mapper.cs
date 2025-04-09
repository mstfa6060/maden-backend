namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Queries.Detail;

public class Mapper
{
    public ResponseModel MapToResponse(Job job)
    {
        return new ResponseModel()
        {
            Id = job.Id,
            Title = job.Title,
            Description = job.Description,
            Salary = job.Salary,
            Type = job.Type,
            Status = job.Status,
            EmployerId = job.EmployerId
        };
    }
}
