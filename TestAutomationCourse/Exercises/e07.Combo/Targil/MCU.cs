using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static TestAutomationCourse.Exercises.e07.Combo.Targil.MCUModel;

namespace TestAutomationCourse.Exercises.e07.Combo.Targil
{
    internal class MCU
    {
        public class Film
        {
            public string Name { get; set; }
            public int SeriesCounter { get; set; }

            public string[] SuperHeroes { get; set; } = new string[10];

        }

        public Film mCUModel = new Film();
       
        public bool sameSuperHeroes = false;
        [Test]



        public void LodaData()
        {
            
            mCUModel.Name = "Captain America - The First Avenger";
            mCUModel.SeriesCounter = 0;
            mCUModel.SuperHeroes[0]= "Thor";
            mCUModel.SuperHeroes[1] = "Cap";
            mCUModel.SuperHeroes[2] = "Black Widow";
            mCUModel.SuperHeroes[3] = "Hawekeye";
            mCUModel.SuperHeroes[4] = "Hulk";
            mCUModel.SuperHeroes[5] = "Iron Man";
        


            //dataObjectToString = JsonConvert.SerializeObject(mCUModel);

           //  dataStringToObject = JsonConvert.DeserializeObject<Film>(dataObjectToString);
            


        }

        [Test]
          

        public void CheckIfSameSuperHeroes()
        {
            LodaData();
           string jsonData = "{\"Name\":\"Captain America - The First Avenger\",\"SeriesCounter\":0,\"SuperHeroes\":[\"Thor\",\"Cap\",\"Black Widow\",\"Hawekeye\",\"Hulk\",\"Iron Man\",null,null,null,null]}";

            var jsonDataConvert = JsonConvert.DeserializeObject<Film>(jsonData);

           var dataObjectToString = JsonConvert.SerializeObject(mCUModel);

           var dataStringToObject = JsonConvert.DeserializeObject<Film>(dataObjectToString);

            var count = 10;

            for (int i = 0; i < count; i++)
            {
                if (jsonDataConvert.SuperHeroes[i] == dataStringToObject.SuperHeroes[i])
                {
                    sameSuperHeroes = true;
                }
            }

            Assert.IsTrue(sameSuperHeroes);
        }
}
}
