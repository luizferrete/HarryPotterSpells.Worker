using HPSpells.Worker.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPSpells.Worker.Domain.Interfaces.Business
{
    public interface ISpellService
    {
        Task<SpellDTO> SetSpell();
        Task SendSpell(SpellDTO spell);
    }
}
