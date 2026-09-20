using DockerfileScanner.Domain.Models;

namespace DockerfileScanner.Domain.Parsing;

public class DockerfileParser
{
    public List<DockerInstruction> Parse(string content)
    {
        var instructions = new List<DockerInstruction>();

        var lines = content.Split('\n');

        var currentInstruction = "";
        var startLineNumber = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            int lineNumber = i + 1;

            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            var trimmedLine = line.Trim();

            if (trimmedLine.StartsWith("#"))
            {
                continue;
            }

            // 1. La instrucción continúa en la siguiente línea
            if (trimmedLine.EndsWith("\\"))
            {
                if (string.IsNullOrEmpty(currentInstruction))
                {
                    startLineNumber = lineNumber;
                }

                currentInstruction += trimmedLine
                    .Substring(0, trimmedLine.Length - 1)
                    .Trim() + " ";

                continue;
            }

            // 2. Estamos terminando una instrucción multilínea
            if (!string.IsNullOrEmpty(currentInstruction))
            {
                currentInstruction += trimmedLine;

                trimmedLine = currentInstruction.Trim();

                lineNumber = startLineNumber;

                currentInstruction = "";
                startLineNumber = 0;
            }

            // 3. Buscar dónde termina Instruction y empiezan Arguments
            var separatorIndex = -1;

            for (int j = 0; j < trimmedLine.Length; j++)
            {
                if (char.IsWhiteSpace(trimmedLine[j]))
                {
                    separatorIndex = j;
                    break;
                }
            }

            if (separatorIndex != -1)
            {
                var instruction = trimmedLine
                    .Substring(0, separatorIndex)
                    .Trim();

                var arguments = trimmedLine
                    .Substring(separatorIndex + 1)
                    .Trim();

                var dockerInstruction = new DockerInstruction
                {
                    LineNumber = lineNumber,
                    Instruction = instruction,
                    Arguments = arguments,
                    RawText = trimmedLine
                };

                instructions.Add(dockerInstruction);
            }
        }

        return instructions;
    }
}