using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pairs.Models;

namespace Pairs.Repositories
{
    public class ShapeRepository : IShapeRepository
    {
        private readonly HttpClient httpClient;

        public ShapeRepository()
        {
            httpClient = new HttpClient();
        }

        public async Task<IList<Shape>> ListAsync()
        {
            var response = await httpClient.GetAsync("https://gist.githubusercontent.com/bijington/ed15ab140a57e751dc8db6a21b068626/raw/11d72ae0bf088255e9f292d26e6eae8575dcf2de/shapes.json");

            if (!response.IsSuccessStatusCode)
            {
                return new List<Shape>();
            }

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IList<Shape>>(content);
        }
    }
}
