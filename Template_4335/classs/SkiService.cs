using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_4335.Class
{
    public class SkiService : Entity
    {
        [JsonProperty("IdServices")]
        public override int Id { get; set; }

        [JsonProperty("NameServices")]
        public string ServiceName { get; set; }

        [JsonProperty("CodeService")]
        public string ServiceCode { get; set; }

        [JsonProperty("TypeOfService")]
        public SkiServiceType ServiceType { get; set; }

        [JsonProperty("Cost")]
        public decimal PriceForHour { get; set; }

        public SkiService() { }

        public SkiService(int id, string serviceName, string serviceCode, string serviceType, decimal priceForHour)
        {
            SkiServiceType? type = serviceType.ToSkiServiceType();

            if (type is null)
                throw new ArgumentException("Нет такого вида услуг", nameof(serviceType));

            Id = id;
            ServiceName = serviceName;
            ServiceCode = serviceCode;
            ServiceType = type.Value;
            PriceForHour = priceForHour;
        }
    }
}