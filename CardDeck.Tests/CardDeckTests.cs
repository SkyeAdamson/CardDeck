namespace CardDeck.Tests;

[TestFixture]
public class DeckTests
{
	[Test]
	public void Deck_ShouldHave52CardsInitially()
	{
		var deck = new Deck();
		Assert.That(deck, Has.Count.EqualTo(52));
	}

	[Test]
	public void Draw_ShouldReduceCount()
	{
		var deck = new Deck();
		var card = deck.Draw();
        Assert.Multiple(() =>
        {
            Assert.That(deck, Has.Count.EqualTo(51));
            Assert.That(card, Is.Not.Null);
        });
    }

	[Test]
	public void Shuffle_ShouldNotChangeCardCount()
	{
		var deck = new Deck();
		deck.Shuffle();
		Assert.That(deck, Has.Count.EqualTo(52));
	}

	[Test]
	public void Reset_ShouldRestoreFullDeck()
	{
		var deck = new Deck();
		deck.Draw();
		deck.Draw();
		deck.Reset();
		Assert.That(deck, Has.Count.EqualTo(52));
	}

	[Test]
	public void Deck_Enumeration_ShouldReturnAllCards()
	{
		var deck = new Deck();
		var count = 0;
		foreach (var card in deck)
			count++;
		Assert.That(count, Is.EqualTo(52));
	}
}