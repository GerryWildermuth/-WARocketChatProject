using System;
using System.DrawingCore;
using System.IO;
using System.Text.RegularExpressions;

namespace SWARocketChat.Extensions
{
    public static class Base64ImageConverter
    {
        public static string ResizeBase64ImageString(string base64String, int desiredWidth, int desiredHeight)
        {
            var matches = Regex.Match(base64String, "data:image\\/(?<format>\\w*);base64,");
            var format = matches.Groups["format"].Value;
            base64String = Regex.Replace(base64String, "data:image\\/\\w*;base64,", "");

            // Convert Base64 String to byte[]
            var imageBytes = Convert.FromBase64String(base64String);

            using (var ms = new MemoryStream(imageBytes))
            {
                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                var image = Image.FromStream(ms, true);

                var imag = ScaleImage(image, desiredWidth, desiredHeight);

                using (var ms1 = new MemoryStream())
                {
                    //First Convert Image to byte[]
                    imag.Save(ms1, imag.RawFormat);
                    var imageBytes1 = ms1.ToArray();

                    //Then Convert byte[] to Base64 String
                    base64String = Convert.ToBase64String(imageBytes1);
                    return $"data:image/{format};base64," + base64String;
                }
            }
        }
        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }
    }
}
