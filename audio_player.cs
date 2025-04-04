using System;
using System.Media;
using System.IO;

namespace st10449610_partOne
{
    //importing the system.media
    using System.Media;
    using System;
    public class audio_player
    {

        public audio_player()
        {

            //getting the application full location
            string startinglocation = AppDomain.CurrentDomain.BaseDirectory;

            Console.WriteLine(startinglocation);

            //replace the bin\debug\folders so that we can get the audio
            string new_location = startinglocation.Replace("bin\\Debug\\", "");
            Console.WriteLine(new_location);

            //combine both the new location and audio file
            string full_path = Path.Combine(new_location, "ultronn.wav");


            //try and catch, error handling
            try
            {
                //using function to create play instance
                using (SoundPlayer play = new SoundPlayer(full_path))
                {

                    play.Play();
                }//end of using
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }//end of catch

        } //end of constructor

        //method to play the sound
        private void PlayAudio(string full_path)
        {
            //try and catch
            try
            {

                using (SoundPlayer play = new SoundPlayer(full_path))
                {
                    //to play the sound use this
                    play.PlaySync();

                }//end of using

            }
            catch (Exception error)
            {
                //then show the error message
                Console.WriteLine(error.Message);

            }//end of try and catch

        }//end of method play wav

    } //end of class
} //end of namespace