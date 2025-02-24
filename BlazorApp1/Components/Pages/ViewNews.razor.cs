using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;


namespace BlazorApp1.Components.Pages
{
    public partial class ViewNews : ComponentBase
    {
        [Inject] private TradingAPIService ApiService { get; set; } = default!;

        string? response = string.Empty;

        public bool IsEditing { get; set; } = false;

        public List<NewsDay> news = new List<NewsDay>();


        protected override async Task OnInitializedAsync()
        {
            await FetchData();
        }
        protected async Task FetchData()
        {
            try
            {
                news = await ApiService.GetNews();
            }
            catch (Exception ex)
            {
                response = $"Error: {ex.Message}";
            }
        }
    }
}