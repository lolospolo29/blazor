using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;


namespace BlazorApp1.Components.Pages
{
    public partial class CreateBacktest : ComponentBase
    {
        [Inject] private TradingAPIService ApiService { get; set; } = default!;

        string? response = string.Empty;

        string? strategy = string.Empty;

        public List<Result> results = new List<Result>();

        public List<string> strategies = new List<string>();

        public List<string> assets = new List<string>();

        public BacktestInput model = new BacktestInput();
        protected async Task SubmitAsync()
        {
            await ApiService.RunBackest(model);
        }

        protected Task ToggleSelection(string asset, ChangeEventArgs e)
        {
            if ((bool)e.Value)
            {
                model.TestAssets.Add(asset);
                return Task.CompletedTask;
            }
            else
            {
                model.TestAssets.Remove(asset);
                return Task.CompletedTask;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await FetchData();
        }
        protected async Task FetchData()
        {
            try
            {
                strategies = await ApiService.GetStrategies();
                strategies.Add("");
                assets = await ApiService.GetAssetSelection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected async Task OnButtonClick()
        {
            results = await ApiService.GetTestResults(strategy);
        }
    }
}