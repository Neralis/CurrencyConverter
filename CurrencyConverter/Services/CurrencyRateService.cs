using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CurrencyConverter.services
{
    public class CurrencyRateService
    {
        private readonly HttpClient _httpClient;

        public CurrencyRateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetCurrencyRatesAsync()
        {
            var url = "https://www.cbr-xml-daily.ru/daily_utf8.xml";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var xmlContent = await response.Content.ReadAsStringAsync();
            return xmlContent;
        }

        public Dictionary<string, string> ParseCurrencyRates(string xmlContent)
        {
            var rates = new Dictionary<string, string>();

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlContent);

            var nodeList = xmlDoc.GetElementsByTagName("Valute");
            foreach (XmlNode node in nodeList)
            {
                var charCode = node["CharCode"]?.InnerText;
                var value = node["Value"]?.InnerText;
                if (charCode != null && value != null)
                {
                    rates[charCode] = value;
                }
            }

            return rates;
        }
    }
}
