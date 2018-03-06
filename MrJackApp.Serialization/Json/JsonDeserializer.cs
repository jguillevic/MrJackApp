using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace MrJackApp.Serialization.Json
{
    public sealed class JsonDeserializer<T>
    {
        public T OutputData { get; private set; }
        public Stream InputStream { get; set; }

        public void Deserialize()
        {
            using (var sr = new StreamReader(InputStream, Encoding.UTF8, false, 512, true))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    OutputData = Newtonsoft.Json.JsonSerializer.CreateDefault().Deserialize<T>(jr);
                }
            }
        }
    }
}
