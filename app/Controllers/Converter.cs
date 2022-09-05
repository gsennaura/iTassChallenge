using Guilherme.SenaGuilherme.Models.Enums;
using Guilherme.SenaGuilherme.Models.Files;
using Guilherme.SenaGuilherme.Models.Files.Agora;
using Guilherme.SenaGuilherme.Models.Converters;
using Guilherme.SenaGuilherme.Models.Interfaces;

namespace Guilherme.SenaGuilherme.Controllers
{
    //IFinalFormat IDestinationFormat
    //IFormatConverter = IFormatting
    public class FileConverter
    {
        public IFormatting SourceFormatConverter { get; set; }
        public IDestinationFormat DestinationFormat { get; set; }

        /// <summary>
        ///     Apply conversion between 'Minha CDN' and 'Agora' files
        ///     <param name="sourceType">the source log type.</param>
        ///     <param name="destinationType">the destination log type.</param>
        ///     <param name="sourcePath">the source path file.</param>
        ///     <param name="destinationPath">the destination path file</param>
        ///     <param name="sourceFileName">the source file name</param>
        ///     <param name="destinationFileName">the destination file name</param>
        /// </summary>
        public async Task ConvertFile(FileHandleEnumerators.SupportedFileTypes sourceType, FileHandleEnumerators.SupportedFileTypes destinationType, string sourceURL, string sourcePath, string sourceFileName, string destinationPath, string destinationFileName)
        {
            if ((sourceType == FileHandleEnumerators.SupportedFileTypes.MinhaCDN) && (destinationType == FileHandleEnumerators.SupportedFileTypes.Agora)){
                FileManager fm = new FileManager(sourceURL, sourcePath, destinationPath, sourceFileName, destinationFileName);
                await fm.downloadFile();
                var lines = fm.ReadSourceFile();   
                _ConvertMinhaCDNtoAgora(sourcePath, sourceFileName, destinationPath, destinationFileName);  
                string converted = _Execute(lines);
                fm.WriteDestinationFile(converted);
                Console.WriteLine("File converted successfully");
            }else
                throw new Exception($"Something went wrong. Conversion is not supported");
        }   

        /// <summary>
        ///     Apply conversion between 'Minha CDN' and 'Agora' files.
        ///     <param name="sourcePath">the source path file.</param>
        ///     <param name="destinationPath">the destination path file</param>
        ///     <param name="sourceFileName">the source file name</param>
        ///     <param name="destinationFileName">the destination file name</param>
        /// </summary>
        protected void _ConvertMinhaCDNtoAgora(string sourcePath, string sourceFileName, string destinationPath, string destinationFileName)
        {
            if (FileValidator.CheckIfFileIsValid(sourcePath + sourceFileName))
            {
                DestinationFormat = new AgoraFileFormat();
                SourceFormatConverter = new MinhaCDNConverter(DestinationFormat);  
            }else
                throw new Exception($"Something went wrong during conversion between 'Minha CDN' and 'Agora' files");
        }   

        /// <summary>
        ///     Apply file conversion
        ///     <param name="lines">source lines</param>
        /// </summary>
        protected string _Execute(string[] lines)
        {
            return SourceFormatConverter.HeaderInformation() + SourceFormatConverter.SpecificConverter(lines);
        }


    }
}
