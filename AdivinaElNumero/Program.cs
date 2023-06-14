// See https://aka.ms/new-console-template for more information
using System.Numerics;
string? player;
Random random = new Random();

int attempts = 0;
int highesScoreAttempts = 0;

Console.WriteLine("/***** Guess the Number *****/");


StarGame();


void StarGame()
{
    Console.WriteLine("");
    Console.WriteLine("/***** Welcome to the Game *****/");

    var randomNumbber = random.Next(1, 10);

    Console.WriteLine("What is you name?");
    player = Console.ReadLine();

   
    WantToPlay(randomNumbber);

}

void WantToPlay(int randomNumbber, bool playAgain= false)
{
    if (!playAgain)
        Console.WriteLine($"Hi {player}, are you ready to play? (Enter Yes/No)");
    else
        Console.WriteLine($"{player}, are you ready to play? (Enter Yes/No)");

    var wantToPlay = Console.ReadLine();

    switch (wantToPlay?.ToLower().Trim())
    {
        case "yes":
            Play(randomNumbber);
            break;
        case "no":
            DontPlay();
            break;
        default:
            Console.WriteLine("That is not a valid option.");
            WantToPlay(randomNumbber);
            break;
    }
}

void Play(int randomNumbber)
{
    try
    {
        Console.WriteLine("Pick a nomber between 1 and 10");
        var pickNumber = Console.ReadLine();

        if (pickNumber is null)
            throw new Exception("You need to pick a value!");

        if (int.Parse(pickNumber) < 1 || int.Parse(pickNumber) > 10)
            throw new Exception("The number is not between 1 and 10");


        if (int.Parse(pickNumber)== randomNumbber)
        {            
            YouGuessed();
        }
        else if(int.Parse(pickNumber) < randomNumbber)
        {
            Console.WriteLine("Try again! The number is higher...");
            attempts++;
            Play(randomNumbber);
        }
        else if (int.Parse(pickNumber) > randomNumbber)
        {
            Console.WriteLine("Try again! The number is lower...");
            attempts++;
            Play(randomNumbber);
        }

    }
    catch (Exception e)
    {
        Console.WriteLine($" There has been an error: {e.Message}");
        Play(randomNumbber);
    }

}



void DontPlay()
{
    Console.WriteLine("No worries! Goodbye");
}

void YouGuessed()
{
    Console.WriteLine("");
    Console.WriteLine("Nice! You Guessed the number!");
    attempts++;

    if (highesScoreAttempts == 0 || attempts < highesScoreAttempts)
        highesScoreAttempts= attempts;

    Console.WriteLine($"It has taken you {attempts} attempts to gues the number");
    ShowScore();
    attempts = 0;

    var randomNumbber = random.Next(1, 10);
    WantToPlay(randomNumbber, true);
}

void ShowScore()
{
    if(highesScoreAttempts == 0)
        Console.WriteLine("There is currently no high score, it's you for taking!");
    else
        Console.WriteLine($"The current high score is {highesScoreAttempts} attempts");
}


