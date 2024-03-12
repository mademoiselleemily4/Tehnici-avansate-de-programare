namespace Tap.Hangman.App
{// Clasa care implementează jocul Hangman
    internal class HangmanGame
    {// Cuvantul curent al jocului
        private string word;
        // Caracterele care au fost ghicite corect
        private SortedSet<char> matchedCharacters;
        // Starea curenta a cuvantului (caractere ghicite si necunoscute)
        private char[] wordState;
        // Constructorul clasei HangmanGame
        public HangmanGame()
        {
            word = "computer";// Cuvantul pe care jucatorul trebuie sa-l ghiceasca
            RemainingLives = 5;// Numarul initial de vieti
            matchedCharacters = new SortedSet<char>();// Initializarea listei de caractere ghicite corect
            wordState = word.ToCharArray();// Initializarea starii initiale a cuvantului
            ClearWordState(); // Functia pentru resetarea starii cuvantului
        }
        // Proprietatea pentru numarul de vieti ramase
        public int RemainingLives { get; set; }
        // Proprietatea pentru starea jocului (castigat, pierdut, in desfasurare)
        public GameState GameState
        {
            get
            {
                if (RemainingLives == 0)// Verificarea daca jucatorul a ramas fara vieti
                {
                    return GameState.Lost;// Jocul este pierdut
                }
                if (!wordState.Contains('_')) // Verificarea daca toate literele au fost ghicite
                {
                    return GameState.Won; // Jocul este castigat
                }
                return GameState.InProgress;// Jocul este in desfasurare
            }
        }
        // Proprietatea pentru afisarea cuvantului curent
        public string CurrentWord => new string(wordState);
        // Metoda pentru aplicarea unei litere introduse de jucator
        public void ApplyLetter(char letter)
        {// Verifică dacă jocul s-a încheiat sau litera a fost deja ghicită anterior
            if (RemainingLives == 0 || matchedCharacters.Contains(letter))
            {
                return;// Ieși din metoda dacă condițiile nu sunt îndeplinite
            }
            // Convertește cuvântul într-un vector de caractere
            char[] wordLetters = word.ToCharArray();
            // Aplică modificările asupra stării jocului în funcție de litera introdusă
            AdjustGameStateBasedOnLetter(letter, wordLetters);
        }
        // Metoda pentru ajustarea starii jocului in functie de litera introdusa
        private void AdjustGameStateBasedOnLetter(char letter, char[] wordLetters)
        {
            var foundLetter = false;// Variabilă pentru a urmări dacă litera a fost găsită în cuvânt
            for (int i = 0; i < wordLetters.Length; i++)// Parcurge fiecare literă din cuvânt pentru a verifica dacă litera introdusă se potrivește
            {
                char wordLetter = wordLetters[i];
                if (wordLetter == letter)
                {
                    wordState[i] = letter;
                }
            }

            if (foundLetter == false)
            {
                RemainingLives--;// Scaderea unei vieti daca litera introdusa nu se potriveste
            }
        }
        // Metoda pentru resetarea starii cuvantului la inceputul jocului
        private void ClearWordState()
        {
            for (int i = 0; i < wordState.Length; i++)
            {
                wordState[i] = '_';// Inlocuirea tuturor literelor cu caractere necunoscute ('_')
            }
        }
    }
}
