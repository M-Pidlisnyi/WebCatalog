using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebCatalog.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }

        private DateTime birthDate;
        public DateTime BirthDate { 
            get { return birthDate.Date; }
            set { birthDate = value; } 
        }
        public string Role { get; set; }
        public string Image { get; set; }

        [JsonPropertyName("onFrontPage")]
        public bool IsOnFrontPage { get; set; }

        public Dictionary<string, string> AdditionalProperties { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
       
    }
}
