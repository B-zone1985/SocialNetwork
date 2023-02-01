using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class UserFriends
    {
        public void Show(IEnumerable<Friends> userFriends)
        {
            Console.WriteLine("Ваши друзья:");


            if (userFriends.Count() == 0)
            {
                Console.WriteLine("Друзей не обнаружно");
                return;
            }

            userFriends.ToList().ForEach(friend =>
            {
                Console.WriteLine("Ваш друг: " + friend.FirstName + " " + friend.LastName);
            });
        }
    }
}