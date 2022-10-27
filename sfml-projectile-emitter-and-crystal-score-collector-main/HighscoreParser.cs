using System;
using System.IO;
using SFML.System;
using SFML.Graphics;

namespace Game_Score
{
    public class HighscoreParser
    {
        private static HighscoreParser instance;

        public static HighscoreParser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HighscoreParser();
                }
                return instance;
            }
        }

        private HighscoreParser(){}

        StreamReader reader = null;
        StreamWriter writer = null;

        public void SetHighScore(int score)
        {
            string highScore = score.ToString();
            try
            {
                writer = new StreamWriter("Highscore.txt");

                using(writer)
                {
                    writer.Write(highScore);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("No file");
            }
            catch (IOException)
            {
                Console.WriteLine("General IO problem");
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public int GetHighScore()
        {
            try
            {
                string score;
                reader = new StreamReader("Highscore.txt");

                using(reader)
                {
                    score = reader.ReadLine();
                }
                int result = Int32.Parse(score);
                return result;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("No file");
                return 0;
            }
            catch (IOException)
            {
                Console.WriteLine("General IO problem");
                return 0;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public void Update()
        {
            
        }
    }
}