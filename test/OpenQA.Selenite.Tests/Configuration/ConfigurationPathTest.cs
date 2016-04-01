// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using NUnit.Framework;

namespace Microsoft.Extensions.Configuration.Test
{
    [TestFixture]
    public class ConfigurationPathTest
    {
        [Test]
        public void CombineWithEmptySegmentLeavesDelimiter()
        {
            Assert.AreEqual("parent:", ConfigurationPath.Combine("parent", ""));
            Assert.AreEqual("parent::", ConfigurationPath.Combine("parent", "", ""));
            Assert.AreEqual("parent:::key", ConfigurationPath.Combine("parent", "", "", "key"));
        }

        [Test]
        public void GetLastSegmenGetSectionKeyTests()
        {
            Assert.AreEqual(null, ConfigurationPath.GetSectionKey(null));
            Assert.AreEqual("", ConfigurationPath.GetSectionKey(""));
            Assert.AreEqual("", ConfigurationPath.GetSectionKey(":::"));
            Assert.AreEqual("c", ConfigurationPath.GetSectionKey("a::b:::c"));
            Assert.AreEqual("", ConfigurationPath.GetSectionKey("a:::b:"));
            Assert.AreEqual("key", ConfigurationPath.GetSectionKey("key"));
            Assert.AreEqual("key", ConfigurationPath.GetSectionKey(":key"));
            Assert.AreEqual("key", ConfigurationPath.GetSectionKey("::key"));
            Assert.AreEqual("key", ConfigurationPath.GetSectionKey("parent:key"));
        }

        [Test]
        public void GetParentPathTests()
        {
            Assert.AreEqual(null, ConfigurationPath.GetParentPath(null));
            Assert.AreEqual(null, ConfigurationPath.GetParentPath(""));
            Assert.AreEqual("::", ConfigurationPath.GetParentPath(":::"));
            Assert.AreEqual("a::b::", ConfigurationPath.GetParentPath("a::b:::c"));
            Assert.AreEqual("a:::b", ConfigurationPath.GetParentPath("a:::b:"));
            Assert.AreEqual(null, ConfigurationPath.GetParentPath("key"));
            Assert.AreEqual("", ConfigurationPath.GetParentPath(":key"));
            Assert.AreEqual(":", ConfigurationPath.GetParentPath("::key"));
            Assert.AreEqual("parent", ConfigurationPath.GetParentPath("parent:key"));
        }

    }
}
