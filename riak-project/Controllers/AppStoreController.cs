using Newtonsoft.Json;
using RiakClient;
using RiakClient.Models;
using RiakProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RiakProject.Controllers
{
    public class AppStoreController
    {
        private string _bucket;
        private IRiakClient _client;

        public AppStoreController()
        {
            _bucket = "AppStore";
            IRiakEndPoint endpoint = RiakCluster.FromConfig("riakConfig");
            _client = endpoint.CreateClient();
        }

        public void ImportData()
        {
            try
            {
                string pathJson = @"D:\Personal\dai-hoc\chuyen-nganh\nhap-mon-du-lieu-lon\bao-cao-cuoi-ki-final\riak-project\Data\AppleStore.json";

                string json = File.ReadAllText(pathJson);

                List<AppStore> appStores = JsonConvert.DeserializeObject<List<AppStore>>(json);

                Console.WriteLine("Import app data");

                foreach (var appStore in appStores)
                {
                    var riakObjectId = new RiakObjectId(_bucket, appStore.Id.ToString());
                    var riakObject = new RiakObject(riakObjectId, appStore);
                    _client.Put(riakObject);
                }
                Console.WriteLine("Import data success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
        }

        public void GetById(long id)
        {
            try
            {
                var result = _client.Get(_bucket, id.ToString());
                if (result.IsSuccess)
                {
                    Console.WriteLine($"AppStore {id}: {GetValueAsString(result)}\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
        }

        public void Create(AppStore appStore)
        {
            try
            {
                Console.WriteLine("Update");
                var riakObject = new RiakObject(_bucket, appStore.Id.ToString(), appStore);
                var result = _client.Put(riakObject);
                if (result.IsSuccess)
                {
                    Console.WriteLine("Create data success");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
        }

        public void Update(long id, AppStore appStore)
        {
            try
            {
                Console.WriteLine("Update");
                var riakObject = new RiakObject(_bucket, id.ToString(), appStore);
                var result = _client.Put(riakObject);
                if (result.IsSuccess)
                {
                    Console.WriteLine("Update data success");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
        }

        public void Delete(long id)
        {
            try
            {
                Console.WriteLine("Delete");
                var result = _client.Delete(_bucket, id.ToString());
                if (result.IsSuccess)
                {
                    Console.WriteLine("Delete data success");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.Message);
            }
        }

        private string GetValueAsString(RiakResult<RiakObject> result)
        {
            string rv = string.Empty;

            if (result.IsSuccess)
            {
                RiakObject riakObject = result.Value;
                rv = Encoding.UTF8.GetString(riakObject.Value);
            }
            else
            {
                rv = "ERROR";
            }

            return rv;
        }
        
    }
}
