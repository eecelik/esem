using Business.Abstract;
using Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MapManager : Requests, IMapService
    {
        public void FillAddress(Product product)
        {
            if (string.IsNullOrEmpty(product.LongLat)) return;

            Get("https://maps.googleapis.com/maps/api/geocode/json?key=AIzaSyAPqHn3BB_UHwBnIvLef6Zs_oNhn-A9X4s&latlng=" + product.LongLat);

            JObject json = JsonConvert.DeserializeObject(source) as JObject;

            product.City = json["results"]["address_components"][4]["long_name"].ToString();
            product.FormattedAddress = json["results"]["formatted_address"].ToString();
        }
    }
}
