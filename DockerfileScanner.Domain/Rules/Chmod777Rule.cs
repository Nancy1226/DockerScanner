using DockerfileScanner.Domain.Enums;
using DockerfileScanner.Domain.Models;

namespace DockerfileScanner.Domain.Rules;

public class Chmod777Rule : IDockerfileRule
{
    public Finding? Analyze(DockerInstruction instruction)
    {
        if (instruction.Instruction == "RUN" &&
            instruction.Arguments.Contains("chmod 777"))
        {
            return new Finding
            {
                RuleId = "DF003",
                Title = "Use of chmod 777",
                Severity = Severity.High,
                LineNumber = instruction.LineNumber,
                AffectedCode = instruction.RawText,
                Description = "El uso de chmod 777 otorga permisos de lectura, escritura y ejecución a todos los usuarios, lo que puede dar lugar a vulnerabilidades de seguridad.",
                Recommendation = "Evita usar chmod 777. En su lugar, establece permisos más restrictivos que solo permitan el acceso necesario."
            };
        }

        return null;
    }
}