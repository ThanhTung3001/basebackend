using System;

namespace Models.DbEntities.Attachments;

public enum AttachmentType
{
    Image,
    QrCodeImage,
    Document
}

public class Attachment
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public long Size { get; set; }
    public string FilePath { get; set; }
    public DateTime CreatedAt { get; set; }
    public AttachmentType Type { get; set; }
}