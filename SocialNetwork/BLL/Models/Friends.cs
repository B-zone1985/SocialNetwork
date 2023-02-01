using System.Collections.Generic;

namespace SocialNetwork.BLL.Models
{
    public class Friends
    {
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Friends(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}