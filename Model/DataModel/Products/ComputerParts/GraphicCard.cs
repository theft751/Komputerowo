using Model.DataModel.Additional.ComputerParts;
using Model.DataModel.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.DataModel.Products.ComputerParts
{
    public class GraphicCard : Product
    {
        public PcGpuSerie GpuSerie { get; set; }
        public string VideoPorts { get; set; }

        // VideoPort jest typem enum
        public List<VideoPort> VideoPortsList
        {
            // Deserializuje z formatu json zawartość właściwości VideoPorts i zwraca typ List<VideoPort>
            get
            {
                return string.IsNullOrEmpty(VideoPorts)
                    ? new List<VideoPort>()
                    : JsonSerializer.Deserialize<List<VideoPort>>(VideoPorts, new JsonSerializerOptions
                    {
                        Converters = { new JsonStringEnumConverter() }
                    });
            }

            // Serializuje wejście typu List<VideoPort> do formatu json i zapisuje do właściwości VideoPorts
            set
            {
                VideoPorts = value == null
                    ? string.Empty
                    : JsonSerializer.Serialize(value, new JsonSerializerOptions
                    {
                        Converters = { new JsonStringEnumConverter() }
                    });
            }
        }
    }
}
