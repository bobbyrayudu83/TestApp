using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace TestPocApp.Core.Helpers
{

    public sealed class Singleton
    {
        private Singleton()
        {
        }
        private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());
        public static Singleton Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }

}
