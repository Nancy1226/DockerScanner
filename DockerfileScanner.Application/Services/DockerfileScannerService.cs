using DockerfileScanner.Domain.Models;
using DockerfileScanner.Domain.Parsing;
using DockerfileScanner.Domain.Rules;

namespace DockerfileScanner.Application.Services;

public class DockerfileScannerService
{
    private readonly DockerfileParser _parser;
    private readonly RootUserRule _rootUserRule;

    public DockerfileScannerService(
        DockerfileParser parser,
        RootUserRule rootUserRule)
    {
        _parser = parser;
        _rootUserRule = rootUserRule;
    }

    public List<Finding> Scan(string content)
    {
        var instructions = _parser.Parse(content);

        var findings = new List<Finding>();

        foreach (var instruction in instructions)
        {
            var finding = _rootUserRule.Analyze(instruction);
            if (finding != null)
            {
                findings.Add(finding);
            }
        }

        return findings;
    }
}