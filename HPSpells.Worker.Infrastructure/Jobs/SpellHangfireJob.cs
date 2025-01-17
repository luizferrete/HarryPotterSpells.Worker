using HPSpells.Worker.Domain.Interfaces.Business;
using HPSpells.Worker.Domain.Interfaces.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPSpells.Worker.Infrastructure.Jobs
{
    public class SpellHangfireJob : ISpellHangfireJob
    {
        private readonly ISpellService _spellService;
        private readonly ILogger<SpellHangfireJob> _logger;

        public SpellHangfireJob(ISpellService spellService, ILogger<SpellHangfireJob> logger)
        {
            _spellService = spellService;
            _logger = logger;
        }

        public async Task ExecuteAsync()
        {
            _logger.LogInformation("Executing SpellHangfireJob");

            var spell = await _spellService.SetSpell();
            await _spellService.SendSpell(spell);

            _logger.LogInformation("SpellHangfireJob executed, upserted spell {spell}", spell);
        }
    }
}
