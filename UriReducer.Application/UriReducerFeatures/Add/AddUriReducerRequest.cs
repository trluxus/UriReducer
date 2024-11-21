using MediatR;

namespace UriReducer.Application.UriReducerFeatures.Add;

public sealed record AddUriReducerRequest(string LongUri) : IRequest<AddUriReducerResponse>;
