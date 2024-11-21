using MediatR;
using Microsoft.AspNetCore.Http;
using UriReducer.Application.Repository;
using UriReducer.Application.Repository.IUriReducerRepository;
using UriReducer.Application.Services;
using UriReducer.Domain.Entities;

namespace UriReducer.Application.UriReducerFeatures.Add
{
    public sealed class AddUriReducerHandler : IRequestHandler<AddUriReducerRequest, AddUriReducerResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUriReducerRepository uriReducerRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUriReducerService uriReducerService;

        public AddUriReducerHandler(IUnitOfWork unitOfWork,
            IUriReducerRepository uriReducerRepository,
            IHttpContextAccessor httpContextAccessor,
            IUriReducerService uriReducerService)
        {
            this.unitOfWork = unitOfWork;
            this.uriReducerRepository = uriReducerRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.uriReducerService = uriReducerService;
        }

        public async Task<AddUriReducerResponse> Handle(AddUriReducerRequest request,
            CancellationToken cancellationToken)
        {
            var uriCode = await uriReducerService.GenerateUniqueCode();

            var requestParams = httpContextAccessor.HttpContext?.Request;
            if(requestParams is null) {
                throw new ArgumentNullException(nameof(requestParams));
            }

            var shortUri = $"{requestParams.Scheme}://{requestParams.Host}/{uriCode}";

            ReducedUri reducedUri = new()
            {
                Id = Guid.NewGuid(),
                LongUri = request.LongUri,
                UriCode = uriCode,
                ShortUri = shortUri
            };
            uriReducerRepository.Create(reducedUri);
            await unitOfWork.Save(cancellationToken);

            return new(shortUri);
        }

    }
}
