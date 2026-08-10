using System.Threading.Tasks;

namespace ZAD.Domain.Interfaces.DomainServices
{
    public interface ICompanyUniquenessChecker
    {
        Task<bool> IsNameUniqueAsync(string nameEn, int? currentCompanyId = null);
    }
}
