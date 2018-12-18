using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [EnableCors(origins: "http://198.24.161.132", headers: "*", methods: "*")]

    public class CorreiosController : ApiController
    {

        public class RetornoCEP
        {
            public string cep { get; set; }
            public string logradouro { get; set; }
            public string complemento { get; set; }
            public string bairro { get; set; }
            public string localidade { get; set; }
            public string uf { get; set; }
            public string ibge { get; set; }
            public List<Temperatura> temperaturas { get; set; } = new List<Temperatura>();

        }

        public class Temperatura
        {
            public string data { get; set; }
            public string diaSemana { get; set; }
            public string max { get; set; }
            public string min { get; set; }
            public string descricao { get; set; }

        }

        public class Forecast
        {
            public string date { get; set; }
            public string weekday { get; set; }
            public string max { get; set; }
            public string min { get; set; }
            public string description { get; set; }
            public string condition { get; set; }
        }


        public class Results
        {
            public int temp { get; set; }
            public string date { get; set; }
            public string time { get; set; }
            public string condition_code { get; set; }
            public string description { get; set; }
            public string currently { get; set; }
            public string cid { get; set; }
            public string city { get; set; }
            public string img_id { get; set; }
            public string humidity { get; set; }
            public string wind_speedy { get; set; }
            public string sunrise { get; set; }
            public string sunset { get; set; }
            public string condition_slug { get; set; }
            public string city_name { get; set; }
            public List<Forecast> forecast { get; set; }
        }

        public class RootObject
        {
            public string by { get; set; }
            public bool valid_key { get; set; }
            public Results results { get; set; }
            public double execution_time { get; set; }
            public bool from_cache { get; set; }
        }

        [HttpGet]
        [Route("api/correios/cep/{cep}")]
        [ResponseType(typeof(RetornoCEP))]
        [EnableCors(origins: "http://198.24.161.132", headers: "*", methods: "*")]

        public async System.Threading.Tasks.Task<HttpResponseMessage> ConsultaCEPAsync(int cep)
        {
            RetornoCEP retorno = new RetornoCEP();
            try
            {

                #region BuscaCEP
                string url = "https://viacep.com.br/ws/" + cep + "/json/";
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(url);

                //Converte resposta do serviço em objeto
                retorno = JsonConvert.DeserializeObject<RetornoCEP>(response);
                #endregion




                if (retorno == null)
                {
                    retorno.cep = "15105000";
                    retorno.bairro = "Centro";
                    retorno.ibge = "11111";
                    retorno.localidade = "Potirendaba";
                    retorno.uf = "SP";
                    retorno.logradouro = "Rua fim do mundo";
                }
            }
            catch (System.Exception)
            {
                retorno.cep = "15105000";
                retorno.bairro = "Centro";
                retorno.ibge = "11111";
                retorno.localidade = "Potirendaba";
                retorno.uf = "SP";
                retorno.logradouro = "Rua fim do mundo";
            }

            try
            {
                #region BuscaClima


                string url = " https://api.hgbrasil.com/weather/?format=json&city_name=" + retorno.localidade + "&key=3d41dc44";
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(url);

                //Converte resposta do serviço em objeto
                var retClima = JsonConvert.DeserializeObject<RootObject>(response);

                foreach (var item in retClima.results.forecast)
                {
                    Temperatura temp = new Temperatura();

                    temp.data = item.date;
                    temp.descricao = item.description;
                    temp.diaSemana = item.weekday;
                    temp.min = item.min;
                    temp.max = item.max;

                    retorno.temperaturas.Add(temp);

                }

                #endregion
            }
            catch (System.Exception)
            {
                Temperatura temp = new Temperatura();

                temp.data = "18/12";
                temp.descricao = "Tempestades isoladas";
                temp.diaSemana = "Ter";
                temp.min = "23";
                temp.max = "33";

                retorno.temperaturas.Add(temp);
            }
            if (retorno.temperaturas.Count == 0)
            {
                Temperatura temp = new Temperatura();

                temp.data = "18/12";
                temp.descricao = "Tempestades isoladas";
                temp.diaSemana = "Ter";
                temp.min = "23";
                temp.max = "33";

                retorno.temperaturas.Add(temp);
            }
            return Request.CreateResponse(HttpStatusCode.OK, retorno);


        }

    }
}
