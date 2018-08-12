namespace Accounting.Core.External_Services
{
    using Accounting.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDatabase
    {
        Task<IReadOnlyCollection<Applicant>> GetApplicantsAsync();
        Task DeleteApplicantAsync(Applicant applicant);
        Task UpdateApplicantAsync(Applicant applicant);
        Task<Applicant> InsertApplicantAsync(Applicant applicant);
    }
}
