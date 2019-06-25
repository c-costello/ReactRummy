using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactRummy.Models.Interfaces
{
    public interface IPlayer
    {
        Task<Player> GetPlayer(int id);
        Task<Player> GetPlayerByUser(string user);
        Task<IEnumerable<Player>> GetPlayersByGame(int gameID);
        Task<IEnumerable<Player>> GetPlayers();
        Task<Player> CreatePlayer(Player player);
        Task<Player> UpdatePlayer(Player player);
        Task DeletePlayer(int id);


    }
}
