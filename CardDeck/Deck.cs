using System.Collections;

namespace CardDeck;

public class Deck(Random rng) : IReadOnlyCollection<Card>
{
	private readonly List<Card> _deck = GenerateDefaultDeck();

	private readonly Random _rng = rng ?? throw new ArgumentNullException(nameof(rng));

	public Deck()
		: this(new Random())
	{
	}

	public Card Draw()
	{
		if (_deck.Count == 0)
			throw new InvalidOperationException("The deck is empty.");

		var card = _deck[^1];
		_deck.RemoveAt(_deck.Count - 1);
		return card;
	}

	public void Shuffle()
	{
		for (var i = _deck.Count - 1; i > 0; i--)
		{
			var j = _rng.Next(i + 1);
			(_deck[i], _deck[j]) = (_deck[j], _deck[i]);
		}
	}
	
	public void Reset(bool shuffle = true)
	{
		_deck.Clear();
		_deck.AddRange(GenerateDefaultDeck());

		if (shuffle)
		{
			Shuffle();
		}
	}


	private static List<Card> GenerateDefaultDeck()
	{
		var cardValues = Enum.GetValues<CardValue>();
		var cardSuits = Enum.GetValues<Suit>();
		
		var defaultDeck = cardSuits.SelectMany(s => cardValues.Select(v => new Card(v, s))).ToList();
		return defaultDeck;
	}

	public IEnumerator<Card> GetEnumerator() => _deck.GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	public int Count => _deck.Count;
}