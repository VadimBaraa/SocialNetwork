using SocialNetwork.BLL.Exceptions;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public interface IFriendService
    {
        void AddFriend(int userId, string email);
    }
    public class FriendService : IFriendService
    {
        private readonly UserRepository _userRepository;
        private readonly FriendRepository _friendRepository;

    public FriendService(UserRepository userRepository, FriendRepository friendRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _friendRepository = friendRepository ?? throw new ArgumentNullException(nameof(friendRepository));
    }

        public void AddFriend(int userId, string friendEmail)
        {
            // Поиск пользователя друга по email
            var friend = _userRepository.FindByEmail(friendEmail);

            if (friend == null)
            {
                throw new UserNotFoundException();
            }

            // Добавление друга
            _friendRepository.AddFriend(userId, friend.id);
        }
    }
}
