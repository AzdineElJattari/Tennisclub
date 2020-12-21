﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using TennisClub.DTO.Game;

namespace TennisClub.UI.Api
{
    public static class GameAPI
    {
        public static async Task<List<GameDTO>> GetGames()
        {
            string fullUri = $"{ApiHelper.BASEURL}game";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(fullUri))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<GameDTO>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public static async Task CreateGame(GameCreateDTO game)
        {
            string fullUri = $"{ApiHelper.BASEURL}game/create";
            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(fullUri, game))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                    else
                    {
                        MessageBox.Show($"Wedstrijd is succesvol ingeplant!", "Informatie", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static async Task DeleteGame(int id)
        {
            string fullUri = $"{ApiHelper.BASEURL}game/{id}";
            MessageBoxResult messageBoxResult = MessageBox.Show($"Bent u zeker dat u de wedstrijd met id: {id} wilt verwijderen?", "Waarschuwing", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                try
                {
                    using (HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(fullUri))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            throw new Exception(response.ReasonPhrase);
                        }
                        else
                        {
                            MessageBox.Show("Wedstrijd is succesvol verwijderd!", "Informatie", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public static async Task UpdateGame(GameUpdateDTO game)
        {
            string fullUri = $"{ApiHelper.BASEURL}game/update";
            try
            {
                using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(fullUri, game))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                    else
                    {
                        MessageBox.Show("Wedstrijd is succesvol geüpdate!", "Informatie", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
