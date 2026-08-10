using System.Threading.Tasks;

namespace ZAD.Domain.Interfaces.DomainServices
{
    public interface IBranchUniquenessChecker
    {
        Task<bool> IsNameUniqueWithinCompanyAsync(int companyId, string nameEn, int? currentBranchId = null);
    }
}
