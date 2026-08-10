using System;
using Microsoft.AspNetCore.Http;
using ZAD.Domain.Enums;

namespace ZAD.Application.DTOs.Common
{
    public class CreateDocumentDto
    {
        public DocumentType Type { get; set; }
        
        public string DocumentNumber { get; set; } = string.Empty;
        public IFormFile? AttachFile { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
