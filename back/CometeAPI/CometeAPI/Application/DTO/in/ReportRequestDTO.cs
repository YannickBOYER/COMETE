namespace CometeAPI.Application.DTO.@in;

public class ReportRequestDTO
{
    public long IdUtilisateur {  get; set; }
    public long IdFolder {  get; set; }
    public string? FileName {  get; set; }
    public string? Text { get; set; }
    public string? InstructionSupplementaire { get; set; }
}