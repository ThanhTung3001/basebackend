

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Data.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DbEntities.Attachments;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AttachmentController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;
    private readonly ApplicationDbContext _dbContext;

    public AttachmentController(IWebHostEnvironment environment, ApplicationDbContext dbContext)
    {
        _environment = environment;
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file, string savePath)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("File not found");
        }

        var fileName = Path.GetFileName(file.FileName);
        var fileFullPath = Path.Combine(savePath, fileName);
        var filePath = Path.Combine(savePath, fileName);
        var _savePath = Path.Combine(Directory.GetCurrentDirectory(), savePath);
        if (!Directory.Exists(_savePath))
        {
            Directory.CreateDirectory(_savePath);
        }
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var attachment = new Attachment
        {
            FileName = fileName,
            ContentType = file.ContentType,
            Size = file.Length,
            FilePath = fileFullPath,
            CreatedAt = DateTime.Now
        };

        _dbContext.Attachments.Add(attachment);
        await _dbContext.SaveChangesAsync();

        return Ok(new { attachment.Id, attachment.FileName, PathFile = filePath });
    }

    [HttpPost("multiple")]
    public async Task<IActionResult> UploadMultiple(List<IFormFile> files, string savePath)
    {
        if (files == null || files.Count == 0)
        {
            return BadRequest("Files not found");
        }

        var attachments = new List<Attachment>();
        var _savePath = Path.Combine(Directory.GetCurrentDirectory(), savePath);
        if (!Directory.Exists(_savePath))
        {
            Directory.CreateDirectory(_savePath);
        }
        foreach (var file in files)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(savePath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var attachment = new Attachment
            {
                FileName = fileName,
                ContentType = file.ContentType,
                Size = file.Length,
                FilePath = filePath,
                CreatedAt = DateTime.Now
            };

            attachments.Add(attachment);
            _dbContext.Attachments.Add(attachment);
        }

        await _dbContext.SaveChangesAsync();

        return Ok(new { data = attachments.Select(a => new { a.Id, a.FileName }) });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDataFile(int id)
    {
        var attachment = await _dbContext.Attachments.FindAsync(id);

        if (attachment == null)
        {
            return NotFound();
        }

        var filePath = attachment.FilePath;
        var memory = new MemoryStream();

        using (var stream = new FileStream(filePath, FileMode.Open))
        {
            await stream.CopyToAsync(memory);
        }

        memory.Position = 0;

        return File(memory, attachment.ContentType, attachment.FileName);
    }

    [HttpGet("info/{id}")]
    public async Task<IActionResult> GetInfoFile(int id)
    {
        var attachment = await _dbContext.Attachments.FindAsync(id);

        if (attachment == null)
        {
            return NotFound();
        }

        return Ok(new
        {
            attachment.Id,
            attachment.FileName,
            attachment.ContentType,
            attachment.Size,
            attachment.FilePath,
            attachment.CreatedAt,
            attachment.Type
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFile(int id)
    {
        var attachment = await _dbContext.Attachments.FindAsync(id);

        if (attachment == null)
        {
            return NotFound();
        }

        System.IO.File.Delete(attachment.FilePath);
        _dbContext.Attachments.Remove(attachment);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
}