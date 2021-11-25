using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Lib.WebUI.Webpack
{
    public class WebpackChunkNamer
    {
        private static Dictionary<string, string> Tags { get; set; } = new Dictionary<string, string>();
        private static byte[] oldHash;
        private static byte[] newHash;
        private static readonly string ManifestPath = Startup.Configuration.GetSection("AppSettings")["ManifestJsonPath"];
        private static string BaseDirectoryManifestPath = Path.Combine(AppContext.BaseDirectory, ManifestPath);

        public static void Init()
        {
            try
            {
                using (var fs = File.OpenRead(BaseDirectoryManifestPath))
                using (var sr = new StreamReader(fs))
                using (var reader = new JsonTextReader(sr))
                using (var md5 = MD5.Create())
                {
                    JObject obj = JObject.Load(reader);

                    if (Tags != null && Tags.Any())
                    {
                        Tags = new Dictionary<string, string>();
                    }
                    foreach (var chunk in obj)
                    {
                        Tags.Add(chunk.Key, chunk.Value.ToString());
                    }
                    fs.Position = 0;
                    oldHash = md5.ComputeHash(fs);
                }
            }
            catch
            {

            }
        }

        public static string GetJsFile(string filename)
        {
            WebpackChunkNamer.Check();
            var element = Tags.FirstOrDefault(x => x.Key == $"{filename}.js");
            return element.Value ?? string.Empty;
        }

        public static string GetCssFile(string filename)
        {
            WebpackChunkNamer.Check();
            var element = Tags.FirstOrDefault(x => x.Key == $"{filename}.css");
            return element.Value ?? string.Empty;
        }

        private static void Check()
        {
            try
            {
                using (var fs = File.OpenRead(BaseDirectoryManifestPath))
                {
                    using (var md5 = MD5.Create())
                    {
                        newHash = md5.ComputeHash(fs);

                        if (!newHash.SequenceEqual(oldHash))
                        {
                            WebpackChunkNamer.Init();
                        }
                    }
                }
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
