using System;
using System.ComponentModel.DataAnnotations;

namespace GoodAppleProj.Models {   
    public class Connection {
        public int FriendId {get;set;}
        public User Friend {get;set;}

        public int UserId {get;set;}
        public User User {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}