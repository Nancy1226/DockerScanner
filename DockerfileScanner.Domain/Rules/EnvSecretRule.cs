using DockerfileScanner.Domain.Models;

namespace DockerfileScanner.Domain.Rules;

public class EnvSecretRule : IDockerfileRule
{
    public Finding? Analyze(DockerInstruction instruction)
    {
        return null;
    }
}