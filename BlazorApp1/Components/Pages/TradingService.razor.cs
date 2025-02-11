using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Components.Pages
{
    public partial class TradingService : ComponentBase
    {
        [Inject] private TradingAPIService ApiService { get; set; } = default!;

        protected List<Trade> Trades { get; set; } = new List<Trade>();

        protected List<Asset> _Assets { get; set; } = new List<Asset>();

        protected string PostResponseMessage { get; set; } = "";
        protected string ResponseMessage { get; set; } = "";

        protected async Task FetchTrades()
        {
            try
            {
                Trades = await ApiService.GetTrades();
            }
            catch (Exception ex)
            {
                ResponseMessage = $"Error: {ex.Message}";
            }
        }

        protected async Task FetchAssets()
        {
            try
            {
                _Assets = await ApiService.GetAssets();
            }
            catch (Exception ex)
            {
                ResponseMessage = $"Error: {ex.Message}";
            }
        }
        protected async Task SendData()
        {
            try
            {
                await ApiService.SendData();
                PostResponseMessage = "Data sent successfully!";
            }
            catch (Exception ex)
            {
                PostResponseMessage = $"Error: {ex.Message}";
            }
        }
    }
}