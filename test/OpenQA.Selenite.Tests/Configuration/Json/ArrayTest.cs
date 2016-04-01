// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Extensions.Configuration.Test;
using NUnit.Framework;

namespace Microsoft.Extensions.Configuration.Json.Test
{
    public class ArrayTest
    {
        [Test]
        public void ArraysAreConvertedToKeyValuePairs()
        {
            var json = @"{
                'ip': [
                    '1.2.3.4',
                    '7.8.9.10',
                    '11.12.13.14'
                ]
            }";

            var jsonConfigSource = new JsonConfigurationProvider(TestStreamHelpers.ArbitraryFilePath);
            jsonConfigSource.Load(TestStreamHelpers.StringToStream(json));
            
            Assert.AreEqual("1.2.3.4", jsonConfigSource.Get("ip:0"));
            Assert.AreEqual("7.8.9.10", jsonConfigSource.Get("ip:1"));
            Assert.AreEqual("11.12.13.14", jsonConfigSource.Get("ip:2"));
        }

        [Test]
        public void ArrayOfObjects()
        {
            var json = @"{
                'ip': [
                    {
                        'address': '1.2.3.4',
                        'hidden': false
                    },
                    {
                        'address': '5.6.7.8',
                        'hidden': true
                    }
                ]
            }";

            var jsonConfigSource = new JsonConfigurationProvider(TestStreamHelpers.ArbitraryFilePath);
            jsonConfigSource.Load(TestStreamHelpers.StringToStream(json));

