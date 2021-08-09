﻿using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace OnlineTicket.Infrastructure.Extensions
{
    public static class SessionExtension
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(session.GetString(key));
            }
            catch
            {
                return default;
            }
        }
    }
}