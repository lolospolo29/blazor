using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;


namespace BlazorApp1.Components.Pages
{
    public partial class CreateAsset : ComponentBase
    {
        [Inject] private TradingAPIService ApiService { get; set; } = default!;

        public enum AssetClass
        {
            FX = 1,
            Crypto = 2,
            Indice = 3,
        }

        string? response = string.Empty;

        public Asset model = new Asset();
        protected async Task SubmitAsync()
        {
            model.SMTPairs = new List<SMTPair>();
            model.Relations = new List<Relation>();
            await ApiService.CreateAsset(model);
        }
    }
}