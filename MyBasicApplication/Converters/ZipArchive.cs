using System.IO;
using ICSharpCode.SharpZipLib.Tar;
using System;

namespace MyBasicApplication.Converters
{
    internal class ZipArchive
    {
        public static void ExtractTar(String tarFileName, String destFolder)
        {

            Stream inStream = File.OpenRead(tarFileName);

            TarArchive tarArchive = TarArchive.CreateInputTarArchive(inStream);
            tarArchive.ExtractContents(destFolder);
            tarArchive.Close();

            inStream.Close();
        }

    }
}