using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemEntity
{
    public class EC_tblStaffs
    {
        private string _staffID;

        public string StaffID
        {
            get { return _staffID; }
            set { _staffID = value; }
        }

        private string _staffName;

        public string StaffName
        {
            get { return _staffName; }
            set { _staffName = value; }
        }

        private string _dob;

        public string Dob
        {
            get { return _dob; }
            set { _dob = value; }
        }

        private string _gender;

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _startWorkDay;

        public string StartWorkDay
        {
            get { return _startWorkDay; }
            set { _startWorkDay = value; }
        }

        private string _loginID;

        public string LoginID
        {
            get { return _loginID; }
            set { _loginID = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
