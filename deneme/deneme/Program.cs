using System;

// Card class represents a card in the game
class Card
{
    private string name; // Name of the card
    private int damage; // Damage value of the card

    // Constructor to initialize the card
    public Card(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }

    // Method to get the name of the card
    public string GetName()
    {
        return name;
    }

    // Method to get the damage of the card
    public int GetDamage()
    {
        return damage;
    }
}

// Player class represents a player in the game
class Player
{
    private string name; // Name of the player
    private int health; // Health of the player

    // Constructor to initialize the player
    public Player(string name, int health)
    {
        this.name = name;
        this.health = health;
    }

    // Method to display player's info
    public void DisplayInfo()
    {
        Console.WriteLine($"Player: {name}, Health: {health}");
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        Console.WriteLine($"{name} took {damage} damage!");
    }

    // Method to check if player is alive
    public bool IsAlive()
    {
        return health > 0;
    }

    // Method to choose a card
    public int ChooseCard()
    {
        Console.WriteLine($"{name}, choose your card:");
        Console.WriteLine("1. Red Card");
        Console.WriteLine("2. Blue Card");
        Console.WriteLine("3. Green Card");
        Console.WriteLine("4. Purple Card");
        Console.WriteLine("5. Yellow Card");
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());
        return choice;
    }
}

// Main class of the program
class Program
{
    // Method to display the player name menu
    static void ShowPlayerNameMenu(out string player1Name, out string player2Name)
    {
        Console.WriteLine("Enter Player 1's name:");
        player1Name = Console.ReadLine();
        Console.WriteLine("Enter Player 2's name:");
        player2Name = Console.ReadLine();
    }

    // Method to display the start menu
    static void ShowStartMenu()
    {
        Console.WriteLine("Welcome to Card Game");
        Console.WriteLine("1. Start Game");
        Console.WriteLine("2. Exit");
    }

    // Method to start the game
    static void Main(string[] args)
    {
        // Ask for player names
        string player1Name, player2Name;
        ShowPlayerNameMenu(out player1Name, out player2Name);

        // Display the start menu
        ShowStartMenu();

        // Get user input for menu choice
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                StartGame(player1Name, player2Name); // Start the game with player names
                break;
            case 2:
                Console.WriteLine("Exiting game...");
                break;
            default:
                Console.WriteLine("Invalid choice! Exiting game...");
                break;
        }
    }

    // Method to start the game
    static void StartGame(string player1Name, string player2Name)
    {
        // Create two players
        Player player1 = new Player(player1Name, 100); // Initialize Player 1 with name and health
        Player player2 = new Player(player2Name, 100); // Initialize Player 2 with name and health

        // Create cards with increasing damage
        Card[] cards = new Card[]
        {
            new Card("Red Card", 20),
            new Card("Blue Card", 30),
            new Card("Green Card", 40),
            new Card("Purple Card", 50),
            new Card("Yellow Card", 50)
        };

        // Display players' info
        player1.DisplayInfo();
        player2.DisplayInfo();

        // Game loop
        while (player1.IsAlive() && player2.IsAlive())
        {
            // Player 1 selects a card
            int player1Choice = player1.ChooseCard(); // Player 1 chooses a card
            Card player1Card = cards[player1Choice - 1]; // Get the card chosen by Player 1
            Console.WriteLine($"Player 1 selects: {player1Card.GetName()}");

            // Player 2 selects a card
            int player2Choice = player2.ChooseCard(); // Player 2 chooses a card
            Card player2Card = cards[player2Choice - 1]; // Get the card chosen by Player 2
            Console.WriteLine($"Player 2 selects: {player2Card.GetName()}");

            // Check which player takes damage
            if (player1Card.GetDamage() > player2Card.GetDamage())
            {
                player2.TakeDamage(player1Card.GetDamage()); // Player 2 takes damage
                Console.WriteLine("Player 1 wins! Player 2 took damage.");
            }
            else if (player2Card.GetDamage() > player1Card.GetDamage())
            {
                player1.TakeDamage(player2Card.GetDamage()); // Player 1 takes damage
                Console.WriteLine("Player 2 wins! Player 1 took damage.");
            }
            else
            {
                Console.WriteLine("It's a draw! No damage taken.");
            }

            // Display players' updated info
            player1.DisplayInfo();
            player2.DisplayInfo();

            // Check if the game is over
            if (!player1.IsAlive() || !player2.IsAlive())
                break;

            // Pause between rounds
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        // Determine the winner
        if (player1.IsAlive())
            Console.WriteLine($"{player1Name} wins the game!");
        else if (player2.IsAlive())
            Console.WriteLine($"{player2Name} wins the game!");
        else
            Console.WriteLine("It's a draw!");
    }
}
