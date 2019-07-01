using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Hosting.Server;
using System.IO;
using Rikkei.PinkMind.DAO.Data;
using Rikkei.PindMind.DAO.Models;
using System.Security.Claims;
using Rikei.PinkMind.Business.ProjectFile.CreateFolder;
using MediatR;
using Rikei.PinkMind.Business.ProjectFile.GetAllFolder;

namespace Rikkei.PinkMind.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FileUploadController : ControllerBase
  {
    public readonly IServer _iServer;
    private readonly PinkMindContext _pmContext;
    private readonly ClaimsPrincipal _caller;
    private readonly IMediator _mediator;
    public FileUploadController(IMediator mediator, IServer iServer, PinkMindContext pmContext, IHttpContextAccessor httpContextAccessor)
    {
      _iServer = iServer;
      _pmContext = pmContext;
      _caller = httpContextAccessor.HttpContext.User;
      _mediator = mediator;
    }

    private string GetContentType(string path)
    {
      var types = GetMimeTypes();
      var ext = Path.GetExtension(path).ToLowerInvariant();
      return types[ext];
    }

    private Dictionary<string, string> GetMimeTypes()
    {
      return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},  
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
    }

    [HttpGet("{pathfolder}")]
    public async Task<IActionResult> GetFile(string pathfolder)
    {
      return Ok(await _mediator.Send(new GetAllFileQuery { path = pathfolder}));
    }

    [HttpPost("{path}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Upload(string path, string projectKey)
    {

      var userID = _caller.Claims.Single(u => u.Type == "id");
      //var userInfo = await _pmContext.Users.FindAsync(Convert.ToInt64(userID.Value));
      for (int i = 0; i < Request.Form.Files.Count; i++)
      {
        IFormFile file = Request.Form.Files[i]; //Uploaded file
        //Use the following properties to get file's name, size and MIMEType
        long fileSize = file.Length;
        string fileName = file.FileName;
        string mimeType = file.ContentType;
        Directory.CreateDirectory($"{path}");
        var filePath = Path.Combine($"{path}", fileName);
        Stream fileContent = file.OpenReadStream();
        //To save file, use SaveAs method
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
          await file.CopyToAsync(stream);
        }

        var entity = new ProjectFileUpload
        {
          FolderPath = $"/{path}",
          FilePath = file.FileName,
          FileSize = $"{fileSize} KB",
          TypeModel = "File",
          ImagePath = "Haha",
          CreateBy = Convert.ToInt64(userID.Value),
          CreateAt = DateTime.UtcNow,
          UpdateBy = Convert.ToInt64(userID.Value),
          LastUpdate = DateTime.Now,
          DelFlag = true,
          ProjectID = projectKey
        };
        _pmContext.ProjectFiles.Add(entity);
        _pmContext.SaveChanges();
      }

      return Ok("Uploaded " + Request.Form.Files.Count + " files");

    }

    [HttpPost("{pathissue}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadFileIssue(string pathissue)
    {

      //var userID = _caller.Claims.Single(u => u.Type == "id");
      //var userInfo = await _pmContext.Users.FindAsync(Convert.ToInt64(userID.Value));
      for (int i = 0; i < Request.Form.Files.Count; i++)
      {
        IFormFile file = Request.Form.Files[i]; //Uploaded file
        //Use the following properties to get file's name, size and MIMEType
        long fileSize = file.Length;
        string fileName = file.FileName;
        string mimeType = file.ContentType;
        Directory.CreateDirectory($"{pathissue}");
        var filePath = Path.Combine($"{pathissue}", fileName);
        Stream fileContent = file.OpenReadStream();
        //To save file, use SaveAs method
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
          await file.CopyToAsync(stream);
        }

      }

      return NoContent();
      //return Ok("Uploaded " + Request.Form.Files.Count + " files");
    }
    [HttpGet("{filename}")]
    public async Task<IActionResult> Download(string filename)
    {
      if (filename == null)
        return Content("filename not present");

      var path = Path.Combine(filename);

      var memory = new MemoryStream();
      using (var stream = new FileStream(path, FileMode.Open))
      {
        await stream.CopyToAsync(memory);
      }
      memory.Position = 0;
      return File(memory, GetContentType(path), Path.GetFileName(path));
    }

    [HttpPost]
    public async Task<IActionResult> PostFolder([FromBody]CreateFolderCommand command)
    {
      var userID = _caller.Claims.Single(u => u.Type == "id");
      await _mediator.Send(new CreateFolderCommand
      {
        FolderPath = $"/{command.FolderPath}",
        FilePath = command.FilePath,
        CreateBy = Convert.ToInt64(userID.Value),
        UpdateBy = Convert.ToInt64(userID.Value),
        ProjectID = command.ProjectID
      });

      return NoContent();
    }

  }
}
