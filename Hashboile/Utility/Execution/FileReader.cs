using Hashboile.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hashboile.Utility.Execution
{
    class FileReader : IDisposable
    {

        private readonly StreamReader _stream;
        private readonly string _delimitier;

        private static readonly string INPUT_DIRECTORY = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Input");

        private Queue<string> currentLine;
        private Dictionary<Type, TypeConverter> _typeConverterCache = new Dictionary<Type, TypeConverter>();

        private FileReader(StreamReader stream, string delimitier)
        {
            _stream = stream;
            _delimitier = delimitier;
        }

        public static FileReader ReadFrom(string path, string delimitier)
        {
            path = File.Exists(path) ?
                path :
                Path.Combine(
                    INPUT_DIRECTORY,
                    path);

            if(!File.Exists(path))
            {
                throw new FileNotFoundException($"Input File for path {path} could not be found");
            }

            return new FileReader(
                File.OpenText(path), 
                delimitier);
        }

        public void Dispose()
        {

            if (currentLine != null && currentLine.Any())
            {
                throw new InvalidOperationException($"Invalid State: File has been fully consumed, but there are tokens left: {string.Join(' ', currentLine)}");
            }
                
            _stream?.Dispose();
        }

        public T Next<T>()
        {
            if(currentLine == null || !currentLine.Any())
            {
                currentLine = _stream
                    .ReadLine()
                    ?.Split(_delimitier)
                    ?.Select(x => x.Trim())
                    ?.ToQueue();

                if(currentLine == null)
                {
                    throw new Exception("File has finnished!");
                }
            }

            var nextToken = currentLine.Dequeue();

            var converter = _typeConverterCache.GetOrCreate(
                typeof(T),
                t => TypeDescriptor.GetConverter(t));

            return (T)converter.ConvertFromInvariantString(nextToken);
        }

        


    }
}
