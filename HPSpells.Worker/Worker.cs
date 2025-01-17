using Hangfire;
using HPSpells.Worker.Domain.Interfaces.Infrastructure;

namespace HPSpells.Worker
{
    public class Worker : BackgroundService
    {
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly ISpellHangfireJob _spellHangfireJob;

        public Worker(IRecurringJobManager recurringJobManager, ISpellHangfireJob spellHangfireJob)
        {
            _recurringJobManager = recurringJobManager;
            _spellHangfireJob = spellHangfireJob;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _recurringJobManager.AddOrUpdate(
                "SpellJob",
                () =>  _spellHangfireJob.ExecuteAsync(),
                Cron.Minutely);

        }
    }
}
