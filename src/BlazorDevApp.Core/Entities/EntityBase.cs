namespace BlazorDevApp.Core.Entities;
public abstract class EntityBase
{
    protected EntityBase()
    {
        CreatedOn = DateTimeOffset.UtcNow;
    }

    public virtual int Id { get; protected set; }
    public virtual DateTimeOffset CreatedOn { get; protected set; }
    public virtual DateTimeOffset? UpdatedOn { get; protected set; }

    protected void Update()
    {
        UpdatedOn = DateTimeOffset.UtcNow;
    }
}
