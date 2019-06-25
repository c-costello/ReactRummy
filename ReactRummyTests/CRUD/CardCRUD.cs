using System;
using Xunit;
using ReactRummy.Models;
using Microsoft.EntityFrameworkCore;
using ReactRummy.Data;
using ReactRummy.Models.Services;

namespace ReactRummyTests.CRUD
{
    public class CardCRUD
    {
        [Fact]
        public async void CanCreateCard()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("test").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                CardService cardService = new CardService(context);
                Card card = new Card()
                {
                    GameID = 1,
                    Suit = Card.SuitType.Clubs,
                    Value = Card.ValType.Ace
                };
                await cardService.CreateCard(card);
                var actual = await context.Cards.FirstOrDefaultAsync(c => c.Suit == card.Suit && c.Value == card.Value && c.GameID == card.GameID);
                Assert.Equal(card, actual);

            }
        }
        [Fact]
        public async void CanUpdateCard()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("test").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                CardService cardService = new CardService(context);
                Card card = new Card()
                {
                    GameID = 1,
                    Suit = Card.SuitType.Clubs,
                    Value = Card.ValType.Two,
                    LocationID = 2,
                };
                await cardService.CreateCard(card);
                card.LocationID = 4;
                await cardService.UpdateCard(card);
                var actual = await context.Cards.FirstOrDefaultAsync(c => c.Suit == card.Suit && c.Value == card.Value && c.GameID == card.GameID);
                Assert.Equal(card, actual);

            }
        }
        [Fact]
        public async void CanDeleteCard()
        {
            DbContextOptions<GameDbContext> options = new DbContextOptionsBuilder<GameDbContext>().UseInMemoryDatabase("test").Options;
            using (GameDbContext context = new GameDbContext(options))
            {
                CardService cardService = new CardService(context);
                Card card = new Card()
                {
                    GameID = 1,
                    Suit = Card.SuitType.Clubs,
                    Value = Card.ValType.Three,
                    LocationID = 2,
                };
                await cardService.CreateCard(card);
                await cardService.DeleteCard(card.Suit, card.Value);
                var actual = await context.Cards.FirstOrDefaultAsync(c => c.Suit == card.Suit && c.Value == card.Value && c.GameID == card.GameID);
                Assert.Null(actual);

            }
        }
    }
}
