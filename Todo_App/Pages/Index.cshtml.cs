using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Todo_App.Model;
using Todo_App.Repository;

namespace Todo_App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITaskRepo _repo;
        public List<To_Do> ToDoList { get; set; }
        public IndexModel(ITaskRepo repo)
        {
            _repo = repo;
            ToDoList = repo.GetallTask();
        }
        public void OnGet()
        {
            
        }
        public void OnGetGetTask()
        {

        }
    }
}