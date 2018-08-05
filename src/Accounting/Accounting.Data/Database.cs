namespace Accounting.Data
{
    using Accounting.Core.External_Services;
    using Accounting.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Database : IDatabase
    {
        public Task<IReadOnlyCollection<Applicant>> GetApplicantsAsync()
        {
            var taskSource = new TaskCompletionSource<IReadOnlyCollection<Applicant>>();

            taskSource.SetResult(Enumerable.Range(1, 10).Select(id => new Applicant(id, $"{Guid.NewGuid()} - {id}")).ToList());

            return taskSource.Task;
        }
    }
}
