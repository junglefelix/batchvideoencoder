using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchVideoEncoder.Helpers
{
    public static class GeneralHelper
    {
        public static string GenerateRandomWord(int minLength, int maxLength)
        {
            char[] letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            Random rnd = new Random();
            int randomlength = rnd.Next(minLength, maxLength);
            char[] randomLetters = new char[randomlength];
            for (int i = 0; i < randomlength; i++)
            {
                int randomIndex = rnd.Next(0, 51);
                randomLetters[i] = letters[randomIndex];
            }
            string randomName = new string(randomLetters);
            return randomName;
        }
        public static double getSizeInKB(string mediaInfoStr)
        {
            mediaInfoStr = mediaInfoStr.Replace(" ", String.Empty);
            double multiplier;
            double value;
            if (mediaInfoStr.Contains("GiB"))
            {
                multiplier = 1024.0 * 1024.0;
                value = Convert.ToDouble(mediaInfoStr.Substring(0, mediaInfoStr.IndexOf("GiB"))) * multiplier;
            }
            else if (mediaInfoStr.Contains("MiB"))
            {
                multiplier = 1024.0;
                value = Convert.ToDouble(mediaInfoStr.Substring(0, mediaInfoStr.IndexOf("MiB"))) * multiplier;
            }
            else if (mediaInfoStr.Contains("KiB"))
            {
                multiplier = 1.0;
                value = Convert.ToDouble(mediaInfoStr.Substring(0, mediaInfoStr.IndexOf("KiB"))) * multiplier;
            }
            else return -1;
            return value;
        }
    }
}
