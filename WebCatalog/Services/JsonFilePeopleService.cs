using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebCatalog.Models;

namespace WebCatalog.Services
{
    public class JsonFilePeopleService
    {
        public JsonFilePeopleService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnviroment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnviroment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnviroment.WebRootPath, "data", "people.json"); }
        }

        public IEnumerable<Person> GetPeople()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Person[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        
        public void AddProperty<T>(int product_id, string property_name, T property_value)
        {
            var people = GetPeople();

            var query = people.First(x => x.ID == product_id);

            if(query.AdditionalProperties == null)
            {
                query.AdditionalProperties = new Dictionary<string, string>();
            }
            else
            {
                query.AdditionalProperties.Add(property_name, property_value.ToString());
            }

            using var outputStream = File.OpenWrite(JsonFileName);
            JsonSerializer.Serialize(
                new Utf8JsonWriter(outputStream, new JsonWriterOptions
                { 
                    SkipValidation = true,
                    Indented = true     
                }),
                people
                );

            
        }
    }
} 
