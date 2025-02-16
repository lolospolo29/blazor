using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;


namespace BlazorApp1.Components.Pages
{
    public partial class ConfigureSMT : ComponentBase
    {
        [Inject] private TradingAPIService ApiService { get; set; } = default!;

        string? response = string.Empty;

        public List<SMTPair> smtPair = new List<SMTPair>();

        protected override async Task OnInitializedAsync()
        {
            await FetchData();
        }
        protected async Task FetchData()
        {
            try
            {
                smtPair = await ApiService.GetSMTPairs();
            }
            catch (Exception ex)
            {
                response = $"Error: {ex.Message}";
            }
        }
        protected async Task DeleteAsset(SMTPair pair )
        {
            try
            {
                await ApiService.DeleteSMTPair(pair);
                Thread.Sleep(5000);
                await FetchData();
            }
            catch (Exception ex)
            {
                response = $"Error: {ex.Message}";
            }
        }
    }
}