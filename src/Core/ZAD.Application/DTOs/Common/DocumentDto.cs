using System;
using ZAD.Domain.Enums;

namespace ZAD.Application.DTOs.Common
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public DocumentType Type { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public DateTime? ExpiryDate { get; set; }
    }
}
