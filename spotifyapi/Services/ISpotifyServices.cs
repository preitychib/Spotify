using spotifyapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotifyapi.Services
{
    public interface ISpotifyServices
    {
        Task<IEnumerable<Release>> GetNewReleases(string countryCode, int limit, string accessToken);
    }
}