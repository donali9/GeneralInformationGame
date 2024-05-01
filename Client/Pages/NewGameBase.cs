using Microsoft.AspNetCore.Components;
using GeneralInformationGame.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace GeneralInformationGame.Client.Pages
{
    public class NewGameBase: ComponentBase
    {
        [Inject]
        public IGameService gameService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public int Count { get; set; }
        public string? Title { get; set; }
        public string? UserId { get; set; }
        [CascadingParameter] private Task<AuthenticationState>? authenticationStateTask { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo("/Login");
            }
            else
            {
                UserId = user.Identity.Name;
                this.StateHasChanged();
            }

        }
        protected async Task AddGame(GeneralInformationGame.Shared.Models.Game newGame)
        {
            try
            {
                newGame.UserId = UserId;
                var game = await gameService.AddGame(newGame);
                //GeneralInformationGame.Shared.Models.Game newGame = new GeneralInformationGame.Shared.Models.Game()
                //{
                //        Name = Title != null ? Title : "untitled",
                //        QuestionCount = Count,
                //        Date = DateTime.Now,

                //};
                //var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7213/api/Game");
                //request.Content = new StringContent(JsonSerializer.Serialize(newGame), System.Text.Encoding.UTF8, "application/json");
                //using var response = await httpClient.SendAsync(request);
                //var game = await response.Content.ReadFromJsonAsync<Game>();

                int id = game != null ? game.Id : 2;
                NavigationManager.NavigateTo($"/GameInfo/{id}");
                //var ss = await gameService.ShowGame(3);
                //int i = game.Id;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
}
