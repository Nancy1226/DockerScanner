using DockerfileScanner.Domain.Models;

namespace DockerfileScanner.Domain.Parsing;

public class DockerfileParser
{
    public List<DockerInstruction> Parse(string content)
    {
        var instructions = new List<DockerInstruction>();

        var lines = content.Split('\n');
        for(int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            int lineNumber = i + 1;

            if(string.IsNullOrWhiteSpace(line))
            {
                continue;
            }
            
            var spaceIndex = line.IndexOf(' ');

            if (spaceIndex != -1)
            {
                var instruction = line.Substring(0, spaceIndex);
                var arguments = line.Substring(spaceIndex + 1);

                var dockerInstruction = new DockerInstruction
                {
                    LineNumber = lineNumber,
                    Instruction = instruction,
                    Arguments = arguments,
                    RawText = line
                };
                
                instructions.Add(dockerInstruction);

            }
        }

        return instructions;
    }

}