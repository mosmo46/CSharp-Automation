namespace TestAutomationCourse.Demos.d03.JSON
{
    // {
    //  "Person": {
    //    "FirstName": "Joe",
    //    "SurName": "Smith",
    //    "Children": [
    //      { "child": "Jane" },
    //      { "child": "Jim"  },
    //      { "child": "JJ"   }
    //    ]
    //  }
    //}

    public class JSONExamples
    {

        public static string getPerson()
        {
            return @"{
                        'Person': {
                            'FirstName': 'Joe',
                            'SurName': 'Smith',
                            'Children': [
                                {
                                'child': 'Jane'
                                },
                                {
                                'child':'Jim'
                                },
                                {
                                'child': 'JJ'}
                                ]
                          }
                    }";
        }
    }

}
