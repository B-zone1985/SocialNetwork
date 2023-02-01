using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendView
    {
        UserService userService;
        FriendService friendService;
        public AddFriendView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }

        public void Show(User user)
        {
            var friendAddData = new FriendAddData();
            Console.Write("Введите почту друга: ");
            string inputMail = Console.ReadLine();
            User userFriend = userService.FindByEmail(inputMail);

            try
            {
                friendAddData.idFriend = userFriend.Id;
                friendAddData.id = user.Id;
                friendService.AddFriends(friendAddData);
                SuccessMessage.Show("Друг добавлен");
            }

            catch (UserNotFoundException)
            {
                WrongAddress.Show("Пользователь с такой почтой не найден!");
            }

            catch (ArgumentNullException)
            {
                WrongAddress.Show("Введено не корректное значение!");
            }

            catch (Exception)
            {
                WrongAddress.Show("Произошла ошибка при отправке сообщения!");
            }

        }
    }
}