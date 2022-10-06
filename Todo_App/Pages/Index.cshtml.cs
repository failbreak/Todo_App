using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Todo_App.Model;
using Todo_App.Repository;

namespace Todo_App.Pages
{
    public class IndexModel : PageModel
    {

       

        private readonly ITaskRepo _repo;

        public List<To_Do> ToDoList { get; set; }

        [BindProperty, MaxLength(50), Required]
        public string Title { get; set; }

        [BindProperty, MaxLength(25), Required]
        public string Desc { get; set; }

        [BindProperty]
        public DateTime Created { get; set; }

        [BindProperty, Range(0, 2)]
        public int prio { get; set; }

        [BindProperty]
        public bool IsDone { get; set; }

        [BindProperty]
        public Guid GUid { get; set; }

        public bool ErrorTriggered { get; set; }
        public bool Success { get; set; }
        public IndexModel(ITaskRepo repo)
        {
            _repo = repo;
            ToDoList = repo.GetallTask();
        }

        public void OnGet(string status)
        {
           
            switch (status)
            {
                case "error":
                    ErrorTriggered = true;
                    break;
                default:
                    Success = true;
                    break;
            }
        }
        public IActionResult OnPostAdd()
        {

            GUid = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                _repo.AddTask((To_Do.Priority)prio, Title, Desc, Created);
                return RedirectToPage();
            }
            else
            {
                ErrorTriggered = true;
                return RedirectToPage("Index", new { status = "error" });
            }

        }
        public IActionResult OnPostEdit()
        {
            if (ModelState.IsValid)
            {
                _repo.EditTask(GUid.ToString(), Desc, Title, prio, IsDone);
                return RedirectToPage("index", new { status = "success" });
            }
            else
            {
                ErrorTriggered = true;
                return RedirectToPage("Index", new { status = "error" });
            }
        }
        public IActionResult OnPostComp()
        {
            _repo.CompTask(GUid.ToString());
            return RedirectToPage();
        }
        public IActionResult OnPostDelete()
        {
            _repo.DelTask(GUid.ToString());
            return RedirectToPage();
        }

        public IActionResult OnPostDelAll()
        {
            _repo.DelAll();
            return RedirectToPage();
        }
    }
}