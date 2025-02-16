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
            try
            {
                relations = await ApiService.GetRelations();
            }
            catch (Exception ex)
            {
                response = $"Error: {ex.Message}";
            }
        }

        protected async Task DeleteRelation(Relation relation)
        {
            try
            {
                await ApiService.DeleteRelation(relation);
                Thread.Sleep(5000);
                await FetchData();
            }
            catch (Exception ex)
            {
                response = $"Error: {ex.Message}";
            }
        }
        protected async Task UpdateRelation(Relation relation )
        {
            try
            {
                await ApiService.UpdateRelation(relation);
                Thread.Sleep(5000);
                await FetchData();
            }
            catch (Exception ex)
            {
                response = $"Error: {ex.Message}";
            }
        }
        protected async Task EditRelation()
        {
            IsEditing = true;
        }
    }
}