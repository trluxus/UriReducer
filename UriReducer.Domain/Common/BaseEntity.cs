namespace UriReducer.Domain.Common;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime CreatedOnUtc { get; set; }

    public DateTime DeletedOnUtc { get; set; }

    public bool IsDeleted { get; set; } = false;
}
