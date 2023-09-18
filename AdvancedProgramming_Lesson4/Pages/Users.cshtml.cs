using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvancedProgramming_Lesson4.Pages
{
    [Authorize("Admin")]
    public class UsersModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UsersModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public IList<IdentityUser> Users { get; set; }
        public async Task OnGetAsync()
        {
            Users = await _userManager.Users.ToListAsync();
        }
    }

}
