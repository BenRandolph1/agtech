using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using QuickType;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AgTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgController : Controller
    {
        // GET
        [HttpGet]
        public async Task<IncomeStatementResultModel> GetSurveyData(int year, string state)
        {
            HttpClient client = new HttpClient();
            string url = "https://api.ers.usda.gov/data/arms/surveydata?api_key=7E2Zm2gjLLIO5KnLC11OQ4p3MvWMuobvarkfBBH6&year=" + year + "&state=" + state + "&report=income+statement&farmtype=operator+households&category=collapsed+farm+typology&category_value=commercial";

            using (var response = await client.GetAsync(url))
            {
                var content = await response.Content.ReadAsStringAsync();
                var incomeStatementResultModel = IncomeStatementResultModel.FromJson(content);

                return incomeStatementResultModel;
            }
        }
        
    }
}