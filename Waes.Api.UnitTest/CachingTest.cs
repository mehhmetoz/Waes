﻿using System;
using Xunit;
using Waes.Api.Helpers;

namespace Waes.Api.UnitTest
{
    public class CachingTest
    {
       
        [Fact]
        public void AddAndGetItemInLRightStore()
        {
            CachingHelper.Add(1, "zxcvb", CacheDirection.RIGHT);
            Assert.Equal("zxcvb", CachingHelper.Get(1, CacheDirection.RIGHT));
        }

        [Fact]
        public void AddAndGetItemInLeftStore()
        {
            CachingHelper.Add(1, "asdfg", CacheDirection.LEFT);
            Assert.Equal("asdfg", CachingHelper.Get(1, CacheDirection.LEFT));
        }
    }
}
