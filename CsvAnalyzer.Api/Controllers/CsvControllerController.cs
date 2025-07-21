using CsvAnalyzer.Api.Common.Errors;
using CsvAnalyzer.Api.Extensions;
using CsvAnalyzer.Application.Common.FilesModel;
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
            return Problem(CsvControllerErrors.FileIsEmptyOrMissing);

        if (!Path.GetExtension(file.FileName).IsAllowedExtension())
            return Problem(CsvControllerErrors.FileExtensionNotAllowed);

        using var stream = file.OpenReadStream();
        var processCsvResult = await _csvService.ProccessCsvAsync(stream, file.FileName);

        return processCsvResult.Match(
            res => Ok(),
            errors => Problem(errors));
    }
    [HttpPost("process")]
    public async Task<IActionResult> ProcessCsv([FromQuery] CsvFilterParams filter)
    {

        return Ok("Processing not implemented yet.");
    }
}