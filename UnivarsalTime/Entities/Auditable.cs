namespace UnivarsalTime.Entities;

public class Auditable
{
    public string CreatedBy { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string ModifiedBy { get; set; }
    public DateTimeOffset ModifiedAt { get; set; }
}