            Assert.AreEqual("1.2.3.4", jsonConfigSource.Get("ip:0:address"));
            Assert.AreEqual("False", jsonConfigSource.Get("ip:0:hidden"));
            Assert.AreEqual("5.6.7.8", jsonConfigSource.Get("ip:1:address"));
            Assert.AreEqual("True", jsonConfigSource.Get("ip:1:hidden"));
        }

        [Test]
        public void NestedArrays()
        {
            var json = @"{
                'ip': [
                    [ 
                        '1.2.3.4',
                        '5.6.7.8'
                    ],
                    [ 
                        '9.10.11.12',
                        '13.14.15.16'
                    ],
                ]
            }";

            var jsonConfigSource = new JsonConfigurationProvider(TestStreamHelpers.ArbitraryFilePath);
            jsonConfigSource.Load(TestStreamHelpers.StringToStream(json));

            Assert.AreEqual("1.2.3.4", jsonConfigSource.Get("ip:0:0"));
            Assert.AreEqual("5.6.7.8", jsonConfigSource.Get("ip:0:1"));
            Assert.AreEqual("9.10.11.12", jsonConfigSource.Get("ip:1:0"));
            Assert.AreEqual("13.14.15.16", jsonConfigSource.Get("ip:1:1"));
        }

        [Test]
        public void ImplicitArrayItemReplacement()
        {
            var json1 = @"{
                'ip': [
                    '1.2.3.4',
                    '7.8.9.10',
                    '11.12.13.14'
                ]
            }";

            var json2 = @"{
                'ip': [
                    '15.16.17.18'
                ]
            }";

            var jsonConfigSource1 = new JsonConfigurationProvider(TestStreamHelpers.ArbitraryFilePath);
            jsonConfigSource1.Load(TestStreamHelpers.StringToStream(json1));

            var jsonConfigSource2 = new JsonConfigurationProvider(TestStreamHelpers.ArbitraryFilePath);
            jsonConfigSource2.Load(TestStreamHelpers.StringToStream(json2));

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.Add(jsonConfigSource1, load: false);
            configurationBuilder.Add(jsonConfigSource2, load: false);
            var config = configurationBuilder.Build();

            Assert.AreEqual(3, config.GetSection("ip").GetChildren().Count());
            Assert.AreEqual("15.16.17.18", config["ip:0"]);
            Assert.AreEqual("7.8.9.10", config["ip:1"]);
            Assert.AreEqual("11.12.13.14", config["ip:2"]);
        }

        [Test]
        public void ExplicitArrayReplacement()
        {
            var json1 = @"{
                'ip': [
                    '1.2.3.4',
                    '7.8.9.10',
                    '11.12.13.14'
                ]
            }";

            var json2 = @"{
                'ip': {
                    '1': '15.16.17.18'
                }
            }";

            var jsonConfigSource1 = new JsonConfigurationProvider(TestStreamHelpers.ArbitraryFilePath);
            jsonConfigSource1.Load(TestStreamHelpers.StringToStream(json1));

            var jsonConfigSource2 = new JsonConfigurationProvider(TestStreamHelpers.ArbitraryFilePath);
            jsonConfigSource2.Load(TestStreamHelpers.StringToStream(json2));

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.Add(jsonConfigSource1, load: false);
            configurationBuilder.Add(jsonConfigSource2, load: false);
            var config = configurationBuilder.Build();

            Assert.AreEqual(3, config.GetSection("ip").GetChildren().Count());
            Assert.AreEqual("1.2.3.4", config["ip:0"]);
            Assert.AreEqual("15.16.17.18", config["ip:1"]);
            Assert.AreEqual("11.12.13.14", config["ip:2"]);
        }

        [Test]
        public void ArrayMerge()
        {
            var json1 = @"{
                'ip': [
                    '1.2.3.4',
                    '7.8.9.10',
                    '11.12.13.14'
                ]
            }";

            var json2 = @"{
                'ip': {
                    '3': '15.16.17.18'
                }
            }";

            var jsonConfigSource1 = new JsonConfigurationProvider(TestStreamHelpers.ArbitraryFilePath);
            jsonConfigSource1.Load(TestStreamHelpers.StringToStream(json1));

            var jsonConfigSource2 = new JsonConfigurationProvider(TestStreamHelpers.ArbitraryFilePath);
            jsonConfigSource2.Load(TestStreamHelpers.StringToStream(json2));

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.Add(jsonConfigSource1, load: false);
            configurationBuilder.Add(jsonConfigSource2, load: false);
            var config = configurationBuilder.Build();

            Assert.AreEqual(4, config.GetSection("ip").GetChildren().Count());
            Assert.AreEqual("1.2.3.4", config["ip:0"]);
            Assert.AreEqual("7.8.9.10", config["ip:1"]);
            Assert.AreEqual("11.12.13.14", config["ip:2"]);
            Assert.AreEqual("15.16.17.18", config["ip:3"]);
        }

        [Test]
        public void ArraysAreKeptInFileOrder()
        {
            var json = @"{
                'setting': [
                    'b',
                    'a',
                    '2'
                ]
            }";

            var jsonConfigSource = new JsonConfigurationProvider(TestStreamHelpers.ArbitraryFilePath);
            jsonConfigSource.Load(TestStreamHelpers.StringToStream(json));

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.Add(jsonConfigSource, load: false);
            var config = configurationBuilder.Build();

            var configurationSection = config.GetSection("setting");
            var indexConfigurationSections = configurationSection.GetChildren().ToArray();

            Assert.AreEqual(3, indexConfigurationSections.Count());
            Assert.AreEqual("b", indexConfigurationSections[0].Value);
            Assert.AreEqual("a", indexConfigurationSections[1].Value);
            Assert.AreEqual("2", indexConfigurationSections[2].Value);
        }

        [Test]
        public void PropertiesAreSortedByNumberOnlyFirst()
        {
            var json = @"{
                'setting': {
                    'hello': 'a',
                    'bob': 'b',
                    '42': 'c',
                    '4':'d',
                    '10': 'e',
                    '1text': 'f',
                }
            }";

            var jsonConfigSource = new JsonConfigurationProvider(TestStreamHelpers.ArbitraryFilePath);
            jsonConfigSource.Load(TestStreamHelpers.StringToStream(json));

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.Add(jsonConfigSource, load: false);
            var config = configurationBuilder.Build();

            var configurationSection = config.GetSection("setting");
            var indexConfigurationSections = configurationSection.GetChildren().ToArray();

            Assert.AreEqual(6, indexConfigurationSections.Count());
            Assert.AreEqual("4", indexConfigurationSections[0].Key);
            Assert.AreEqual("10", indexConfigurationSections[1].Key);
            Assert.AreEqual("42", indexConfigurationSections[2].Key);
            Assert.AreEqual("1text", indexConfigurationSections[3].Key);
            Assert.AreEqual("bob", indexConfigurationSections[4].Key);
            Assert.AreEqual("hello", indexConfigurationSections[5].Key);
        }
    }
}
