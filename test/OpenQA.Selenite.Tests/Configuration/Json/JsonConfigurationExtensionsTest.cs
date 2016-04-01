// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.IO;
using NUnit.Framework;

namespace Microsoft.Extensions.Configuration.Json
{
    [TestFixture]
    public class JsonConfigurationExtensionsTest
    {
        [Theory]
        [TestCase(null)]
        [TestCase("")]
        public void AddJsonFile_ThrowsIfFilePathIsNullOrEmpty(string path)
        {
            // Arrange
            var configurationBuilder = new ConfigurationBuilder();

            // Act and Assert
            var ex = Assert.Throws<ArgumentException>(() => JsonConfigurationExtensions.AddJsonFile(configurationBuilder, path));
            Assert.Equals("path", ex.ParamName);
            Assert.That(ex.Message.StartsWith("File path must be a non-empty string."));
        }

        [Test]
        public void AddJsonFile_ThrowsIfFileDoesNotExistAtPath()
        {
            // Arrange
            var path = Path.Combine(Directory.GetCurrentDirectory(), "file-does-not-exist.json");
            var configurationBuilder = new ConfigurationBuilder();

            // Act and Assert
            var ex = Assert.Throws<FileNotFoundException>(() => JsonConfigurationExtensions.AddJsonFile(configurationBuilder, path));
            Assert.Equals($"The configuration file '{path}' was not found and is not optional.", ex.Message);
        }
    }
}
