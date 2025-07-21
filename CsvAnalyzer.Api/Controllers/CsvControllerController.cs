using CsvAnalyzer.Api.Extensions;
using CsvAnalyzer.Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CsvAnalyzer.Api.Controllers;

[AllowAnonymous]
[Route("csv")]
public class CsvControllerController(CsvService _csvService) : ApiController
{
    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadCsv(IFormFile file)
    {
        if (file is null || file.Length == 0)
            return BadRequest("File is empty or not provided.");

        if (!Path.GetExtension(file.FileName).IsAllowedExtension())
            return BadRequest("File type is not allowed");

        using var stream = file.OpenReadStream();
        var processCsvResult = await _csvService.ProccessCsvAsync(stream);

        return processCsvResult.Match(
            res => Ok(),
            errors => Problem(errors));
    }
    [HttpPost("process")]
    public async Task<IActionResult> ProcessCsv([FromQuery] string? fileName = null,
                                                [FromQuery] DateTime? minStartTime = null,
                                                [FromQuery] DateTime? maxStartTime = null,
                                                [FromQuery] double? minAverageValue = null,
                                                [FromQuery] double? maxAverageValue = null,
                                                [FromQuery] double? minAverageExecutionTime = null,
                                                [FromQuery] double? maxAverageExecutionTime = null)
    {

        return Ok("Processing not implemented yet.");
    }
}