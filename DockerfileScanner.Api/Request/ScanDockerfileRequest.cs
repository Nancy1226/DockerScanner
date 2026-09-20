namespace DockerfileScanner.Api.Requests;

public class ScanDockerfileRequest
{
    public required string Content { get; set; }
}