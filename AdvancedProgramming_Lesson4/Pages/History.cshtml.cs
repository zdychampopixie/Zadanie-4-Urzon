using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdvancedProgramming_Lesson4.Data;
using AdvancedProgramming_Lesson4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AdvancedProgramming_Lesson4.Pages
{
    [Authorize]
    public class HistoryModel : PageModel
    {
        private readonly
       AdvancedProgramming_Lesson4.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public
       HistoryModel(AdvancedProgramming_Lesson4.Data.ApplicationDbContext
       context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IList<ChatMessage> ChatMessage { get; set; }
        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            ChatMessage = await _context.ChatMessages.Where(m => m.User
           == user).ToListAsync();
        }
    }
}
