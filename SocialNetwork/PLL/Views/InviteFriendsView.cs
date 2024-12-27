using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class InviteFriendsView
    {
        private readonly FriendService _friendService;

        public InviteFriendsView(FriendService friendService)
        {
            _friendService = friendService;
        }

        public void Show(int userId)
        {
            Console.WriteLine("Введите email друга, которого хотите добавить:");

            string friendEmail = Console.ReadLine();

            try
            {
                _friendService.AddFriend(userId, friendEmail);
                Console.WriteLine("Друг успешно добавлен!");
            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Произошла ошибка при добавлении друга.");
            }
        }
    }
}
