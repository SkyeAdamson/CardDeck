namespace CardDeck.Tests;

[TestFixture]
public class CardTests
{
	[Test]
	public void Cards_WithSameValueAndSuit_ShouldBeEqual()
	{
		var card1 = new Card(CardValue.Ace, Suit.Spades);
		var card2 = new Card(CardValue.Ace, Suit.Spades);
		
		Assert.That(card1, Is.EqualTo(card2));
		Assert.That(card1.GetHashCode(), Is.EqualTo(card2.GetHashCode()));
	}

	[Test]
	public void Cards_WithDifferentValues_ShouldBeEqual()
	{
		var card1 = new Card(CardValue.Ace, Suit.Spades);
		var card2 = new Card(CardValue.King, Suit.Spades);
		var card3 = new Card(CardValue.Ace, Suit.Hearts);
		
        Assert.Multiple(() =>
        {
	        Assert.That(card1, Is.Not.EqualTo(card2));
            Assert.That(card1, Is.Not.EqualTo(card3));
            Assert.That(card2, Is.Not.EqualTo(card3));
        });
    }
}