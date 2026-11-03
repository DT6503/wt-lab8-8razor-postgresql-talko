namespace wt_lab5_5razor_talko.Models;

public abstract class BaseEntity
{
    public int Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }

    protected BaseEntity()
    {
        CreatedAt = DateTime.Now;
    }

    protected BaseEntity(int id)
    {
        Id = id;
        CreatedAt = DateTime.Now;
    }

    public abstract void PrintInfo();
}