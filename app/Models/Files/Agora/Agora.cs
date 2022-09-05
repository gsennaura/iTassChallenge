using Guilherme.SenaGuilherme.Models.Interfaces;
using Guilherme.SenaGuilherme.Models.Enums;
using System.Collections.Generic;

namespace Guilherme.SenaGuilherme.Models.Files.Agora
{
    /// <summary>Class <c>AgoraFileFormat</c> formats the expected string for 'Agora' log type/// </summary>
    public class AgoraFileFormat : IDestinationFormat
    {
        public List<string> DestinationSequence { get; set; }

        public AgoraFileFormat()
        {
            DestinationSequence = new List<string>();
            DestinationSequence.Add(FileHandleEnumerators.FileFields.Provider);
            DestinationSequence.Add(FileHandleEnumerators.FileFields.HttpMethod);
            DestinationSequence.Add(FileHandleEnumerators.FileFields.StatusCode);
            DestinationSequence.Add(FileHandleEnumerators.FileFields.UriPath);
            DestinationSequence.Add(FileHandleEnumerators.FileFields.TimeTaken);
            DestinationSequence.Add(FileHandleEnumerators.FileFields.ResponseSize);
            DestinationSequence.Add(FileHandleEnumerators.FileFields.CacheStatus);
        }
    }
}
