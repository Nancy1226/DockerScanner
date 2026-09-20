using DockerfileScanner.Domain.Models;
using DockerfileScanner.Domain.Parsing;
using DockerfileScanner.Domain.Rules;

namespace DockerfileScanner.Application.Services;

public class DockerfileScannerService
{
    private readonly DockerfileParser _parser;
    private readonly IEnumerable<IDockerfileRule> _rules;
    public DockerfileScannerService(
        DockerfileParser parser,
        IEnumerable<IDockerfileRule> rules)
    {
        _parser = parser;
        _rules = rules;
    }

    public List<Finding> Scan(string content)
    {
        var instructions = _parser.Parse(content);

        var findings = new List<Finding>();

        foreach (var instruction in instructions)
        {
            foreach (var rule in _rules)
            {
                var finding = rule.Analyze(instruction);
                if (finding != null)
                {
                    findings.Add(finding);
                }
            }
        }

        return findings;
    }
}