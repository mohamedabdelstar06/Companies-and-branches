using System;
using ZAD.Domain.Enums;
using ZAD.Domain.SeedWork;

namespace ZAD.Domain.Entities.Common
{
    public class Document : Entity
    {
        public DocumentType Type { get; private set; }
        public string DocumentNumber { get; private set; } = string.Empty;
        public string FilePath { get; private set; } = string.Empty;
        public DateTime? ExpiryDate { get; private set; }

        private Document() { } // EF Core

        public Document(DocumentType type, string documentNumber, string filePath, DateTime? expiryDate)
        {
            Type = type;
            DocumentNumber = documentNumber;
            FilePath = filePath;
            ExpiryDate = expiryDate;
        }

        public void Update(DocumentType type, string documentNumber, string filePath, DateTime? expiryDate)
        {
            Type = type;
            DocumentNumber = documentNumber;
            FilePath = filePath;
            ExpiryDate = expiryDate;
        }
    }
}
