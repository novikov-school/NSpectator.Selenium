﻿using NUnit.Framework;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup.Environments;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Tests.Shared.Hosting
{
    [TestFixture]
    public class HostThreadedSessionFixture : HostTestFixture, ITestSpec
    {
        [TestFixtureSetUp]
        public override void Init()
        {
            base.Init();

            Before();
        }

        [TestFixtureTearDown]
        public override void Dispose()
        {
            After();

            Threaded<Session>
                .End();

            base.Dispose();
        }

        public virtual void Before()
        {
            
        }

        public virtual void After()
        {
            
        }
    }
}