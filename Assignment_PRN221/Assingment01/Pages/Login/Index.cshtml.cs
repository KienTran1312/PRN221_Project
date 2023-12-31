using Assingment01.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assingment01.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly Prn221Asm1Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public IndexModel(Prn221Asm1Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Username == Username && a.Password == Password);

            if (account != null)
            {
                _httpContextAccessor.HttpContext.Session.SetInt32("AccountId", account.AccountId);
                if (account.Type.Equals("Staff"))
                {
                    return RedirectToPage("/Index");
                }
                else
                {
                    return RedirectToPage("/home/index");
                }
            }
            else
            {
                Username = string.Empty;
                Password = string.Empty;
                ErrorMessage = "Wrong username or password!";
                return RedirectToPage("/Login/Index");
            }
        }
    }
}