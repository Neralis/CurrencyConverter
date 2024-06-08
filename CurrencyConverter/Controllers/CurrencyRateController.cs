using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CurrencyConverter.services;

namespace CurrencyConverter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyRateController : ControllerBase
    {
        private readonly CurrencyRateService _currencyRateService;

        public CurrencyRateController(CurrencyRateService currencyRateService)
        {
            _currencyRateService = currencyRateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRates()
        {
            var xmlContent = await _currencyRateService.GetCurrencyRatesAsync();
            var rates = _currencyRateService.ParseCurrencyRates(xmlContent);
            return Ok(rates);
        }
    }


}