using System.Collections.Generic;

namespace TestAutomationCourse.Demos.d04.Serialization
{
    public class Album
    {
        public Beatles beatles;
    }

    public class Beatles
    {
        public Artist[] artists;
    }

    public class Artist
    {
        public string name { get; set; }
        public string plays { get; set; }
        public string isAlive { get; set; }
    }
}