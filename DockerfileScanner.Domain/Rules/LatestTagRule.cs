using DockerfileScanner.Domain.Enums;
using DockerfileScanner.Domain.Models;

namespace DockerfileScanner.Domain.Rules;

public class LatestTagRule : IDockerfileRule
{
    public Finding? Analyze(DockerInstruction instruction)
    {
        if (instruction.Instruction == "FROM" &&
            instruction.Arguments.EndsWith(":latest"))
        {
            return new Finding
            {
                RuleId = "DF002",
                Title = "Using latest tag",
                Severity = Severity.High,
                LineNumber = instruction.LineNumber,
                AffectedCode = instruction.RawText,
                Description = "El contenedor utiliza la etiqueta 'latest' en la instrucción FROM.",
                Recommendation = "Utiliza una etiqueta de versión específica en la instrucción FROM."
            };
        }

        return null;
    }
}