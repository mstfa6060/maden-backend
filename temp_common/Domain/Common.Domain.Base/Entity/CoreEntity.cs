namespace Common.Definitions.Base.Entity;
public abstract class CoreEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
