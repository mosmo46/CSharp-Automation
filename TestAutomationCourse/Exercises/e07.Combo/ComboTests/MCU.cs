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
  
        public FilmsModel mCUModel = new FilmsModel();
        public FilmsModel jsonDataConvert;
        public FilmsModel dataStringToObject;
        public bool sameSuperHeroes = false;
        public bool antManNotExist = false;

        [SetUp]
        public void SetUp()
        {
            // Create the JSON String using ObjectMapper.writeValue()
            string jsonData = "{\"Name\":\"Captain America - The First Avenger\",\"SeriesCounter\":0,\"SuperHeroes\":[\"Thor\",\"Cap\",\"Black Widow\",\"Hawekeye\",\"Hulk\",\"Iron Man\",null,null,null,null]}";
             jsonDataConvert = JsonConvert.DeserializeObject<FilmsModel>(jsonData);

            //LodaDataToObject
            LodaData();
            var dataObjectToString = JsonConvert.SerializeObject(mCUModel);

             dataStringToObject = JsonConvert.DeserializeObject<FilmsModel>(dataObjectToString);
        }
        [Test]

        public void LodaData()
        {
            mCUModel.Name = "Captain America - The First Avenger";
            mCUModel.SeriesCounter = 0;
            mCUModel.SuperHeroes[0] = "Thor";
            mCUModel.SuperHeroes[1] = "Cap";
            mCUModel.SuperHeroes[2] = "Black Widow";
            mCUModel.SuperHeroes[3] = "Hawekeye";
            mCUModel.SuperHeroes[4] = "Hulk";
            mCUModel.SuperHeroes[5] = "Iron Man";
            //dataObjectToString = JsonConvert.SerializeObject(mCUModel);
            //  dataStringToObject = JsonConvert.DeserializeObject<Film>(dataObjectToString);
        }

        [Test]


        // Prove that the JSON String contains the all the names of the super heroes
        public void CheckIfSameSuperHeroes()
        {
            var count = dataStringToObject.SuperHeroes.Length;
            for (int i = 0; i < count; i++)
            {
                if (jsonDataConvert.SuperHeroes[i] == dataStringToObject.SuperHeroes[i])
                {
                    sameSuperHeroes = true;
                }
            }
            Assert.IsTrue(sameSuperHeroes);
        }

        [Test]
        public void CheckIfAntManExistInSuperHeroes()
        {
            var count = dataStringToObject.SuperHeroes.Length;

            for (int i = 0; i < count; i++)
            {
                if (dataStringToObject.SuperHeroes[i] !="Ant-Man")
                {
                    antManNotExist = true; 
                }

            }
            
        Assert.IsTrue(antManNotExist);
        }
    }
}
