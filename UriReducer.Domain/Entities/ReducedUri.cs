using UriReducer.Domain.Common;

namespace UriReducer.Domain.Entities;

public class ReducedUri : BaseEntity
{
    public string LongUri { get; set; } = string.Empty;

    public string ShortUri { get; set; } = string.Empty;

    public string UriCode { get; set; } = string.Empty;
}
