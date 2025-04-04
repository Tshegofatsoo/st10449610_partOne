using System;
using System.Drawing;
using System.IO;


namespace st10449610_partOne
{
    public class ascii_art_display
    {
        public ascii_art_display()
        {
            //get full location of the project
            string fullLocation = AppDomain.CurrentDomain.BaseDirectory;


            string newLocation = fullLocation.Replace("bin\\Debug\\", "");
            string full_path = Path.Combine(newLocation, "ultron.jpg");

            //create ASCII image using Bitmap class 
            Bitmap image = new Bitmap(full_path);
            image = new Bitmap(image, new Size(60, 50));

            //outer and inner loop
            for (int height = 0; height < image.Height; height++)
            {
                //inner loop
                for (int width = 0; width < image.Width; width++)
                {
                    Color pixelColor = image.GetPixel(width, height);
                    int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    char asciiChar = gray > 200 ? '.' : gray > 150 ? '*' : gray > 100 ? 'o' : gray > 5 ? '#' : '@';

                    Console.Write(asciiChar);
                } //end of inner loop
                Console.WriteLine();

            }//end of outer loop
        }
    }//end of class
}//end of namespace