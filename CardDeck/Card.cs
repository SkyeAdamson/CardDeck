namespace CardDeck;

public sealed class Card : IEquatable<Card>, IFormattable
{
	public Card(CardValue value, Suit suit)
	{
		Value = value;
		Suit = suit;
	}

	public CardValue Value { get; }

	public Suit Suit { get; }

	public override string ToString() => ToString("L", null);

	public bool Equals(Card? other)
	{
		return other is not null &&
		       Value == other.Value &&
		       Suit == other.Suit;
	}

	public override bool Equals(object? obj)
	{
		if (obj is null) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;
		return Equals((Card)obj);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine((int)Value, (int)Suit);
	}
	
	public static bool operator ==(Card? left, Card? right)
		=> Equals(left, right);

	public static bool operator !=(Card? left, Card? right)
		=> !Equals(left, right);
	
	public string ToString(string? format) => ToString(format, null);

	public string ToString(string? format, IFormatProvider? formatProvider)
	{
		format = string.IsNullOrWhiteSpace(format) ? "L" : format.ToUpperInvariant();

		return format switch
		{
			"L" => $"{Value} of {Suit}",
			"S" => $"{GetValueAbbreviation()}{GetSuitSymbol()}",
			_ => throw new FormatException($"Unknown format string '{format}'.")
		};
	}

	private string GetValueAbbreviation() => Value switch
	{
		CardValue.Ace => "A",
		CardValue.Jack => "J",
		CardValue.Queen => "Q",
		CardValue.King => "K",
		_ => ((int)Value).ToString()
	};

	private string GetSuitSymbol() => Suit switch
	{
		Suit.Spades => "♠",
		Suit.Hearts => "♥",
		Suit.Diamonds => "♦",
		Suit.Clubs => "♣",
		_ => throw new ArgumentOutOfRangeException()
	};
}