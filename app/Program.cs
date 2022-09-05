using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guilherme.SenaGuilherme.Controllers;
using Guilherme.SenaGuilherme.Models.Enums;

namespace Guilherme.SenaGuilherme.ConvertFilesChallenge
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(args[0]);
            if (args.Count() == 2)
            {
                string path = @"./logs/";  
                string URIPath = args[0];
                string sourceFileName = args[1];
                string destinationFileName ="agora_log.txt";
                FileConverter c = new FileConverter();
                await c.ConvertFile(FileHandleEnumerators.SupportedFileTypes.MinhaCDN, FileHandleEnumerators.SupportedFileTypes.Agora, URIPath, path, sourceFileName, path, destinationFileName);
            }
            else
               throw new Exception($"Something went wrong. Check if the parameters passed are correct. The specification requires an input URL (sourceUrl) and a destination file (targetPath). For example: http://logstorage.com/minhaCdn1.txt ./output/minhaCdn1.txt");

        }
    }
}
