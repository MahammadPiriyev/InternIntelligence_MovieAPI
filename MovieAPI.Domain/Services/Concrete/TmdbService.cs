using Microsoft.Extensions.Configuration; 
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Services.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Domain.Services.Concrete
{
	public class TmdbService : ITmdbService
	{
		private readonly HttpClient _httpClient;
		private readonly IConfiguration _configuration;
		private readonly string? _apiKey;
		private readonly string? _baseUrl;

		public TmdbService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;
			_apiKey = configuration["Tmdb:ApiKey"];
			_baseUrl = configuration["Tmdb:BaseUrl"];
		}

		public async Task<TmdbMovie> GetMovieByIdAsync(int movieId)
		{
			var response = await _httpClient.GetStringAsync($"{_baseUrl}/movie/{movieId}?api_key={_apiKey}");
			var movie = JsonConvert.DeserializeObject<TmdbMovie>(response);
			return movie;
		}

		public async Task<List<TmdbMovie>> GetPopularMoviesAsync()
		{
			var response = await _httpClient.GetStringAsync($"{_baseUrl}/movie/popular?api_key={_apiKey}");
			var movieList = JsonConvert.DeserializeObject<TmdbMovieResponse>(response);
			return movieList.Results;
		}
	}
}
