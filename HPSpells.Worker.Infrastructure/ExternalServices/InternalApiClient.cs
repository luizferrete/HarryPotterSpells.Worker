using HPSpells.Worker.Domain.Interfaces.Infrastructure;
using HPSpells.Worker.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HPSpells.Worker.Infrastructure.ExternalServices
{
    public class InternalApiClient : IInternalApiClient
    {
        private readonly HttpClient _httpClient;

        public InternalApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendSpell(SpellDTO spell)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(spell),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("spell", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
