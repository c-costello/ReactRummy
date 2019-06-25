using Microsoft.EntityFrameworkCore;
using ReactRummy.Data;
using ReactRummy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactRummy.Models.Services
{
    public class CardService : ICard
    {
        private readonly GameDbContext _Context;

        public CardService(GameDbContext context)
        {
            _Context = context;
        }

        public async Task CreateCard(Card card)
        {
            _Context.Cards.Add(card);
            await _Context.SaveChangesAsync();

        }

        public async Task DeleteCard(Card.SuitType suit, Card.ValType val)
        {
            Card card = await _Context.Cards.FirstOrDefaultAsync(c => c.Suit == suit && c.Value == val);
            _Context.Cards.Remove(card);
            await _Context.SaveChangesAsync();

        }

        public async Task<Card> GetCard(Card.SuitType suit, Card.ValType val)
        {
            Card card = await _Context.Cards.FirstOrDefaultAsync(c => c.Suit == suit && c.Value == val);
            return card;
        }

        public async Task<IEnumerable<Card>> GetCards()
        {
            IEnumerable<Card> cards = await _Context.Cards.ToListAsync();
            return cards;
        }

        public async Task<IEnumerable<Card>> GetCardsByLocation(int locationID)
        {
            IEnumerable<Card> cardsRaw = await _Context.Cards.ToListAsync();
            IEnumerable<Card> cards = cardsRaw.Where(c => c.LocationID == locationID);
            return cards;
        }

        public async Task UpdateCard(Card card)
        {
            _Context.Cards.Update(card);
            await _Context.SaveChangesAsync();
        }
    }
}
