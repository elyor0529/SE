using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SE.Common.Helpers;

namespace SE.Common
{
    public static class MainSettings
    {
        public const string DatabaesConnectionStringName = "DefaultConnection";

        public static readonly bool IsProductionMode = (ConfigurationHelper.GetValue<int>("IsProductionMode") == 1);

        public static readonly CultureInfo CoreDefaulCulture = new CultureInfo("EN-US");

        public static void SetupCulture()
        {
            Thread.CurrentThread.CurrentCulture = CoreDefaulCulture;
            Thread.CurrentThread.CurrentUICulture = CoreDefaulCulture;
        }

        public static string GetRoot()
        {
            var uri = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase);
            var directory = Path.GetDirectoryName(uri.LocalPath);

            return directory;
        }

    }
}
