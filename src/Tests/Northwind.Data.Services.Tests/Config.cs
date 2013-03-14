using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data.Services.Tests
{
    internal static class Config
    {
        public const string AbsoluteBaseUri = "http://localhost:4337/";
        public const string ServiceStackBaseUri = AbsoluteBaseUri /*+ "api"*/;
    }
}
