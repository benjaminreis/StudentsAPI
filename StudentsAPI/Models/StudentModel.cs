using System;
using System.Data;

namespace StudentsAPI.Models
{
    internal class StudentModel
    {
        internal StudentModel()
        {
        }


        public long ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string School { get; set; }
        public string Major { get; set; }

        internal StudentModel(DataRow dr)
        {
            this.ID = int.Parse((dr["id"] != null ? dr["id"].ToString() : ""));
            this.FirstName = dr["FirstName"] != null ? dr["FirstName"].ToString() : "";
            this.LastName = dr["LastName"] != null ? dr["LastName"].ToString() : "";
            this.Age = int.Parse((dr["age"] != null ? dr["age"].ToString() : ""));

            this.School = dr["school"] != null ? dr["school"].ToString() : "";
            this.Major = dr["major"] != null ? dr["major"].ToString() : "";

        }
    }



}




//public long Id { get; set; }

//public string FirstName { get; set; }

//public string LastName { get; set; }

//public long RoleID { get; set; }

//public string Role { get; set; }

//public Boolean Active { get; set; }



//public Volunteer(DataRow dr)
//{
//    this.Id = int.Parse((dr["id"] != null ? dr["id"].ToString() : ""));
//    this.FirstName = dr["FirstName"] != null ? dr["FirstName"].ToString() : "";
//    this.LastName = dr["LastName"] != null ? dr["LastName"].ToString() : "";
//    this.Role = dr["Role"] != null ? dr["Role"].ToString() : "None";
//    this.RoleID = long.Parse((dr["roleId"] != null ? dr["roleId"].ToString() : "1"));
//    this.Active = bool.Parse((dr["Active"] != null ? dr["Active"].ToString() : "1"));

//}

