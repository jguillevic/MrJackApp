using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace MrJackApp.Serialization.Json
{
    public sealed class JsonSerializer
    {
        /// <summary>
        /// Données à sérialiser.
        /// </summary>
        public object InputData { get; set; }
        /// <summary>
        /// Flux de retour contenant le résultat de la sérialisation.
        /// A renseigner car non généré au cours du process de sérialisation.
        /// </summary>
        public Stream OutputStream { get; set; }
        public bool IsIndent { get; set; }

        public void Serialize()
        {
            using (var sw = new StreamWriter(OutputStream, Encoding.UTF8, 512, true))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    var serializer = Newtonsoft.Json.JsonSerializer.CreateDefault();
                    serializer.Formatting = IsIndent ? Formatting.None : Formatting.Indented;
                    serializer.Serialize(jw, InputData);
                }
            }
        }
    }
}
