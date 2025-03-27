using Godot;
using Godot.Collections;
using Solitaire.Scripts;
using System;
using System.Collections.Generic;

public partial class Deck : Node2D
{
	private const int DECK_SIZE = 52;
	private const string CARD_SCENE = "res://Scenes/Card.tscn";
	public Queue<Node2D> PlayerDeck = new Queue<Node2D>(DECK_SIZE);
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		#region Shuffle Cards
		List<int> unshuffled = new List<int>(DECK_SIZE);
		for (int i = 0; i < DECK_SIZE; i++)
		{
			unshuffled.Add(i);
		}
		Random rand = new Random();
		PackedScene cardScene = ResourceLoader.Load<PackedScene>(CARD_SCENE);
		for (int i = 0; i < DECK_SIZE; i++)
		{
			int toCreate = rand.Next(unshuffled.Count);
			Node2D card = (Node2D) cardScene.Instantiate();
			
			Array<Node> children = card.GetChildren(true);
			for (int j = 0; j < children.Count; j++)
			{
				var child = children[j];
				//GD.Print(child.Name);
				if (child.Name == "CardImage")
				{
					Sprite2D toEdit = (Sprite2D) child;
					CardInfo info = MapToCard(unshuffled[toCreate]);
					toEdit.Texture = ResourceLoader.Load<Texture2D>(info.Path);
					card.SetMeta("CardColor", info.Color);
					card.SetMeta("CardNumber", info.Number);
					card.SetMeta("CardSuit", info.Suit);
					PlayerDeck.Enqueue(card);
					unshuffled.RemoveAt(toCreate);
					break;
				}
			}
		}
		#endregion
	}

	public struct CardInfo
	{
		public string Color;
		public string Number;
		public string Path;
		public string Suit;
	}

	public static CardInfo MapToCard(int value)
	{
		CardInfo mapped = new CardInfo();
		switch ((CardEnums)value)
		{
			case CardEnums.ClubAce:
				mapped.Color = "Black";
				mapped.Number = "1";
				mapped.Path = "res://CardsPNG/1Club.png";
				mapped.Suit = "Club";
				break;
			case CardEnums.ClubTwo:
				mapped.Color = "Black";
				mapped.Number = "2";
				mapped.Path = "res://CardsPNG/2Club.png";
				mapped.Suit = "Club";
				break;
			case CardEnums.ClubThree:
				mapped.Color = "Black";
				mapped.Number = "3";
				mapped.Path = "res://CardsPNG/3Club.png";
				mapped.Suit = "Club";
				break;
			case CardEnums.ClubFour:
				mapped.Color = "Black";
				mapped.Number = "4";
				mapped.Path = "res://CardsPNG/4Club.png";
				mapped.Suit = "Club";
				break;
			case CardEnums.ClubFive:
				mapped.Color = "Black";
				mapped.Number = "5";
				mapped.Path = "res://CardsPNG/5Club.png";
				mapped.Suit = "Club";
				break;
			case CardEnums.ClubSix:
				mapped.Color = "Black";
				mapped.Number = "6";
				mapped.Path = "res://CardsPNG/6Club.png";
				mapped.Suit = "Club";
				break;
			case CardEnums.ClubSeven:
				mapped.Color = "Black";
				mapped.Number = "7";
				mapped.Path = "res://CardsPNG/7Club.png";
				mapped.Suit = "Club";
				break;
			case CardEnums.ClubEight:
				mapped.Color = "Black";
				mapped.Number = "8";
				mapped.Path = "res://CardsPNG/8Club.png";
				mapped.Suit = "Club";
				break;
			case CardEnums.ClubNine:
				mapped.Color = "Black";
				mapped.Number = "9";
				mapped.Path = "res://CardsPNG/9Club.png";
				mapped.Suit = "Club";
				break;
			case CardEnums.ClubTen:
				mapped.Color = "Black";
				mapped.Number = "10";
				mapped.Path = "res://CardsPNG/10Club.png";
				mapped.Suit = "Club";
				break;
			case CardEnums.ClubJack:
				mapped.Color = "Black";
				mapped.Number = "11";
				mapped.Path = "res://CardsPNG/11Club.png";
				mapped.Suit = "Club";
				break;
			case CardEnums.ClubQueen:
				mapped.Color = "Black";
				mapped.Number = "12";
				mapped.Path = "res://CardsPNG/12Club.png";
				mapped.Suit = "Club";
				break;
			case CardEnums.ClubKing:
				mapped.Color = "Black";
				mapped.Number = "13";
				mapped.Path = "res://CardsPNG/13Club.png";
				mapped.Suit = "Club";
				break;
			case CardEnums.DiamondAce:
				mapped.Color = "Red";
				mapped.Number = "1";
				mapped.Path = "res://CardsPNG/1Diamond.png";
				mapped.Suit = "Diamond";
				break;
			case CardEnums.DiamondTwo:
				mapped.Color = "Red";
				mapped.Number = "2";
				mapped.Path = "res://CardsPNG/2Diamond.png";
				mapped.Suit = "Diamond";
				break;
			case CardEnums.DiamondThree:
				mapped.Color = "Red";
				mapped.Number = "3";
				mapped.Path = "res://CardsPNG/3Diamond.png";
				mapped.Suit = "Diamond";
				break;
			case CardEnums.DiamondFour:
				mapped.Color = "Red";
				mapped.Number = "4";
				mapped.Path = "res://CardsPNG/4Diamond.png";
				mapped.Suit = "Diamond";
				break;
			case CardEnums.DiamondFive:
				mapped.Color = "Red";
				mapped.Number = "5";
				mapped.Path = "res://CardsPNG/5Diamond.png";
				mapped.Suit = "Diamond";
				break;
			case CardEnums.DiamondSix:
				mapped.Color = "Red";
				mapped.Number = "6";
				mapped.Path = "res://CardsPNG/6Diamond.png";
				mapped.Suit = "Diamond";
				break;
			case CardEnums.DiamondSeven:
				mapped.Color = "Red";
				mapped.Number = "7";
				mapped.Path = "res://CardsPNG/7Diamond.png";
				mapped.Suit = "Diamond";
				break;
			case CardEnums.DiamondEight:
				mapped.Color = "Red";
				mapped.Number = "8";
				mapped.Path = "res://CardsPNG/8Diamond.png";
				mapped.Suit = "Diamond";
				break;
			case CardEnums.DiamondNine:
				mapped.Color = "Red";
				mapped.Number = "9";
				mapped.Path = "res://CardsPNG/9Diamond.png";
				mapped.Suit = "Diamond";
				break;
			case CardEnums.DiamondTen:
				mapped.Color = "Red";
				mapped.Number = "10";
				mapped.Path = "res://CardsPNG/10Diamond.png";
				mapped.Suit = "Diamond";
				break;
			case CardEnums.DiamondJack:
				mapped.Color = "Red";
				mapped.Number = "11";
				mapped.Path = "res://CardsPNG/11Diamond.png";
				mapped.Suit = "Diamond";
				break;
			case CardEnums.DiamondQueen:
				mapped.Color = "Red";
				mapped.Number = "12";
				mapped.Path = "res://CardsPNG/12Diamond.png";
				mapped.Suit = "Diamond";
				break;
			case CardEnums.DiamondKing:
				mapped.Color = "Red";
				mapped.Number = "13";
				mapped.Path = "res://CardsPNG/13Diamond.png";
				mapped.Suit = "Diamond";
				break;
			case CardEnums.HeartAce:
				mapped.Color = "Red";
				mapped.Number = "1";
				mapped.Path = "res://CardsPNG/1Heart.png";
				mapped.Suit = "Heart";
				break;
			case CardEnums.HeartTwo:
				mapped.Color = "Red";
				mapped.Number = "2";
				mapped.Path = "res://CardsPNG/2Heart.png";
				mapped.Suit = "Heart";
				break;
			case CardEnums.HeartThree:
				mapped.Color = "Red";
				mapped.Number = "3";
				mapped.Path = "res://CardsPNG/3Heart.png";
				mapped.Suit = "Heart";
				break;
			case CardEnums.HeartFour:
				mapped.Color = "Red";
				mapped.Number = "4";
				mapped.Path = "res://CardsPNG/4Heart.png";
				mapped.Suit = "Heart";
				break;
			case CardEnums.HeartFive:
				mapped.Color = "Red";
				mapped.Number = "5";
				mapped.Path = "res://CardsPNG/5Heart.png";
				mapped.Suit = "Heart";
				break;
			case CardEnums.HeartSix:
				mapped.Color = "Red";
				mapped.Number = "6";
				mapped.Path = "res://CardsPNG/6Heart.png";
				mapped.Suit = "Heart";
				break;
			case CardEnums.HeartSeven:
				mapped.Color = "Red";
				mapped.Number = "7";
				mapped.Path = "res://CardsPNG/7Heart.png";
				mapped.Suit = "Heart";
				break;
			case CardEnums.HeartEight:
				mapped.Color = "Red";
				mapped.Number = "8";
				mapped.Path = "res://CardsPNG/8Heart.png";
				mapped.Suit = "Heart";
				break;
			case CardEnums.HeartNine:
				mapped.Color = "Red";
				mapped.Number = "9";
				mapped.Path = "res://CardsPNG/9Heart.png";
				mapped.Suit = "Heart";
				break;
			case CardEnums.HeartTen:
				mapped.Color = "Red";
				mapped.Number = "10";
				mapped.Path = "res://CardsPNG/10Heart.png";
				mapped.Suit = "Heart";
				break;
			case CardEnums.HeartJack:
				mapped.Color = "Red";
				mapped.Number = "11";
				mapped.Path = "res://CardsPNG/11Heart.png";
				mapped.Suit = "Heart";
				break;
			case CardEnums.HeartQueen:
				mapped.Color = "Red";
				mapped.Number = "12";
				mapped.Path = "res://CardsPNG/12Heart.png";
				mapped.Suit = "Heart";
				break;
			case CardEnums.HeartKing:
				mapped.Color = "Red";
				mapped.Number = "13";
				mapped.Path = "res://CardsPNG/13Heart.png";
				mapped.Suit = "Heart";
				break;
			case CardEnums.SpadeAce:
				mapped.Color = "Black";
				mapped.Number = "1";
				mapped.Path = "res://CardsPNG/1Spade.png";
				mapped.Suit = "Spade";
				break;
			case CardEnums.SpadeTwo:
				mapped.Color = "Black";
				mapped.Number = "2";
				mapped.Path = "res://CardsPNG/2Spade.png";
				mapped.Suit = "Spade";
				break;
			case CardEnums.SpadeThree:
				mapped.Color = "Black";
				mapped.Number = "3";
				mapped.Path = "res://CardsPNG/3Spade.png";
				mapped.Suit = "Spade";
				break;
			case CardEnums.SpadeFour:
				mapped.Color = "Black";
				mapped.Number = "4";
				mapped.Path = "res://CardsPNG/4Spade.png";
				mapped.Suit = "Spade";
				break;
			case CardEnums.SpadeFive:
				mapped.Color = "Black";
				mapped.Number = "5";
				mapped.Path = "res://CardsPNG/5Spade.png";
				mapped.Suit = "Spade";
				break;
			case CardEnums.SpadeSix:
				mapped.Color = "Black";
				mapped.Number = "6";
				mapped.Path = "res://CardsPNG/6Spade.png";
				mapped.Suit = "Spade";
				break;
			case CardEnums.SpadeSeven:
				mapped.Color = "Black";
				mapped.Number = "7";
				mapped.Path = "res://CardsPNG/7Spade.png";
				mapped.Suit = "Spade";
				break;
			case CardEnums.SpadeEight:
				mapped.Color = "Black";
				mapped.Number = "8";
				mapped.Path = "res://CardsPNG/8Spade.png";
				mapped.Suit = "Spade";
				break;
			case CardEnums.SpadeNine:
				mapped.Color = "Black";
				mapped.Number = "9";
				mapped.Path = "res://CardsPNG/9Spade.png";
				mapped.Suit = "Spade";
				break;
			case CardEnums.SpadeTen:
				mapped.Color = "Black";
				mapped.Number = "10";
				mapped.Path = "res://CardsPNG/10Spade.png";
				mapped.Suit = "Spade";
				break;
			case CardEnums.SpadeJack:
				mapped.Color = "Black";
				mapped.Number = "11";
				mapped.Path = "res://CardsPNG/11Spade.png";
				mapped.Suit = "Spade";
				break;
			case CardEnums.SpadeQueen:
				mapped.Color = "Black";
				mapped.Number = "12";
				mapped.Path = "res://CardsPNG/12Spade.png";
				mapped.Suit = "Spade";
				break;
			case CardEnums.SpadeKing:
				mapped.Color = "Black";
				mapped.Number = "13";
				mapped.Path = "res://CardsPNG/13Spade.png";
				mapped.Suit = "Spade";
				break;
			default:
				mapped.Color = "ERROR";
				mapped.Number = "ERROR";
				mapped.Path = "ERROR";
				mapped.Suit = "ERROR";
				break;
		}
		return mapped;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
