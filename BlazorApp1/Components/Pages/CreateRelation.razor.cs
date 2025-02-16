using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;


namespace BlazorApp1.Components.Pages
{
    public partial class CreateRelation : ComponentBase
    {
        [Inject] private TradingAPIService ApiService { get; set; } = default!;

        public enum AssetClass
        {
            FX = 1,
            Crypto = 2,
            Indice = 3,
        }

        string? response = string.Empty;

        public List<Strategy> strategies = new List<Strategy>();

        public List<Asset> assets = new List<Asset>();

        public List<Broker> brokers = new List<Broker>();

        public Relation model = new Relation();
        protected async Task SubmitAsync()
        {
            await ApiService.CreateRelation(model);
        }

        protected override async Task OnInitializedAsync()
        {
            await FetchData();
        }
        protected async Task FetchData()
        {
            try{
                strategies = await ApiService.GetStrategies();
                assets = await ApiService.GetAssets();
                brokers = await ApiService.GetBrokers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}