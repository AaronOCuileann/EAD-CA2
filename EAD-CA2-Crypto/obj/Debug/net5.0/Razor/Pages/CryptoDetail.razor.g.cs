#pragma checksum "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe4aa785b38235022ea1e002efe7db7652365381"
// <auto-generated/>
#pragma warning disable 1591
namespace EAD_CA2_Crypto.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\_Imports.razor"
using EAD_CA2_Crypto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\_Imports.razor"
using EAD_CA2_Crypto.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
using System.Linq;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/crypto/{cryptoId:int}")]
    public partial class CryptoDetail : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<link href=\"https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css\" rel=\"stylesheet\">\r\n\r\n");
            __builder.AddMarkupContent(1, "<style>\r\n    .scroll {\r\n        overflow: scroll;\r\n        max-height: 55vh;\r\n    }\r\n\r\n    .sort-th {\r\n        cursor: pointer;\r\n    }\r\n\r\n    .fa {\r\n        float: right;\r\n    }\r\n</style>\r\n\r\n");
            __builder.AddMarkupContent(2, "<h1>Crypto</h1>\r\n\r\n");
            __builder.AddMarkupContent(3, "<p>This table display more specific data on a crypto.</p>");
#nullable restore
#line 26 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
 if (cryptos == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(4, "<p><em>Loading...</em></p>");
#nullable restore
#line 29 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(5, "div");
            __builder.OpenElement(6, "table");
            __builder.AddAttribute(7, "class", "table table-bordered table-hover");
            __builder.AddMarkupContent(8, @"<thead><tr><th>ID</th>
                    <th>Name</th>
                    <th>Rank</th>
                    <th>Price</th>
                    <th>Change 1h</th>
                    <th>Change 24h</th>
                    <th>Change 7 days</th></tr></thead>
            ");
            __builder.OpenElement(9, "tbody");
#nullable restore
#line 46 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                 foreach (var crypto in cryptos)
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(10, "tr");
            __builder.OpenElement(11, "td");
            __builder.AddContent(12, 
#nullable restore
#line 49 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                             crypto.id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n                        ");
            __builder.OpenElement(14, "td");
            __builder.AddContent(15, 
#nullable restore
#line 50 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                             crypto.name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n                        ");
            __builder.OpenElement(17, "td");
            __builder.AddContent(18, 
#nullable restore
#line 51 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                             crypto.rank

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n                        ");
            __builder.OpenElement(20, "td");
            __builder.AddContent(21, "$ ");
            __builder.AddContent(22, 
#nullable restore
#line 52 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                               crypto.price_usd

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 53 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                         if (crypto.percent_change_1h.Contains("-"))
                        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(23, "td");
            __builder.AddAttribute(24, "style", "color:red");
            __builder.AddContent(25, 
#nullable restore
#line 55 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                                                   crypto.percent_change_1h

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(26, "%");
            __builder.CloseElement();
#nullable restore
#line 56 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(27, "td");
            __builder.AddAttribute(28, "style", "color:green");
            __builder.AddContent(29, 
#nullable restore
#line 59 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                                                     crypto.percent_change_1h

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(30, "%");
            __builder.CloseElement();
#nullable restore
#line 60 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                         if (crypto.percent_change_24h.Contains("-"))
                        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(31, "td");
            __builder.AddAttribute(32, "style", "color:red");
            __builder.AddContent(33, 
#nullable restore
#line 63 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                                                   crypto.percent_change_24h

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(34, "%");
            __builder.CloseElement();
#nullable restore
#line 64 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(35, "td");
            __builder.AddAttribute(36, "style", "color:green");
            __builder.AddContent(37, 
#nullable restore
#line 67 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                                                     crypto.percent_change_24h

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(38, "%");
            __builder.CloseElement();
#nullable restore
#line 68 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                         if (crypto.percent_change_7d.Contains("-"))
                        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(39, "td");
            __builder.AddAttribute(40, "style", "color:red");
            __builder.AddContent(41, 
#nullable restore
#line 71 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                                                   crypto.percent_change_7d

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(42, "%");
            __builder.CloseElement();
#nullable restore
#line 72 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(43, "td");
            __builder.AddAttribute(44, "style", "color:green");
            __builder.AddContent(45, 
#nullable restore
#line 75 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                                                     crypto.percent_change_7d

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(46, "%");
            __builder.CloseElement();
#nullable restore
#line 76 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 78 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(47, "\r\n        <br>\r\n        ");
            __builder.AddMarkupContent(48, "<h1>Crypto Markets</h1>\r\n        ");
            __builder.AddMarkupContent(49, "<p>This table can be sorted by the Market header.</p>\r\n        ");
            __builder.OpenElement(50, "div");
            __builder.AddAttribute(51, "class", "scroll");
            __builder.OpenElement(52, "table");
            __builder.AddAttribute(53, "class", "table table-bordered table-hover");
            __builder.OpenElement(54, "thead");
            __builder.OpenElement(55, "tr");
            __builder.OpenElement(56, "th");
            __builder.AddAttribute(57, "class", "sort-th");
            __builder.AddAttribute(58, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 88 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                                                        () => SortTable("name")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(59, "Market Name");
            __builder.OpenElement(60, "span");
            __builder.AddAttribute(61, "class", "fa" + " " + (
#nullable restore
#line 88 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                                                                                                               SetSortIcon("name")

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(62, "\r\n                        ");
            __builder.AddMarkupContent(63, "<th>Price</th>\r\n                        ");
            __builder.AddMarkupContent(64, "<th>Volume</th>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(65, "\r\n                ");
            __builder.OpenElement(66, "tbody");
#nullable restore
#line 94 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                     foreach (var crypto in cryptoMarkets)
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(67, "tr");
            __builder.OpenElement(68, "td");
            __builder.AddContent(69, 
#nullable restore
#line 97 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                                 crypto.name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(70, "\r\n                            ");
            __builder.OpenElement(71, "td");
            __builder.AddContent(72, "$ ");
            __builder.AddContent(73, 
#nullable restore
#line 98 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                                   crypto.price_usd

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(74, "\r\n                            ");
            __builder.OpenElement(75, "td");
            __builder.AddContent(76, 
#nullable restore
#line 99 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                                 crypto.volume

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 101 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 106 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 108 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\CryptoDetail.razor"
       
    [Parameter]
    public int cryptoId { get; set; }
    private bool isSortedAscending;
    private string activeSortColumn;
    private Root[] cryptos;
    private MarketRoot[] cryptoMarkets;

    protected override async Task OnInitializedAsync()
    {
        string getURL = $"https://api.coinlore.net/api/ticker/?id={cryptoId}";
        cryptos = await Http.GetFromJsonAsync<Root[]>(getURL);

        string getMarketURL = $"https://api.coinlore.net/api/coin/markets/?id={cryptoId}";
        cryptoMarkets = await Http.GetFromJsonAsync<MarketRoot[]>(getMarketURL);
    }

    public class Root
    {
        public string id { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public string nameid { get; set; }
        public int rank { get; set; }
        public string price_usd { get; set; }
        public string percent_change_24h { get; set; }
        public string percent_change_1h { get; set; }
        public string percent_change_7d { get; set; }
        public string market_cap_usd { get; set; }
        public string volume24 { get; set; }
        public string volume24_native { get; set; }
        public string csupply { get; set; }
        public string price_btc { get; set; }
        public string tsupply { get; set; }
        public string msupply { get; set; }
    }

    public class MarketRoot
    {
        public string name { get; set; }
        public string @base { get; set; }
        public string quote { get; set; }
        public double? price { get; set; }
        public double? price_usd { get; set; }
        public double? volume { get; set; }
        public double? volume_usd { get; set; }
        public int? time { get; set; }
    }

    private void SortTable(string columnName)
    {
        if (columnName != activeSortColumn)
        {
            cryptoMarkets = cryptoMarkets.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToArray();
            isSortedAscending = true;
            activeSortColumn = columnName;
        }
        else
        {
            if (isSortedAscending)
            {
                cryptoMarkets = cryptoMarkets.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToArray();
            }
            else
            {
                cryptoMarkets = cryptoMarkets.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToArray();
            }
            isSortedAscending = !isSortedAscending;
        }
    }

    private string SetSortIcon(string columnName)
    {
        if (activeSortColumn != columnName)
        {
            return string.Empty;
        }
        if (isSortedAscending)
        {
            return "fa-sort-up";
        }
        else
        {
            return "fa-sort-down";
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591