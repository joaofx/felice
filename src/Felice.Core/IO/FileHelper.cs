namespace Felice.Core.IO
{
    using System.Collections.Generic;
    using System.Text;
    using System.IO;

    public class FileHelper
    {
        public static IEnumerable<string> ReadLines(string file, bool skipHeader = false)
        {
            using (var stream = File.OpenRead(file))
            {
                using (var reader = new StreamReader(stream, Encoding.Default))
                {
                    if (skipHeader) reader.ReadLine();
                    while (reader.EndOfStream == false) yield return reader.ReadLine();
                }
            }
        }
    }
}
