using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Template_4335.Class
{
    public enum SkiServiceType
    {
        [EnumMember(Value = "Прокат")]
        Rent,

        [EnumMember(Value = "Подъем")]
        Uphill,

        [EnumMember(Value = "Обучение")]
        Training
    }

    public static class SkiServiceTypeExtensions
    {
        public static SkiServiceType? ToSkiServiceType(this string str)
        {
            switch (str.Trim())
            {
                case "Прокат":
                    {
                        return SkiServiceType.Rent;
                    }
                case "Обучение":
                    {
                        return SkiServiceType.Training;
                    }
                case "Подъем":
                    {
                        return SkiServiceType.Uphill;
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}