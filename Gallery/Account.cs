using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization; // for serialization
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    [Serializable()]
    public class Account : ISerializable
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Account()
        {

        }

        public Account(string _username = "", string _password = "", string _name = "", string _surname = "")
        {
            //Assign values to properties
            this.Username = _username;
            this.Password = _password;
            this.Name = _name;
            this.Surname = _surname;
        }

        //serialization function
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //assign key value pairs for all the data
            info.AddValue("Username", this.Username);
            info.AddValue("Password", this.Password);
            info.AddValue("Name", this.Name);
            info.AddValue("Surname", this.Surname);
        }

        //deserialization function
        public Account(SerializationInfo info, StreamingContext context)
        {
            this.Username = (string)info.GetValue("Username", typeof(string));
            this.Password = (string)info.GetValue("Password", typeof(string));
            this.Name = (string)info.GetValue("Name", typeof(string));
            this.Surname = (string)info.GetValue("Surname", typeof(string));
        }
    }
}
    