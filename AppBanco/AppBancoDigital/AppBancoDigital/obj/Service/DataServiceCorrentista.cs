using AppBancoDigital.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDigital.Service
{
    public class DataServiceCorrentista : DataService
    {
        public static async Task<Correntista> LoginAsync(Correntista c)
        {
            var json_to_send = JsonConvert.SerializeObject(c);

            string json = await DataService.GetDataFromService(String.Format("/correntista/login?cpf={0}&senha={1}", c.CPF, c.Senha));
                
            return JsonConvert.DeserializeObject<Correntista>(json);
        }
        public static async Task<Correntista> CadastrarCorrentistas(Correntista c)
        {
            var json_to_send = JsonConvert.SerializeObject(c);

            string json = await DataService.PostDataToService(json_to_send, "/correntista/save");

            return JsonConvert.DeserializeObject<Correntista>(json);
        }
    }
}
