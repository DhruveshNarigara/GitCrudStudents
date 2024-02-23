using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitStudentCrud.Models
{
    public class StudentRegModel
    {
         public int c_studid { get; set; }


        public string? c_studname { get; set; }



        public DateTime c_studdob { get; set; }



        public string? c_studemail { get; set; }


        public string? c_studpassword { get; set; }


        public string? c_studgender { get; set; }


        public string? c_studmobile { get; set; }

        public string? c_studaddress { get; set; }


        public int ?c_studcourse_id { get; set; }

        public IFormFile? c_studphotoFile { get; set; } 
        public IFormFile? c_studuploaddocFile { get; set; } 

        public string? c_studphoto { get; set; }
        public string? c_studuploaddoc { get; set; } 

        public string? c_studlanguages { get; set; }
    }
}