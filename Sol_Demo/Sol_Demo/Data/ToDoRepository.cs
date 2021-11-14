using Sol_Demo.Model;

namespace Sol_Demo.Data
{
    public class ToDoRepository
    {
        public List<ToDoModel> ToDoList { get; set; }

        public ToDoRepository()
        {
            ToDoList = new List<ToDoModel>()
            {
                new ToDoModel(1,"Make BreakFast",true),
                new ToDoModel(2,"Sending Emails",false)
            };
        }
    }
}