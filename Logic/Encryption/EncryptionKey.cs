using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Encryption
{
    public class EncryptionKey
    {
        internal string key;
        internal static bool useHashing = true;
        public EncryptionKey()
        {
            //var configuration = GetConfiguration();
            //key = configuration.GetSection("AppSecurity").GetSection("SecurityKey").Value;
            key = "E546C8DF278CD5931069B522E695D4F2";
        }

        //private IConfigurationRoot GetConfiguration()
        //{
        //    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //    return builder.Build();
        //}
    }
}
