// See https://aka.ms/new-console-template for more information

using CardDeck;

Console.OutputEncoding = System.Text.Encoding.UTF8;
var cardDeck = new Deck();
foreach (var card in cardDeck)
{
	Console.WriteLine(card.ToString("S"));
}