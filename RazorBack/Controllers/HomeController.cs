namespace RazorBack.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using RazorBack.Models;
    using RazorBack.Models.BotApiModels;
    using System.Diagnostics;
    using System.Text;

    public class HomeController : Controller
    {
        private const string QueryPrefix = "query: ";

        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        protected string _botUrl { get; set; }
        protected string _whereToAsk { get; set; }

        public HomeController(
            ILogger<HomeController> logger,
            IConfiguration config)
        {
            _logger = logger;
            _config = config;

            _botUrl = _config.GetValue<string>("BotUrl");
            _whereToAsk = _config.GetValue<string>("WhereToAsk");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Resolve(QAModel model)
        {
            var client = new HttpClient();
            var question = new QuestionRequstModel
            {
                Article = new Article { Link = @"https://doi.org/10.1039/C4RA15675G" },
                QueryText = string.Concat(QueryPrefix, model.Question),
                Context = model.Context ?? string.Empty
            };

            var json = JsonConvert.SerializeObject(question);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(string.Concat(_botUrl, _whereToAsk), content);

            var answer = JsonConvert.DeserializeObject<AnswerModel>(result.Content.ReadAsStringAsync().Result);

            return View("Index", new QAModel { Answer = answer.Answer, Context = answer.Context });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}