using System;
using System.IO;
using System.Reflection;
using Nancy;

namespace OpenQA.Selenite.Tests.Shared.Hosting
{
    public class TestRootPathProvider : IRootPathProvider
    {
        public static string WorkingDirectory
        {
            get
            {
                return DirectoryOf(Assembly.GetExecutingAssembly());
            }
        }

        private static string DirectoryOf(Assembly assembly)
        {
            string filePath = new Uri(assembly.CodeBase).LocalPath;
            return Path.GetDirectoryName(filePath);
        }

        public string GetRootPath()
        {
            return WorkingDirectory;
        }
    }

    public class TestBootstrapper : DefaultNancyBootstrapper
    {
        protected override IRootPathProvider RootPathProvider
        {
            get { return new TestRootPathProvider(); }
        }
    }
}