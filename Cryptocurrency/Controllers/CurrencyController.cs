using DataContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;

namespace Cryptocurrency.Controllers
{
    [Authorize]
    public class CurrencyController : Controller
    {
        public RedirectResult Index(int value = 0)
        {
            return RedirectPermanent("/Account/Login");
        }

        // GET: Currency
        [HttpGet]
        public ActionResult Index()
        {
            CurrencyWork currencyWork = new CurrencyWork();
            List<Currency> currencyList = currencyWork.GetCurrenciesOfUSD();
            Cryptocurrency.Models.Currencys currencies = new Cryptocurrency.Models.Currencys();
            currencies.MainList = new List<Cryptocurrency.Models.Currency>();
            currencies.MainList.AddRange(currencyList.Select(x =>
                new Cryptocurrency.Models.Currency
                {
                    ID = x.ID,
                    Name = x.Name,
                    Symbol = x.Symbol,
                    CmcRank = x.CmcRank,
                    FullCmcRank = "https://s2.coinmarketcap.com/static/img/coins/16x16/" + x.CmcRank + ".png",
                    Price = x.Price,
                    PercentChangeOneHour = x.PercentChangeOneHour,
                    PercentChangeTwentyFourHour = x.PercentChangeTwentyFourHour,
                    MarketCap = x.MarketCap,
                    LastUpdated = x.LastUpdated
                }));
            currencies.SearchList = currencies.MainList;
            currencies.SearchItem = new Cryptocurrency.Models.CurrencyFilter();
            currencies.SearchItem.LastUpdatedFrom = currencies.SearchItem.LastUpdatedTo = DateTime.Now;
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains("0"))
            {
                memoryCache.Remove("0");
            }
            memoryCache.Add("0", currencies.MainList, DateTime.Now.AddMinutes(10));
            currencies.Title = "Криптовалюты";
            return View(currencies);
        }

        [HttpPost]
        public ActionResult Index(Cryptocurrency.Models.Currencys value)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            value.MainList = (List<Cryptocurrency.Models.Currency>) memoryCache.Get("0");
            value.SearchList = value.MainList;
            if (value?.MainList?.Count > 0 && value?.SearchItem != null)
            {
                if (value.SearchItem.Name?.Length > 0)
                    value.SearchList = value.SearchList.Where(x => x.Name == value.SearchItem.Name).ToList();

                if (value.SearchItem.IsPrice)
                {

                    if (value.SearchItem.PriceFrom != 0 && value.SearchItem.PriceTo != 0)
                        value.SearchList = value.SearchList.Where(x => x.Price >= value.SearchItem.PriceFrom &&
                                                                       x.Price <= value.SearchItem.PriceTo).ToList();
                    else if (value.SearchItem.PriceFrom != 0 && value.SearchItem.PriceTo == 0)
                        value.SearchList = value.SearchList.Where(x => x.Price >= value.SearchItem.PriceFrom).ToList();
                    else if (value.SearchItem.PriceFrom == 0 && value.SearchItem.PriceTo != 0)
                        value.SearchList = value.SearchList.Where(x => x.Price <= value.SearchItem.PriceTo).ToList();
                }

                if (value.SearchItem.IsPercentChangeOneHour)
                {
                    if (value.SearchItem.PercentChangeOneHourFrom != 0 && value.SearchItem.PercentChangeOneHourFrom != 0)
                        value.SearchList = value.SearchList.Where(x =>
                            x.PercentChangeOneHour >= value.SearchItem.PercentChangeOneHourFrom &&
                            x.PercentChangeOneHour <= value.SearchItem.PercentChangeOneHourTo).ToList();
                    else if (value.SearchItem.PercentChangeOneHourFrom != 0 && value.SearchItem.PercentChangeOneHourTo == 0)
                        value.SearchList = value.SearchList.Where(
                            x => x.PercentChangeOneHour >= value.SearchItem.PercentChangeOneHourFrom).ToList();
                    else if (value.SearchItem.PercentChangeOneHourFrom == 0 && value.SearchItem.PercentChangeOneHourTo != 0)
                        value.SearchList = value.SearchList.Where(
                            x => x.PercentChangeOneHour <= value.SearchItem.PercentChangeOneHourTo).ToList();
                }

                if (value.SearchItem.IsPercentChangeTwentyFourHour)
                {
                    if (value.SearchItem.PercentChangeTwentyFourHourFrom != 0 && value.SearchItem.PercentChangeTwentyFourHourTo != 0)
                        value.SearchList = value.SearchList.Where(
                                x => x.PercentChangeTwentyFourHour >=
                                     value.SearchItem.PercentChangeTwentyFourHourFrom &&
                                     x.PercentChangeTwentyFourHour <= value.SearchItem.PercentChangeTwentyFourHourTo)
                            .ToList();
                    else if (value.SearchItem.PercentChangeTwentyFourHourFrom != 0 && value.SearchItem.PercentChangeTwentyFourHourTo == 0)
                        value.SearchList = value.SearchList.Where(
                                x => x.PercentChangeTwentyFourHour >= value.SearchItem.PercentChangeTwentyFourHourFrom)
                            .ToList();
                    else if (value.SearchItem.PercentChangeTwentyFourHourFrom == 0 && value.SearchItem.PercentChangeTwentyFourHourTo != 0)
                        value.SearchList = value.SearchList.Where(
                                x => x.PercentChangeTwentyFourHour <= value.SearchItem.PercentChangeTwentyFourHourTo)
                            .ToList();
                }

                if (value.SearchItem.IsMarketCap)
                {
                    if (value.SearchItem.MarketCapFrom != 0 && value.SearchItem.MarketCapTo != 0)
                        value.SearchList = value.SearchList.Where(
                            x => x.MarketCap >= value.SearchItem.MarketCapFrom &&
                                 x.MarketCap <= value.SearchItem.MarketCapTo).ToList();
                    else if (value.SearchItem.MarketCapFrom != 0 && value.SearchItem.MarketCapTo == 0)
                        value.SearchList = value.SearchList.Where(
                            x => x.MarketCap >= value.SearchItem.MarketCapFrom).ToList();
                    else if (value.SearchItem.MarketCapFrom == 0 && value.SearchItem.MarketCapTo != 0)
                        value.SearchList = value.SearchList.Where(
                            x => x.MarketCap <= value.SearchItem.MarketCapTo).ToList();
                }

                if (value.SearchItem.IsLastUpdated)
                {
                    if (value.SearchItem.LastUpdatedFrom != null && value.SearchItem.LastUpdatedTo != null)
                        value.SearchList = value.SearchList.Where(x =>
                            x.LastUpdated.Date >= value.SearchItem.LastUpdatedFrom.Date &&
                            x.LastUpdated.Date <= value.SearchItem.LastUpdatedTo.Date).ToList();
                    else if (value.SearchItem.LastUpdatedFrom != null && value.SearchItem.LastUpdatedTo == null)
                        value.SearchList = value.SearchList
                            .Where(x => x.LastUpdated >= value.SearchItem.LastUpdatedFrom.Date).ToList();
                    else if (value.SearchItem.LastUpdatedFrom == null && value.SearchItem.LastUpdatedTo != null)
                        value.SearchList = value.SearchList
                            .Where(x => x.LastUpdated <= value.SearchItem.LastUpdatedTo.Date).ToList();
                }
            }
            value.Title = "Криптовалюты";
            if (value.SearchList == null) value.SearchList = new List<Cryptocurrency.Models.Currency>();
            return View("Index", value);
        }

    }
}