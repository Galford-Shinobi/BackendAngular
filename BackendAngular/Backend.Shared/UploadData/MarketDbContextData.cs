using Backend.Shared.DTO;
//using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Backend.Shared.UploadData
{
    public class MarketDbContextData
    {
        public static List<MarcadoZCUDTO> CargarDataAsync() 
        {
            try
            {
                var marcaData = File.ReadAllText(@"../Backend.Shared/UploadData/MarcadoZCU.json");

                List<MarcadoZCUDTO> person = JsonSerializer.Deserialize<List<MarcadoZCUDTO>>(marcaData);

                //using StreamReader reader = new(marcaData);
                //var json = reader.ReadToEnd();
                //List<MarcadoZCUDTO> marcadozcu = JsonConvert.DeserializeObject<List<MarcadoZCUDTO>>(json);

                return person;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
