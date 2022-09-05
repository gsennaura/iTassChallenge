namespace Guilherme.SenaGuilherme.Models.Files
{
    public class FileValidator
    {
        public static bool CheckIfFileIsValid(string path)
        {
            if (path.ToLower().Contains(".txt"))
            {
                try
                {
                    if (!File.Exists(path))
                        File.Create(path);
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
