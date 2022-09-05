using Guilherme.SenaGuilherme.Models.Interfaces;
using Guilherme.SenaGuilherme.Models.Enums;
using System;
using System.Collections;
using System.Text;

namespace Guilherme.SenaGuilherme.Models.Converters
{

    public class MinhaCDNConverter : IFormatting
    {
        public Hashtable SplitedSequences { get; set; }
        public Hashtable Sequences { get; set; }
        protected IDestinationFormat DestinationFormat { get; set; }

        /// <summary>Class <c>MinhaCDNConverter</c> convert 'Minha CDN' logs in a specific destination format
        /// <param name="destination">the destination extended format</param>
        /// </summary>''
        public MinhaCDNConverter(IDestinationFormat destination)
        {
            DestinationFormat = destination;

            Sequences = new Hashtable();
            Sequences.Add(FileHandleEnumerators.FileFields.ResponseSize, 0);
            Sequences.Add(FileHandleEnumerators.FileFields.StatusCode, 1);
            Sequences.Add(FileHandleEnumerators.FileFields.CacheStatus, 2);
            Sequences.Add(FileHandleEnumerators.FileFields.TimeTaken, 4);

            SplitedSequences = new Hashtable();
            SplitedSequences.Add(FileHandleEnumerators.FileFields.HttpMethod, 0);
            SplitedSequences.Add(FileHandleEnumerators.FileFields.UriPath, 1);
            SplitedSequences.Add(FileHandleEnumerators.FileFields.Protocol, 2);
        }
        /// <summary>
        ///     Apply header to destination file
        /// </summary>
        public string HeaderInformation()
        {
            return string.Format("# Version: {0}\n# Date: {1}\n# Fields: {2}\n", "1.0", string.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now), string.Join(" ", DestinationFormat.DestinationSequence.ToArray()));
        }

        /// <summary>
        ///     Apply content to destination file
        ///     <param name="sourceLines">source lines extracted from 'Minha CDN' log</param>
        /// </summary>
        public string SpecificConverter(string[] sourceLines)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var line in sourceLines)
            {
                foreach (string position in DestinationFormat.DestinationSequence)
                {
                    sb.Append(" ");
                    sb.Append(FormatAdapter(line, position));
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        /// <summary>
        ///     Apply content to destination file
        ///     <param name="sourceLine">source line extracted from 'Minha CDN' log</param>
        ///     <param name="position">respective position where the line is going to be inserted</param>
        /// </summary>
        public string FormatAdapter(string sourceLine, string position)
        {   
            if (Sequences.Contains(position))
                return sourceLine.Split('|')[Convert.ToInt32(Sequences[position].ToString())];
            else if (SplitedSequences.Contains(position))
                return sourceLine.Split('|')[3].Split(' ')[Convert.ToInt32(SplitedSequences[position].ToString())].Replace("\"", ""); 
            else if (position.ToLower() == FileHandleEnumerators.FileFields.Provider)
               return FileHandleEnumerators.SourceName.MyCDN;
            else
                throw new Exception($"Something went wrong managing the lines in the file. Current position {position}");
        }
    }
}
