using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;


namespace BlazorApp1.Components.Pages
{
    public partial class CreateAsset : ComponentBase
    {
        [Inject] private TradingAPIService ApiService { get; set; } = default!;

        string? response = string.Empty;

        public List<AssetClass> assetClasses = new List<AssetClass>();

        public Asset model = new Asset();
        protected async Task SubmitAsync()
        {
            model.AssetId = BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0);

            model.SMTPairs = new List<SMTPair>();
            model.Relations = new List<Relation>();
            await ApiService.
            CreateAsset(model);
        }
        protected override async Task OnInitializedAsync()
        {
            await FetchData();
        }
        protected async Task FetchData()
        {
            try{
                assetClasses = await ApiService.GetAssetClasses();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}