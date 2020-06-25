using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace DiaDeBolaClassLibrary
{
    public static class FileManager
    {
        public static string GetLegalFilename(string illegalName)
        {
            if (illegalName is null)
            {
                return "";
            }

            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            string legal_market_id = r.Replace(illegalName, "_");
            return legal_market_id;
        }


        public static void EnsureDirectoryExists(string filePath)
        {
            var fi = new FileInfo(filePath);
            if (!fi.Directory.Exists) Directory.CreateDirectory(fi.DirectoryName);
        }

    }
}
