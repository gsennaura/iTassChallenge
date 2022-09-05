using System;
using System.IO;
using System.Net;
using System.Configuration;

namespace Guilherme.SenaGuilherme.Models.Files
{
    public class FileManager
    {

        protected string _sourceURL { get; set; }
        protected string _sourcePath { get; set; }
        protected string _destinationPath { get; set; }
        protected string _sourceFileName { get; set; }
        protected string _destinationFileName{ get; set; }

        /// <summary>Class <c>FileManager</c> manages reading and writing to files
        /// <param name="sourcePath">the source path file.</param>
        /// <param name="destinationPath">the destination path file</param>
        /// <param name="sourceFileName">the source file name</param>
        /// <param name="destinationFileName">the destination file name</param>
        /// </summary>
        public FileManager(string sourceURL, string sourcePath, string destinationPath, string sourceFileName, string destinationFileName)
        {
            _sourceURL = sourceURL;
            _sourcePath = sourcePath;
            _destinationPath = destinationPath;
            _sourceFileName = sourceFileName;
            _destinationFileName = destinationFileName;
        }

        /// <summary>
        ///    Downloads the log file
        /// </summary>
        public async Task downloadFile()
        {
            HttpClient client = new HttpClient();
            try	
            {
                HttpResponseMessage response = await client.GetAsync(_sourceURL);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                File.WriteAllText(_sourcePath + _sourceFileName, responseBody);
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");	
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        /// <summary>
        ///    Read the file to be converted
        /// </summary>
        public string[] ReadSourceFile()
        {
            return File.ReadAllLines(_sourcePath + _sourceFileName);
        }
        /// <summary>
        ///   Writes to a target file
        /// </summary>
        public void WriteDestinationFile(string destinationContent)
        {
            File.WriteAllText(_destinationPath + _destinationFileName, destinationContent);
        }
    }

}
