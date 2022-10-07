using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Todo_App.Model;
using Todo_App.Repository;

namespace Todo_App.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserRepo _repo;
        private readonly List<Users> _userss;

        [BindProperty, Required]
        public string Username { get; set; }

        [BindProperty, Required]
        public string Password { get; set; }
        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        public LoginModel(IUserRepo repo)
        {
            _repo = repo;
            _userss = repo.GetUsers();
        }
        public void OnGet()
        {

        }
        public void OnPost()
        {
        }
    }
}
