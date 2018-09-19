using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Waes.Api.IntegrationTest
{
    [CollectionDefinition("SystemCollection")]
    public class Collection : Xunit.ICollectionFixture<TestContext>
    {
    }
}
