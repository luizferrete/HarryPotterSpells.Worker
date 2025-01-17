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
    public class HarryPotterApiClient : IHarryPotterApiClient
    {
        private readonly HttpClient _httpClient;

        public HarryPotterApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SpellDTO>> GetSpells()
        {
            var response = await _httpClient.GetAsync("en/spells");
            response.EnsureSuccessStatusCode();
            var spells = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<SpellDTO>>(spells, 
            new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
        }
    }
}
