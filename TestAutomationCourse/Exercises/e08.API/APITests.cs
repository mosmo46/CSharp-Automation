using NUnit.Framework;
using System;

namespace TestAutomationCourse.Exercises.e08.API
{
    [TestFixture]
    internal class APITests
    {
        // JsonPlaceHolder api
        // Use JArray.Parse
        [Test]
        public void number_of_total_posts_is_100()
        {
        }

        [Test]
        public void title_of_first_post_for_userid_1_contains_facere()
        {
        }

        // apichallenges api
        [Test]
        public void create_todo_and_get_it_by_its_id()
        {
            Todo newTodo = new Todo();
            newTodo.title = "My Todo";
            newTodo.doneStatus = false;
            newTodo.description = "dognabbit";


        }

        // use body("Y", hasItem(X)); to find if the ID was added.
        [Test]
        public void create_todo_and_check_if_added_to_todos()
        {
            Todo newTodo = new Todo();
            newTodo.title = "My Todo";
            newTodo.doneStatus = false;
            newTodo.description = "dognabbit";

        }

        // Update the description field
        [Test]
        public void create_get_update_delete_todo()
        {
            Todo new_todo = new Todo();
            new_todo.title = "new title";
            new_todo.description = "new description";
            new_todo.doneStatus = false;

        }
    }
}
