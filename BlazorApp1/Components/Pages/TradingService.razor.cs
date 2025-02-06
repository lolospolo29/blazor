using Microsoft.AspNetCore.Components;
    public partial class TradingService 
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
