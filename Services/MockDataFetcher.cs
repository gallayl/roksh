using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using roksh.Models;

namespace roksh.Services
{
    public class MockDataFetcher : IDataFetcher
    {

        private readonly HttpClient _client = new HttpClient();
        const string startingPage = "https://www.arukereso.hu/mobiltelefon-c3277/f:samsung,erintokepernyo/";

        private async Task<HtmlDocument> LoadPage(string url)
        {
            var response = await _client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            var html = new HtmlDocument();
            html.LoadHtml(body);
            return html;
        }

        private string GetNextPageUrl(HtmlDocument page) => page.DocumentNode.SelectNodes("//a[@data-akpage]").ToList().FirstOrDefault(node => node.InnerText.Contains('>'))?.Attributes.First(attr => attr.Name == "href").Value;

        private List<Item> ParseItemsFromPage(HtmlDocument page)
        {
            return page.DocumentNode.SelectNodes("//div[@class='product-box clearfix']")
            .Select((node,item) =>
            {
                var name = node.SelectSingleNode(".//h2/a").InnerText;
                var img = node.SelectSingleNode(".//img[@src|@data-lazy-src]")?.Attributes.FirstOrDefault(attr => attr.Name == "src" || attr.Name == "data-lazy-src")?.Value;
                var url = node.SelectSingleNode(".//a[@href][@class='image']")?.Attributes.FirstOrDefault(attr => attr.Name == "href")?.Value;
                var description = node.SelectSingleNode(".//div[@class='description clearfix hidden-xs'][last()]")?.InnerText;
                return new Item() { Name = name, ImageUrl=img, ItemUrl=url, Description=description };
            }).ToList();
        }

        private async Task<List<Item>> GetItemsFromPage(string url = MockDataFetcher.startingPage)
        {
            var page = await LoadPage(url);
            var result = ParseItemsFromPage(page);
            var nextPage = GetNextPageUrl(page);
            if (!String.IsNullOrEmpty(nextPage)){
                var nextValues = await this.GetItemsFromPage(nextPage);
                result.AddRange(nextValues);
            }
            return result;
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await this.GetItemsFromPage();
        }
    }
}