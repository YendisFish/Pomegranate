using Compiler.Lexing;

namespace Compiler
{
    internal class EntryPoint
    {
        public static void Main(params string[] args)
        {
            Lexer lx = new Lexer(args[0]);
            List<(Token token, string value, int[] indexes)> vals = lx.ParseFile();

            foreach((Token token, string value, int[] indexes) v in vals)
            {
                if(v.value is not "")
                {
                    Console.WriteLine($"Token: {v.token} Value: {v.value}");
                }
            }
        }
    }
}