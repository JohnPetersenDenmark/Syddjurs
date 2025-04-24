using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Syddjurs.Models
{
    public class ItemInListDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }


        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lendable")]
        public bool Lendable { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        public bool IsSelected { get; set; }
    }
}
