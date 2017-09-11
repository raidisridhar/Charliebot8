using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using ContosoFlowers.Models.Search;
using ContosoFlowers.Services;
using ContosoFlowers.Properties;
using System.Threading;

namespace ContosoFlowers.Handlers
{
    internal sealed class SearchIntentHandler : IIntentHandler
    {
        private readonly ISearchService bingSearchService;
        private readonly IBotToUser botToUser;

        public SearchIntentHandler(IBotToUser botToUser, ISearchService bingSearchService)
        {
            SetField.NotNull(out this.bingSearchService, nameof(bingSearchService), bingSearchService);
            SetField.NotNull(out this.botToUser, nameof(botToUser), botToUser);
        }

        public async Task Respond(IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            EntityRecommendation entityRecommendation;
            string summaryText = string.Empty;
            try
            {
                var query = result.TryFindEntity(ZummerStrings.ArticlesEntityTopic, out entityRecommendation)
                    ? entityRecommendation.Entity
                    : result.Query;
                query = query.Substring(query.IndexOf(" "), query.Length - query.IndexOf(" "));
               // await this.botToUser.PostAsync(string.Format(Resources.SearchTopicTypeMessage));
                
                string bingSearch =  this.bingSearchService.FindArticles(query);
                
                if (bingSearch == null)
                {
                    summaryText = "I'm sorry I could not search at this point of time, please try again.";
                }
                else
                {
                    summaryText = "Error";
                    //var zummerResult = this.PrepareZummerResult(query, bingSearch.webPages.value[0]);

                    //summaryText = $"### [{zummerResult.Tile}]({zummerResult.Url})\n{zummerResult.Snippet}\n\n";

                    //summaryText +=
                    //    $"*{string.Format(Resources.PowerBy, $"[Bing™](https://www.bing.com/search/?q={zummerResult.Query} site:wikipedia.org)")}*";
                }
            }
            catch { summaryText = "I'm sorry I could not search at this point of time, please try again."; }
            await this.botToUser.PostAsync(summaryText);
        }

        private ZummerSearchResult PrepareZummerResult(string query, Value page)
        {
            string url;
            var myUri = new Uri(page.url);

            if (myUri.Host == "www.bing.com" && myUri.AbsolutePath == "/cr")
            {
                url = HttpUtility.ParseQueryString(myUri.Query).Get("r");
            }
            else
            {
                url = page.url;
            }

            var zummerResult = new ZummerSearchResult
            {
                Url = url,
                Query = query,
                Tile = page.name,
                Snippet = page.snippet
            };

            return zummerResult;
        }
    }
}