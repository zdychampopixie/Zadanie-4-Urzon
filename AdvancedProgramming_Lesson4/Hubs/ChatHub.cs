using System.Threading.Tasks;
using AdvancedProgramming_Lesson4.Data;
using AdvancedProgramming_Lesson4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace AdvancedProgramming_Lesson4.Hubs
{
    public class ChatHub : Hub
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        public ChatHub(UserManager<IdentityUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }
        public async Task SendMessage(string message)
        {
            var user = await _userManager.GetUserAsync(Context.User);
            var chatMessage = new ChatMessage()
            {
                User = user,
                Message = message
            };
            _dbContext.Add(chatMessage);
            await _dbContext.SaveChangesAsync();
            await Clients.All.SendAsync("ReceiveMessage", user.UserName,
           message);
        }
    }








}
