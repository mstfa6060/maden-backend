namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Commands.Update;

public class Handler : IRequestHandler
{
	private readonly DataAccess _dataAccessLayer;

	public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
	{
		_dataAccessLayer = (DataAccess)dataAccess;
	}

	public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		var request = (RequestModel)payload;
		var mapper = new Mapper();

		var job = await _dataAccessLayer.GetById(request.JobId);
		if (job is null)
			throw new ArfBlocksValidationException("İş ilanı bulunamadı.");

		mapper.MapToExistingEntity(job, request);

		await _dataAccessLayer.Update(job);

		return ArfBlocksResults.Success(new ResponseModel { Id = job.Id });
	}
}
