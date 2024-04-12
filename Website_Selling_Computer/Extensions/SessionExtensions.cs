
using System.Text.Json;

namespace Website_Selling_Computer.Session
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key,
            object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value) ?? default;
        }
       /* public static T? GetObjectFromJson<T>(this ISession session, string key) where T : struct
        {
            var value = session.GetString(key);
            return value == null ? null : JsonSerializer.Deserialize<T>(value);
        }*/
    }

}
