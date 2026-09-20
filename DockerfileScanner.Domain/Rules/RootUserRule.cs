using DockerfileScanner.Domain.Enums;
using DockerfileScanner.Domain.Models;

namespace DockerfileScanner.Domain.Rules;

public class RootUserRule
{
    public Finding? Analyze(DockerInstruction instruction)
    {
        if (instruction.Instruction == "USER" &&
            instruction.Arguments == "root")
        {
            return new Finding
            {
                RuleId = "DF001",
                Title = "Container running as root",
                Severity = Severity.High,
                LineNumber = instruction.LineNumber,
                AffectedCode = instruction.RawText,
                Description = "El contenedor está configurado para ejecutarse como usuario root.",
                Recommendation = "Utiliza un usuario sin privilegios para ejecutar el contenedor."
            };
        }

        return null;
    }
}