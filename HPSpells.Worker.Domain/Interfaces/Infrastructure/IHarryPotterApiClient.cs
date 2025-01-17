using HPSpells.Worker.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPSpells.Worker.Domain.Interfaces.Infrastructure
{
    public interface IHarryPotterApiClient
    {
        Task<List<SpellDTO>> GetSpells();
    }
}
