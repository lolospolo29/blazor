using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;


namespace BlazorApp1.Components.Pages
{
    public partial class ConfigureSMT : ComponentBase
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

        public Asset model = new Asset();

        public List<Strategy> strategies = new();

        public List<SMTPair> smtPairs = new();

        public List<Asset> assets = new();

        public SMTPair currentPair = new("","","","");

        protected async Task SubmitAsync()
        {
            Console.WriteLine(model.ToJson() + smtPairs.Count);
        }

        protected async Task AddSMTAsync()
        {
            currentPair.AssetA = model.Name;
            smtPairs.Add(currentPair);
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