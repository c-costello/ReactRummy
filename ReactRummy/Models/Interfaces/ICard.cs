using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactRummy.Models.Interfaces
{
    public interface ICard
    {
        Task<Card> GetCard(Card.SuitType suit, Card.ValType val);
        Task<IEnumerable<Card>> GetCards();
        Task<IEnumerable<Card>> GetCardsByLocation(int locationID);
        Task CreateCard(Card card);
        Task UpdateCard(Card card);
        Task DeleteCard(Card.SuitType suit, Card.ValType val);
    }
}
