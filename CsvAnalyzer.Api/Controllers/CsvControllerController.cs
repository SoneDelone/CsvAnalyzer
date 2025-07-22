using CsvAnalyzer.Api.Common.Errors;
using CsvAnalyzer.Api.Extensions;
using CsvAnalyzer.Application.Common.FilesModel;
using CsvAnalyzer.Application.Service;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CsvAnalyzer.Api.Controllers;

[AllowAnonymous]
[Route("csv")]
public class CsvControllerController(CsvService _csvService,
                                     IMapper _mapper) : ApiController
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
    [HttpPost("filter")]
    public async Task<IActionResult> FilterCsv([FromQuery] CsvFilterParams filter)
    {
        var processResult = await _csvService.getFilteredReuslts(filter);

        return processResult.Match(
            res => Ok(res.Adapt<ResultsDTO[]>()),
            errors => Problem(errors));
    }

    [HttpPost("last")]
    public async Task<IActionResult> LastValuesCvs([FromQuery] string name)
    {
        var processResult = await _csvService.getLastResultsByName(name);

        return processResult.Match(
            res => Ok(res.Adapt<ResultsDTO[]>()),
            errors => Problem(errors));
    }
}