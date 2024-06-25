namespace CometeAPI.Domain.models;

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
}