using DockerfileScanner.Application.Services;
using Microsoft.AspNetCore.Mvc;
using DockerfileScanner.Api.Requests;

namespace DockerfileScanner.Api.Controllers;

[ApiController]
[Route("api/scan")]
public class ScanController : ControllerBase
{
    private readonly DockerfileScannerService _scannerService;

    public ScanController(DockerfileScannerService scannerService)
    {
        _scannerService = scannerService;
    }

    [HttpPost]
    public IActionResult Scan([FromBody] ScanDockerfileRequest request)
    {
        var result = _scannerService.Scan(request.Content);

        return Ok(result);
    }
}