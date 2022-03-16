using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using System.Text.Json;

namespace WallpaperHourly
{
    public class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        public static void Main(string[] args)
        {
            var inputFilePath = args[0];
            StreamWriter str = File.CreateText("C:\\temp\\WallpaperHourlyLogs.txt");
           
            var fileStream = File.OpenRead(inputFilePath);
            InputFile inputFile;
            try
            {
                inputFile = JsonSerializer.Deserialize<InputFile>(fileStream);
                str.WriteLine($"Succesfully deserialize inputFile {inputFilePath}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("an error occured during deserialization");
                str.WriteLine("an error occured during deserialization");
                return;
            }

            var hour = DateTime.Now.Hour;
            var imagePathForNow = inputFile.GetPathForHour(hour);
            Console.WriteLine(imagePathForNow);
            try
            {
                str.WriteLine(ChangeWallPaperWithPath(imagePathForNow));
            }
            catch(Exception ex)
            {
                str.WriteLine(ex.Message);
            }
            str.Close();
        }

        private static int ChangeWallPaperWithPath(string path)
        {
            return SystemParametersInfo(0x14, 0, path, 0x01 | 0x02);
        }
    }
}
