using GeneralInformationGame.Client.Services;
using GeneralInformationGame.Shared.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using System.Net.Http;
using System.Text;
using RestSharp;
using System.Text.Json.Serialization;
using System;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;
using GeneralInformationGame.Shared.ViewModels;
using System.Drawing;

namespace GeneralInformationGame.Client.Actions
{
    public class GameService : IGameService
    {
        private readonly HttpClient httpClient;
        public GameService(HttpClient Httpclient)
        {
            this.httpClient = Httpclient;
        }
        public async Task<Game?> AddGame(Game newGame)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<Game>("api/Game", newGame);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(Game);
                    }

                    return await response.Content.ReadFromJsonAsync<Game>();

                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception ex)
            {

                throw(ex);
            }
            
        }

        public async Task<Game?> ShowGame(int id,string email)
        {
            var response = await httpClient.GetFromJsonAsync<Game>($"api/Game/{id}/{email}");
            return response;
            //return await response.Content.ReadFromJsonAsync<Game>();
        }
        public async Task<QuestionViewModel?> ShowQuestion(int id)
        {
            var response = await httpClient.GetFromJsonAsync<QuestionViewModel>($"api/question/{id}");
            return response;
        }

        public async Task<Participant?> AddParticipant(Participant participant)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<Participant>("api/Participant", participant);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(Participant);
                    }

                    return await response.Content.ReadFromJsonAsync<Participant>();

                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public async Task RemoveParticipant(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/Participant/{id}");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SaveQuestionResult(bool result, int participantId)
        {
            var response = await httpClient.PutAsJsonAsync($"api/Participant/{participantId}",result);
        }

        public async Task<List<Game>> GetAllGames(int page, int size,string email)
        {
            var response = await httpClient.GetFromJsonAsync<List<Game>>($"api/Game/{page}/{size}/{email}");
            return response;
        }
        public async Task<int> GetGamesCount(string email)
        {
            var response = await httpClient.GetFromJsonAsync<int>($"api/Game/{email}");
            return response;
        }
    }
}
