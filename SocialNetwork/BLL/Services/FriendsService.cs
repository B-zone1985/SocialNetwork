using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;
        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        public IEnumerable<Friends> GetAllFriendsByUserId(int recipientId)
        {
            var friends = new List<Friends>();

            friendRepository.FindAllByUserId(recipientId).ToList().ForEach(m =>
            {
                UserEntity friend = userRepository.FindById(m.friend_id);
                friends.Add(new Friends(friend.id, friend.firstname, friend.lastname));
            });

            return friends;
        }


        public void AddFriends(FriendAddData friendAddData)
        {
            var friendEntity = new FriendEntity()
            {
                user_id = friendAddData.id,
                friend_id = friendAddData.idFriend
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}