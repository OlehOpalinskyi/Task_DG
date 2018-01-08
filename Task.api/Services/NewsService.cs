using CsQuery;
using System;
using System.Collections.Generic;
using Task.api.Models;

namespace Task.api.Services
{
    public class NewsService
    {
        public List<NewsModel> GetNews()
        {
            var news = new List<NewsModel>();
            var url = "http://www.pravda.com.ua/news/";
            var dom = CQ.CreateFromUrl(url);
            var articles = dom.Select("#endless .article").Length;
            for (var i = 0; i < articles; i++)
            {
                var article = new NewsModel()
                {
                    Time = TimeSpan.Parse(dom.Select("#endless  .article__time").Eq(i).Text()),
                    Title = dom.Select("#endless .article__title a").Eq(i).Text()
                };
                news.Add(article);
            }

            return news;
        }

        public IEnumerable<NewsModel> ByTitle()
        {
            var news = GetNews();
            news.Sort((x, y) => string.Compare(x.Title, y.Title));
            return news;
        }

        public IEnumerable<NewsModel> ByDate()
        {
            var news = GetNews();
            news.Sort((x, y) => TimeSpan.Compare(x.Time, y.Time));
            return news;
        }
    }
}