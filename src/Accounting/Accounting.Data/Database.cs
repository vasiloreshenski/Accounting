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
        private List<Applicant> all = Enumerable.Range(1, 10).Select(id => new Applicant(id, $"{Guid.NewGuid()} - {id}")).ToList();

        public Task DeleteApplicantAsync(Applicant applicant)
        {
            this.all.RemoveAll(x => x.Id == applicant.Id);

            return Task.CompletedTask;
        }

        public Task<IReadOnlyCollection<Applicant>> GetApplicantsAsync()
        {
            var taskSource = new TaskCompletionSource<IReadOnlyCollection<Applicant>>();

            taskSource.SetResult(this.all);

            return taskSource.Task;
        }

        public Task<Applicant> InsertApplicantAsync(Applicant applicant)
        {
            var newApplicant = new Applicant(this.all.Max(x => x.Id), applicant.Name);

            this.all.Add(newApplicant);

            var ts = new TaskCompletionSource<Applicant>();
            ts.SetResult(newApplicant);

            return ts.Task;
        }

        public Task UpdateApplicantAsync(Applicant applicant)
        {
            if (this.all.Find(x => x.Id == applicant.Id) is Applicant a)
            {
                a.Name = applicant.Name;
            }

            return Task.CompletedTask;
        }
    }
}
