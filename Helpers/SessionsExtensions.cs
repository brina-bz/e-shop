using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OpremiSe.Models;

namespace OpremiSe.Helpers

{
    public static class SessionsExtensions
    {
        public static void SetCart(this ISession session, string key, ShoppingCart cart)
        {
            session.SetString(key, JsonConvert.SerializeObject(cart));
        }

        public static ShoppingCart GetCart(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? new ShoppingCart() : JsonConvert.DeserializeObject<ShoppingCart>(value);
        }
    }
}
