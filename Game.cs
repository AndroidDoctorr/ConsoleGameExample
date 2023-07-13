public class Game
{
    private bool hasRedKey = false;
    private bool hasScroll = false;


    public void Run()
    {
        Console.WriteLine("Loading game...");
        Thread.Sleep(2000);

        RoomOne();
    }

    public void RoomOne()
    {
        Console.Clear();
        Console.Write("You are in a dungeon, obvious exits are ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("NORTH, EAST, ");
        Console.ResetColor();
        Console.Write("and ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("WEST\n\n");
        Console.ResetColor();

        bool answerIsValid;
        do
        {
            answerIsValid = true;
            Console.Write("What would you like to do? ");
            string answer = Console.ReadLine();
            switch (answer.ToLower())
            {
                case "north":
                case "n":
                    // Go north
                    RoomThree();
                    break;
                case "east":
                case "e":
                    // Go east
                    break;
                case "west":
                case "w":
                    // Go west
                    RoomTwo();
                    break;
                default:
                    Console.WriteLine("I'm sorry, I don't understand you");
                    answerIsValid = false;
                    break;
            }
        } while (!answerIsValid);
    }

    public void RoomTwo()
    {
        Console.Clear();
        Console.WriteLine("This room is a dead end, empty but for some cobwebs and a locked chest.");
        Console.Write("Obvious exits are ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("EAST");
        Console.ResetColor();

        bool answerIsValid;
        do
        {
            answerIsValid = true;
            Console.WriteLine("What would you like to do?");

            string response = Console.ReadLine();
            switch (response)
            {
                case "east":
                case "e":
                case "go east":
                case "go e":
                case "exit e":
                case "exit east":
                    RoomOne();
                    break;
                case "unlock chest":
                    if (!hasScroll && hasRedKey) {
                        Console.Write("You open the chest! Inside is a ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("SCROLL");
                        Console.ResetColor();

                        hasScroll = true;
                    } else if (hasScroll) {
                        answerIsValid = false;
                        Console.WriteLine("You already opened this chest...");
                    } else {
                        answerIsValid = false;
                        Console.WriteLine("You don't have the right key!");
                    }
                    break;
                default:
                    Console.WriteLine("I'm sorry, I don't understand...");
                    answerIsValid = false;
                    break;
            }

        } while (!answerIsValid);
    }

    public void RoomThree() {
        Console.Clear();
        Console.Write("You find a ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("RED KEY");
        Console.ResetColor();
        Console.Write("!\n");

        hasRedKey = true;

        Console.WriteLine("Obvious exits are SOUTH");

        bool answerIsValid;
        do
        {
            answerIsValid = true;
            Console.WriteLine("What would you like to do?");

            string response = Console.ReadLine();
            switch (response.ToLower())
            {
                case "south":
                case "s":
                case "go south":
                case "go s":
                case "exit s":
                case "exit south":
                    RoomOne();
                    break;
                default:
                    Console.WriteLine("I'm sorry, I don't understand...");
                    answerIsValid = false;
                    break;
            }

        } while (!answerIsValid);
    }
}