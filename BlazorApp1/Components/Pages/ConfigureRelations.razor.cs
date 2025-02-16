using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;


namespace BlazorApp1.Components.Pages
{
    public partial class ConfigureRelations : ComponentBase
    {
        [Inject] private TradingAPIService ApiService { get; set; } = default!;

        string? response = string.Empty;

        public bool IsEditing { get; set; } = false;

        public List<Relation> relations = new List<Relation>();

        protected override async Task OnInitializedAsync()
        {
            await FetchData();
        }
        protected async Task FetchData()
        {
            relations = await ApiService.GetRelations();
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
        protected async Task EditAsset()
        {
            IsEditing = true;
        }

    }
}