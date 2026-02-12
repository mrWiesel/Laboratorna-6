using System.Text;

namespace ChessSystem
{
    // Базовий клас для шахової фігури
    public abstract class ChessPiece
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int CurX { get; set; }
        public int CurY { get; set; }

        public ChessPiece(string name, string color, int x, int y)
        {
            Name = name;
            Color = color;
            CurX = x;
            CurY = y;
        }

        public abstract bool CanMove(int targetX, int targetY);

        public void DisplayPosition()
        {
            Console.WriteLine($"{Color} {Name} зараз на позиції: [{CurX}, {CurY}]");
        }
    }

    // король
    public class King : ChessPiece
    {
        public King(string color, int x, int y) : base("Король", color, x, y) { }

        public override bool CanMove(int targetX, int targetY)
        {
            // Король ходить на 1 клітинку в будь-якому напрямку
            int deltaX = Math.Abs(targetX - CurX);
            int deltaY = Math.Abs(targetY - CurY);
            return deltaX <= 1 && deltaY <= 1 && !(deltaX == 0 && deltaY == 0);
        }
    }

    // коник
    public class Knight : ChessPiece
    {
        public Knight(string color, int x, int y) : base("Кінь", color, x, y) { }

        public override bool CanMove(int targetX, int targetY)
        {
            // Кінь ходить літерою "Г"
            int deltaX = Math.Abs(targetX - CurX);
            int deltaY = Math.Abs(targetY - CurY);
            return (deltaX == 2 && deltaY == 1) || (deltaX == 1 && deltaY == 2);
        }
    }

    // пішка 
    public class Pawn : ChessPiece
    {
        public Pawn(string color, int x, int y) : base("Пішка", color, x, y) { }

        public override bool CanMove(int targetX, int targetY)
        {
            // пішка ходить тільки вперед на 1 клітинку
            // (Для білих Y збільшується, для чорних — зменшується)
            int direction = (Color == "Білий") ? 1 : -1;
            return targetX == CurX && targetY == CurY + direction;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<ChessPiece> pieces = new List<ChessPiece>
            {
                new King("Білий", 4, 0),
                new Knight("Чорний", 1, 7),
                new Pawn("Білий", 2, 1)
            };

            Console.WriteLine("=== Перевірка ходів шахових фігур ===\n");

            Console.Write("Введіть X (1-8): ");
            int testX = int.Parse(Console.ReadLine());

            Console.Write("Введіть Y (1-8): ");
            int testY = int.Parse(Console.ReadLine());
            
            if (testX < 1 || testX > 8 || testY < 1 || testY > 8)
            {
                Console.WriteLine(">:( навіщо? ");
                Console.WriteLine("в стандартних шахах поле 8x8");
                return;
            }

            foreach (var piece in pieces)
            {
                piece.DisplayPosition();
                bool possible = piece.CanMove(testX, testY);

                string result = possible ? "МОЖЕ" : "НЕ МОЖЕ";
                Console.WriteLine($"Чи може фігура піти на [{testX}, {testY}]? Відповідь: {result}");
                Console.WriteLine(new string('-', 40));
            }

            Console.ReadKey();
        }
    }
}