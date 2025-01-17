using HPSpells.Worker.Domain.Interfaces.Business;
using HPSpells.Worker.Domain.Interfaces.Infrastructure;
using HPSpells.Worker.Domain.ValueObjects;

namespace HPSpells.Worker.Business.Services
{
    public class SpellService : ISpellService
    {
        private readonly IHarryPotterApiClient _hpClient;
        private readonly IInternalApiClient _internalClient;

        public SpellService(IHarryPotterApiClient hpClient, IInternalApiClient internalClient)
        {
            _hpClient = hpClient;
            _internalClient = internalClient;
        }

        public async Task<SpellDTO> SetSpell()
        {
            var spells = await _hpClient.GetSpells();

            Random random = new Random();
            int randomIndex = random.Next(spells.Count);
            var spell = spells[randomIndex];

            return spell;
        }

        public async Task SendSpell(SpellDTO spell)
        {
            await _internalClient.SendSpell(spell);
        }
    }
}
