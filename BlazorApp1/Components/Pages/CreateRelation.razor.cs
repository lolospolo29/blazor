using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;


namespace BlazorApp1.Components.Pages
{
    public partial class CreateRelation : ComponentBase
    {
        [Inject] private TradingAPIService ApiService { get; set; } = default!;
        string? response = string.Empty;

        public List<string> strategies = new List<string>();

        public List<Asset> assets = new List<Asset>();

        public List<Broker> brokers = new List<Broker>();

        public List<Category> categories = new List<Category>();

        public Relation model = new Relation();
        protected async Task SubmitAsync()
        {
            model.Id = BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0);

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
                categories = await ApiService.GetCategories();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}