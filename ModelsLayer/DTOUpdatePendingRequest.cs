using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class DTOUpdatePendingRequest
    {
        [JsonPropertyName("ticketid")]
        public int TicketId {get; set;}

        [JsonPropertyName("status")]
        public string? Status {get; set;}
    }
}