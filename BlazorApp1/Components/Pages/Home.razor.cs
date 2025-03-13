using Microsoft.AspNetCore.Components;

using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace BlazorApp1.Components.Pages
{
    public partial class Home : ComponentBase
    {
        
        [Inject] private TradingAPIService ApiService { get; set; } = default!;

        string? response = string.Empty;

        public List<Trade> trades = new List<Trade>();

        protected override async Task OnInitializedAsync()
        {
            await FetchData();
        }
        protected async Task FetchData()
        {
            try
            {
                trades = await ApiService.GetTrades();
            }
            catch (Exception ex)
            {
                response = $"Error: {ex.Message}";
            }
        }
    }
}