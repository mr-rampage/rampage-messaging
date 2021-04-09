﻿using System;
using System.Threading.Tasks;

namespace Rampage.Messaging.Impl
{
    public static class Combinators
    {
        public static Action<Action<T>> Thrush<T>(T x) => f => f(x);
        public static Func<Action<T>, Task> ThrushAsync<T>(T x) => f => Task.Run(() => f(x));

        public static Action<dynamic> ApplyForType<T>(Action<T> f) => x =>
        {
            if (x is T ofType) f(ofType);
        };
    }
}