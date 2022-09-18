using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Todo_App.Model;
using Todo_App.Repository;

namespace Todo_App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITaskRepo _repo;

        [BindProperty]
        public List<To_Do> ToDoList { get; set; }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Desc { get; set; }

        [BindProperty]
        public DateTime Created { get; set; }

        [BindProperty]
        public bool IsDone {get; set; }
        public IndexModel(ITaskRepo repo)
        {
            _repo = repo;
            ToDoList = repo.GetallTask();
        }
        public void OnGet()
        {
            ToDoList = _repo.GetallTask();
        }
        public void OnGetGetTask()
        {
            
        }
    }
}