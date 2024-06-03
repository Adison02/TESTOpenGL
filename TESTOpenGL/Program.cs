using TESTOpenGL.GameLoop;

namespace TESTOpenGL
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            Game game = new TestGame(800, 600, "Title");
            game.Run();
        }
    }
}