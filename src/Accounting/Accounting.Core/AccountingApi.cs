namespace Accounting.Core
{
    using Accounting.Core.External_Services;
    using Accounting.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AccountingApi
    {
        private readonly IDatabase database;

        public AccountingApi(IDatabase database)
        {
            this.database = database;
        }

        public Task<IReadOnlyCollection<Applicant>> GetApplicantsAsync()
        {
            return this.database.GetApplicantsAsync();
        }

        public Task UpdateApplicantAsync(Applicant applicant)
        {
            return this.database.UpdateApplicantAsync(applicant);
        }

        public Task DeleteApplicantAsync(Applicant applicant)
        {
            return this.database.DeleteApplicantAsync(applicant);
        }

        public Task<Applicant> InsertApplicantAsync(Applicant applicant)
        {
            return this.database.InsertApplicantAsync(applicant);
        }
    }
}
