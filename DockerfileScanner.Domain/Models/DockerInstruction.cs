namespace DockerfileScanner.Domain.Models;

public class DockerInstruction
{
    public int LineNumber { get; set; }

    public required string Instruction { get; set; }

    public required string Arguments { get; set; }

    public required string RawText { get; set; }
}