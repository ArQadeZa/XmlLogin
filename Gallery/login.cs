using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Gallery
{
    
    class login
    {
        List<Account> accounts = new List<Account> { }; //list of all the accounts

        public bool exist { get; set; }
        public bool valid { get; set; }
        

        public login()
        {

        }

        //LOG IN WITH ACCOUNT
        public login(string _username,string _password)
        {
            exist = false;
            valid = false;

            deserialize();
            foreach (Account account in accounts)
            {
                if (account.Username == _username && account.Password == _password) //tests if the details are correct
                {
                    valid = true;
                    
                }
                else
                {
                    valid = false;
                }
            }
            accounts = null; //clears the account details from the memory
  
        }

        //CREATE ACCOUNT
        public login(string _username , string _password,string _name,string _surname)
        {
            exist = false;
            accounts.Clear(); // clears the accounts list

            if (File.Exists(@"Accounts.xml"))
            {
                deserialize();
                foreach (Account account in accounts.ToList())
                {
                    if (account.Username == _username) //if the account exists it changes the exists variable to true
                    {
                        exist = true;
                        return; //exits entire method
                    }  
                }
                accounts.Add(new Account(_username, _password, _name, _surname));  //adds the account
                serialize(); // adds values to the xmlfile
            }
            if (!File.Exists(@"Accounts.xml"))
            {
                //Creates file
                accounts.Add(new Account(_username, _password, _name, _surname));
                serialize();
            }
            
        }



        private void deserialize()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Account>)); //declaring a deserializer with the type of  a list of accounts
            using (FileStream fileStream = File.OpenRead(@"Accounts.xml"))
            {
                accounts = (List<Account>)deserializer.Deserialize(fileStream);
            }
        }

        private void serialize()
        {
            using(Stream stream =new FileStream(@"Accounts.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Account>));
                serializer.Serialize(stream, accounts);
            }
            accounts.Clear();
        }
    }
}
