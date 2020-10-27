using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using DiplomProject.Infrastructure;

namespace DiplomProject.Models
{
    public class SessionFavorite : Favorite
    {
        public static Favorite GetFavorite(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionFavorite favorite = session?.GetJson<SessionFavorite>("Favorite")
                ?? new SessionFavorite();
            favorite.Session = session;
            return favorite;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Car Car)
        {
            base.AddItem(Car);
            Session.SetJson("Favorite", this);
        }

        public override void RemoveItem(Car Car)
        {
            base.RemoveItem(Car);
            Session.SetJson("Favorite", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Favorite");
        }
    }
}
