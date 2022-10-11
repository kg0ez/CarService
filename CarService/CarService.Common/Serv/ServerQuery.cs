using System;
using CarService.Common.Enums;

namespace CarService.Common.Serv
{
    [Serializable]
    public class ServerQuery
    {
        public QueryType Type { get; set; }

        public string TypeAction { get; set; }

        public string Object { get; set; }
    }
}

