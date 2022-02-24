using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hashboile.Utility.Execution
{
    class FileWriter : IDisposable
    {
        private readonly StreamWriter _writer;
        private readonly string _delimitier;
        
        private static readonly string OUTPUT_DIRECTORY = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Output");

        private FileWriter(string delimitier, StreamWriter writer)
        {
            _delimitier = delimitier;
            _writer = writer;
        }

        public static FileWriter WriteTo(string path, string delimitier)
        {
            if(!Path.IsPathFullyQualified(path))
            {
                Directory.CreateDirectory(OUTPUT_DIRECTORY);
                path = Path.Combine(
                    OUTPUT_DIRECTORY,
                    path);
            }

            return new FileWriter(
                delimitier,
                new StreamWriter(path, false));
        }

        public void WriteInitialToken<T>(T token)
        {
            _writer.Write(token);
        }

        public void WriteToken<T>(T token)
        {
            _writer.Write(_delimitier + token.ToString());
        }

        public void WriteLineBreak()
        {
            _writer.WriteLine();
        }

        public void Dispose()
        {
            _writer?.Dispose();
        }
    }
}
