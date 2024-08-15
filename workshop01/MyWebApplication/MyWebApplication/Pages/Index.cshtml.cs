using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace MyWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;

        public string RandomQuote { get; private set; }

        //private static readonly string[] Quotes = new[]
        //{
        //    "Logic will get you from A to B. Imagination will take you everywhere.",
        //    "There are 10 kinds of people. Those who know binary and those who don't.",
        //    "There are two ways of constructing a software design. One way is to make it so simple that there are obviously no deficiencies and the other is to make it so complicated that there are no obvious deficiencies.",
        //    "It's not that I'm so smart, it's just that I stay with problems longer.",
        //    "It is pitch dark. You are likely to be eaten by a grue."
        //};

        public IndexModel(ILogger<IndexModel> logger, IMemoryCache memoryCache, IConfiguration configuration)
        {
            _logger = logger;
            _cache = memoryCache;
            _configuration = configuration;
        }

        public void OnGet()
        {
            //var random = new Random();
            //RandomQuote = Quotes[random.Next(Quotes.Length)];

            // Try to get the list of quotes from cache
            if (!_cache.TryGetValue("QuotesList", out string[] quotes))
            {
                // If not in cache, get the quotes from appsettings.json
                quotes = _configuration.GetSection("Quotes").Get<string[]>();

                // Cache the list of quotes
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(60)); // Cache for 60 minutes

                _cache.Set("QuotesList", quotes, cacheEntryOptions);
            }

            // Randomly select a quote
            var random = new Random();
            RandomQuote = quotes[random.Next(quotes.Length)];
        }
    }
}
