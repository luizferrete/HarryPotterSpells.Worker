using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPSpells.Worker.Domain.Interfaces.Infrastructure
{
    public interface ISpellHangfireJob
    {
        Task ExecuteAsync();
    }
}
