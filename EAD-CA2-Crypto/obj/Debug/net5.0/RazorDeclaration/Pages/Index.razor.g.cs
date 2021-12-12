// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
#line 3 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\Index.razor"
using System.Linq;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 68 "C:\Users\aaron\EAD-CA2\EAD-CA2-Crypto\Pages\Index.razor"
       
    private Root cryptos;
    private Root filteredCryptos;
    private string selectedSort;
    public string SelectedSort
    {
        get { return selectedSort; }
        set
        {
            selectedSort = value;
            selectedSortDict[selectedSort]();
        }
    }
    Dictionary<string, Action> selectedSortDict;

    protected override async Task OnInitializedAsync()
    {
        //there are only 100 crypto currerncies in this API, set limit to max
        cryptos = await Http.GetFromJsonAsync<Root>("https://api.coinlore.net/api/tickers/?start=0&limit=100");
        filteredCryptos = cryptos;
        selectedSortDict = new Dictionary<string, Action>
        {
            ["idAsc"] = () => filteredCryptos.data = filteredCryptos.data.OrderBy(a => a.id.Length).ThenBy(a => a.id).ToList(),
            ["idDesc"] = () => filteredCryptos.data = filteredCryptos.data.OrderByDescending(a => a.id.Length).ThenByDescending(a => a.id).ToList(),
            ["nameAsc"] = () => filteredCryptos.data = filteredCryptos.data.OrderBy(a => a.name).ToList(),
            ["nameDesc"] = () => filteredCryptos.data = filteredCryptos.data.OrderByDescending(a => a.name).ToList(),
            ["rankAsc"] = () => filteredCryptos.data = filteredCryptos.data.OrderBy(a => a.rank).ToList(),
            ["rankDesc"] = () => filteredCryptos.data = filteredCryptos.data.OrderByDescending(a => a.rank).ToList(),
            ["priceAsc"] = () => filteredCryptos.data = filteredCryptos.data.OrderBy(a => decimal.Parse(a.price_usd)).ToList(),
            ["priceDesc"] = () => filteredCryptos.data = filteredCryptos.data.OrderByDescending(a => decimal.Parse(a.price_usd)).ToList(),
        };
    }

    public class Datum
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
        public string price_btc { get; set; }
        public string market_cap_usd { get; set; }
        public double volume24 { get; set; }
        public double volume24a { get; set; }
        public string csupply { get; set; }
        public string tsupply { get; set; }
        public string msupply { get; set; }
    }

    public class Info
    {
        public int coins_num { get; set; }
        public int time { get; set; }
    }

    public class Root
    {
        public List<Datum> data { get; set; }
        public Info info { get; set; }
    }

    private async void OnSearchTextChange(ChangeEventArgs changeEventArgs)
    {
        string searchText = changeEventArgs.Value.ToString();
        Console.WriteLine(searchText);

        filteredCryptos.data = cryptos.data.Where(crypto => crypto.name.Contains(searchText)).ToList();
        Console.WriteLine(cryptos.data.Count());
        Console.WriteLine(filteredCryptos.data.Count());
        cryptos = await Http.GetFromJsonAsync<Root>("https://api.coinlore.net/api/tickers/?start=0&limit=100");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
