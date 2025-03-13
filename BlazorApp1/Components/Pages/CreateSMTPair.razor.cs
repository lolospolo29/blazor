using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;


namespace BlazorApp1.Components.Pages
{
    public partial class CreateSMTPair : ComponentBase
    {
        [Inject] private TradingAPIService ApiService { get; set; } = default!;

        public enum AssetClass
        {
            FX = 1,
            Crypto = 2,
            Indice = 3,
        }

        public enum Correlation
        {
            Positive = 1,
            Negative = 2,
        }

        public List<string> strategies = new();

        public List<Asset> assets = new();

        public SMTPair smtPair = new("","","","");

        protected override async Task OnInitializedAsync()
        {
            await FetchData();
        }

        protected async Task AddSMTAsync()
        {
            await ApiService.CreateSMTPair(smtPair);
        }

        protected async Task FetchData()
        {
            try{
                strategies = await ApiService.GetStrategies();
                assets = await ApiService.GetAssets();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}