using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;


namespace BlazorApp1.Components.Pages
{
    public partial class ConfigureAssets : ComponentBase
    {
        [Inject] private TradingAPIService ApiService { get; set; } = default!;

        string? response = string.Empty;

        public bool IsEditing { get; set; } = false;

        public List<Asset> assets = new List<Asset>();

        public Asset currentAsset = new Asset();

        protected override async Task OnInitializedAsync()
        {
            await FetchData();
        }
        protected async Task FetchData()
        {
            try
            {
                assets = await ApiService.GetAssets();
            }
            catch (Exception ex)
            {
                response = $"Error: {ex.Message}";
            }
        }
        protected async Task DeleteAsset(Asset asset )
        {
            try
            {
                await ApiService.DeleteAsset(asset);
                Thread.Sleep(5000);
                await FetchData();
            }
            catch (Exception ex)
            {
                response = $"Error: {ex.Message}";
            }
        }
        protected async Task UpdateAsset(Asset asset )
        {
            try
            {
                await ApiService.UpdateAsset(asset);
                Thread.Sleep(5000);
                await FetchData();
            }
            catch (Exception ex)
            {
                response = $"Error: {ex.Message}";
            }
        }
        protected async Task EditAsset(Asset asset)
        {
            IsEditing = true;
        }

    }
}