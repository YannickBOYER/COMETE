namespace CometeAPI.Domain.models;

[Serializable]
public class Report
{
    private long id;
    private string name;
    private string content;

    public Report(long id, string name, string content)
    {
        this.id = id;
        this.name = name;
        this.content = content;
    }

    public long Id { get { return id; } set { id = value; } }
    public string Name { get { return name; } set { name = value; } }
    public string Content { get { return content; } set { content = value; } }
}