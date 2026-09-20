namespace DockerfileScanner.Domain.Models;
using DockerfileScanner.Domain.Enums;

public class Finding
{
    public required string RuleId { get;set; }
    public required string Title { get; set; }
    public Severity Severity { get; set; }
    public int LineNumber { get; set; }
    public required string AffectedCode { get; set; }
    public required string Description { get; set; }
    public required string Recommendation { get; set; }
}