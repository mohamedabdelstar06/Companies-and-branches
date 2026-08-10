using System.Collections.Generic;
using System.Linq;
using ZAD.Domain.Entities.Common;
using ZAD.Domain.SeedWork;
using ZAD.Domain.ValueObjects;

namespace ZAD.Domain.Entities.Branches
{
    public class Branch : Entity, IAggregateRoot
    {
        public string Code { get; private set; } = string.Empty;
        
        public string NameAr { get; private set; } = string.Empty;

        public string NameEn { get; private set; } = string.Empty;
        
        public Address? Address { get; private set; }
        
        public EmailAddress? Email { get; private set; }
        
        public string? Phone { get; private set; }
        
        public string? CostCenter { get; private set; }
        
        public bool IsMainBranch { get; private set; }
        
        public string? LogoPath { get; private set; }
        
        public bool IsActive { get; private set; } = true;

        public int CompanyId { get; private set; }
        
        public Companies.Company? Company { get; private set; }

        private readonly List<Contact> _contacts = new();

        public IReadOnlyCollection<Contact> Contacts => _contacts.AsReadOnly();

        private readonly List<Document> _documents = new();

        public IReadOnlyCollection<Document> Documents => _documents.AsReadOnly();

        private Branch() { } // EF Core

        public Branch(string code, string nameAr, string nameEn, int companyId, Address? address, EmailAddress? email, string? phone, string? costCenter, bool isMainBranch, string? logoPath)
        {
            Code = code;
            NameAr = nameAr;
            NameEn = nameEn;
            CompanyId = companyId;
            Address = address;
            Email = email;
            Phone = phone;
            CostCenter = costCenter;
            IsMainBranch = isMainBranch;
            LogoPath = logoPath;
        }

        public void Update(string nameAr, string nameEn, int companyId, Address? address, EmailAddress? email, string? phone, string? costCenter, bool isMainBranch, string? logoPath, bool isActive)
        {
            NameAr = nameAr;
            NameEn = nameEn;
            CompanyId = companyId;
            Address = address;
            Email = email;
            Phone = phone;
            CostCenter = costCenter;
            IsMainBranch = isMainBranch;
            LogoPath = logoPath ?? LogoPath;
            IsActive = isActive;
        }

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public void RemoveContact(int contactId)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == contactId);
            if (contact != null)
                _contacts.Remove(contact);
        }

        public void ClearContacts()
        {
            _contacts.Clear();
        }

        public void AddDocument(Document document)
        {
            _documents.Add(document);
        }

        public void RemoveDocument(int documentId)
        {
            var document = _documents.FirstOrDefault(d => d.Id == documentId);
            if (document != null)
                _documents.Remove(document);
        }
        
        public void ClearDocuments()
        {
            _documents.Clear();
        }
    }
}
