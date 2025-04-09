namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Commands.Delete;

public class Handler : IRequestHandler
{
	private readonly DataAccess _dataAccessLayer;

	public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
	{
		_dataAccessLayer = (DataAccess)dataAccess;
	}

	public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		var mapper = new Mapper();
		var request = (RequestModel)payload;

		var job = await _dataAccessLayer.GetJobById(request.JobId);
		if (job == null)
			throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.JobErrors.JobNotFound));

		job.IsDeleted = request.IsDeleted;
		await _dataAccessLayer.UpdateJob(job);

		var response = mapper.MapToResponse(job);
		return ArfBlocksResults.Success(response);
	}
}
