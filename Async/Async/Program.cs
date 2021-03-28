using System;
using System.IO;
using System.Threading.Tasks;

namespace Async
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var text = ConcatTextAsync().GetAwaiter().GetResult();
            Console.WriteLine(text);
        }

        private static Task<string> ReadFileAsync()
        {
            return File.ReadAllTextAsync("Hello.txt");
        }

        private static Task<string> WordAsync()
        {
            return Task.Run(() => "World");
        }

        private static async Task<string> ConcatTextAsync()
        {
            var readFileTask = ReadFileAsync();
            var wordTask = WordAsync();
            var result = $"{await readFileTask} {await wordTask}";
            return result;
        }
    }
}
