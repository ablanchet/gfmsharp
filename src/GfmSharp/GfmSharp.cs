using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GfmSharp
{
    public class GfmSharpMessage
    {
        public static class Modes
        {
            public const string Markdown = "markdown";
            public const string Gfm = "gfm";
        }

        [JsonProperty( PropertyName = "text" )]
        public string Text { get; set; }

        [JsonProperty( PropertyName = "mode" )]
        public string Mode { get; set; }

        [JsonProperty( PropertyName = "context" )]
        public string Context { get; set; }
    }

    public class GfmSharp
    {
        const string _apiUrl = "https://api.github.com/markdown";

        public static async Task<string> GetHtml( string mdDontent )
        {
            return await GetHtml( new GfmSharpMessage { Mode = GfmSharpMessage.Modes.Markdown, Text = mdDontent } );
        }

        public static async Task<string> GetHtml( GfmSharpMessage message )
        {
            string jsonmessage = JsonConvert.SerializeObject( message );
            HttpContent content = new StringContent( jsonmessage );

            return await GetContent( content );
        }

        static async Task<string> GetContent( HttpContent content )
        {
            using( var c = new HttpClient() )
            {
                c.DefaultRequestHeaders.UserAgent.Add( new ProductInfoHeaderValue( "gfmsharp-api", "0.9.0" ) );

                HttpResponseMessage response = await c.PostAsync( _apiUrl, content );
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
