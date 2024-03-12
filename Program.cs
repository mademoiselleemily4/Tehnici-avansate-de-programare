using Tap.Hangman.App;
// Initializarea unui nou joc de Hangman
var hangmanGame = new HangmanGame();
// Mesaj de bun venit pentru jucator
Console.WriteLine("---Hangman game---");
Console.WriteLine("Enjoy the game!");
Console.WriteLine();
// Afisarea cuvantului curent (initial cu spatii pentru litere necunoscute)
Console.WriteLine("Your word:");
Console.WriteLine(hangmanGame.CurrentWord);
// Inceperea buclei de joc pana cand jocul se termina
while (hangmanGame.GameState == GameState.InProgress)
{// Inceperea buclei de joc pana cand jocul se termina
    Console.WriteLine($"Lives left: {hangmanGame.RemainingLives}");
    // Solicitarea unei litere de la jucator
    Console.WriteLine("Your next letter is?");
    var letterInput = Console.ReadKey().KeyChar;
    // Aplicarea literei introduse in joc
    hangmanGame.ApplyLetter(letterInput);

    Console.WriteLine();// Afisarea unei linii goale pentru claritate
    Console.WriteLine("Your word:");
    Console.WriteLine(hangmanGame.CurrentWord);// Afisarea starii curente a cuvantului
}
Console.WriteLine();// Afisarea unei linii goale pentru claritate
// Verificarea starii jocului si afisarea unui mesaj corespunzator
if (hangmanGame.GameState == GameState.Lost)
{
    Console.WriteLine("You lost! :(");// Mesaj in cazul in care jucatorul a pierdut
}

if (hangmanGame.GameState == GameState.Won)
{
    Console.WriteLine("You won! :)");// Mesaj in cazul in care jucatorul a castigat
}