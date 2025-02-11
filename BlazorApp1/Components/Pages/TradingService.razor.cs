using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Components.Pages
{
    public partial class TradingService : ComponentBase
    {
        [Inject] private TradingAPIService ApiService { get; set; } = default!;

        protected string ResponseMessage { get; set; } = "";

        protected async Task FetchData()
        {
            try
            {
                ResponseMessage = await ApiService.GetFlaskDataAsync();
            }
            catch (Exception ex)
            {
                ResponseMessage = $"Error: {ex.Message}";
            }
        }
    }
}