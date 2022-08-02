using System;
using System.Collections.Generic;
using System.IO;

namespace Assessment
{
    public class Extractor
    {
        public string FileName { get; private set; }

        public Extractor(string file)
        {
            FileName = file;
        }

        public IEnumerable<string> readRow(bool isNotHeaderRow)
        {
            int rowIndex = 0;

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File Not Found", path);
            }
            else
            {
                foreach (var row in File.ReadAllLines(path))
                {
                    if (!isNotHeaderRow && rowIndex == 0)
                    {
                        rowIndex++;
                        continue;

                    }

                    yield return row;
                }

            }

        }
            
    }
}