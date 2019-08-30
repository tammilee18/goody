using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodAppleProj.Models {
    public class Teacher {
        public int TeacherId {get;set;}

        public string District {get;set;}
        public string School {get;set;}
        public string Subject {get;set;}

        public int UserId {get;set;}
        public virtual User User {get;set;}
        public List <Project> Projects {get;set;}
    }
}