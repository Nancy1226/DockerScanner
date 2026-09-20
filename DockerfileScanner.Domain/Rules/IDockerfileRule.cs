using DockerfileScanner.Domain.Models;

namespace DockerfileScanner.Domain.Rules;

public interface IDockerfileRule
{
    Finding? Analyze(DockerInstruction instruction);
}