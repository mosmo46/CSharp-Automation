using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace TestAutomationCourse.Exercises.e05.JSON
{
    internal class filmsJSONTests
    {
        private JArray jsonFilms;

        [SetUp]
        public void Setup()
        {
            using (var sr = new StreamReader(".//Exercises//e05.JSON//films.json"))
            {
                var reader = new JsonTextReader(sr);
                jsonFilms = JArray.Load(reader);

            }


        }
        [Test]

        public void FindBilingualMovies()
        {
            var arrayLength = jsonFilms.Count;

            int bilingualMovies = 0;
            for (int i = 0; i < arrayLength; i++)
            {
                string languages = (string)jsonFilms[i]["Language"];
                string[] counter = languages.Split(',');
                if (counter.Length == 2)
                {
                    bilingualMovies++;
                }
            }
            Assert.AreEqual(bilingualMovies, 5);
        }
        [Test]
        public void FindActorsBefore2010()
        {
            var arrayLength = jsonFilms.Count;

            List<string> actors = new List<string>();

            for (int i = 0; i < arrayLength; i++)
            {
                string fullDate = (string)jsonFilms[i]["Released"];

                int releasedMovieYear = ConvertToDateTime(fullDate == "N/A" ? "0" : fullDate);

                if (releasedMovieYear < 2010)
                {
                    actors.Add((string)jsonFilms[i]["Actors"]);
                }
            }
            foreach (var actor in actors)
            {
                Console.WriteLine(actor);
            }
            Assert.AreEqual(16, arrayLength);
        }

        private int ConvertToDateTime(string value)
        {

            DateTime convertedDate;

            try
            {
                convertedDate = Convert.ToDateTime(value);
                return convertedDate.Year;
            }
            catch (FormatException)
            {
                Console.WriteLine("'{0}' is not in the proper format.", value);
            }
            return 0;
        }

        [Test]
        public void CalculationAverageByImdbRatingMore200()
        {
            var arrayLength = jsonFilms.Count;
            List<float> ratingList = new List<float>();
            for (int i = 0; i < arrayLength; i++)
            {
                string imdbVotes = (string)jsonFilms[i]["imdbVotes"];
                int r = int.Parse(imdbVotes == "N/A" ? "0" : imdbVotes, NumberStyles.AllowThousands, new CultureInfo("en-au"));

                if (r > 200000)
                {
                    string movieRating = (string)jsonFilms[i]["imdbRating"];
                    float convertMovieRating = float.Parse(movieRating == "N/A" ? "0" : movieRating, CultureInfo.InvariantCulture.NumberFormat);
                    ratingList.Add(convertMovieRating);
                }
            }
            foreach (var item in ratingList)
            {
                Console.WriteLine(item);
            }

            double average = ratingList.Average();

            int convertAverageToInt = Convert.ToInt32(average);
            Console.WriteLine("average is " + convertAverageToInt.ToString());
            Assert.AreEqual(convertAverageToInt, 8);
        }

        [Test]
        public void FindCrimeMovies()
        {
            var jsonFilms1 = jsonFilms;

            int crimeMoviesOrTv = 0;

            for (int i = 0; i < jsonFilms1.Count; i++)
            {
                string movieOrTvGenre = (string)jsonFilms1[i]["Genre"];

                string[] genre = movieOrTvGenre.Split(',');

                for (int j = 0; j < genre.Length; j++)
                {
                    if (genre[j].Trim() == "Crime")
                    {
                        crimeMoviesOrTv++;
                    }
                }
            }
            Assert.AreEqual(crimeMoviesOrTv, 6);
        }

    }
}
