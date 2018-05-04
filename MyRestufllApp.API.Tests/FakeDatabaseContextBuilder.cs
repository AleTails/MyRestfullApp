using System;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using MyRestfullApp.Infrastructure.Data;

namespace MyRestufllApp.API.Tests
{
    internal class FakeDatabaseContextBuilder
    {
        public MyRestfullAppContext Build([CallerMemberName] string contextName = null)
        {
            var optionBuilder = new DbContextOptionsBuilder<MyRestfullAppContext>();
            optionBuilder.UseInMemoryDatabase($"{contextName}{Guid.NewGuid()}");
            return new MyRestfullAppContext(optionBuilder.Options);
        }
    }
}
