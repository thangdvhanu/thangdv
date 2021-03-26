using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Member
    {
        private string _firstName;
        private string _lastName;
        private string _gender;
        private DateTime _DOB;
        private string _phoneNumber;
        private string _birthPlace;
        private DateTime _startDate;
        private DateTime _endDate;

        [Required]
        public string FirstName
        {
            get { return _firstName; }
            set { this._firstName = value; }
        }
        [Required]
        public string LastName
        {
            get { return _lastName; }
            set { this._lastName = value; }
        }
        [Required]
        public string Gender
        {
            get { return _gender; }
            set { this._gender = value; }
        }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB
        {
            get { return _DOB; }
            set { this._DOB = value; }
        }
        [Required]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { this._phoneNumber = value; }
        }
        public string BirthPlace
        {
            get { return _birthPlace; }
            set { this._birthPlace = value; }
        }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate
        {
            get { return _startDate; }
            set { this._startDate = value; }
        }
        [DataType(DataType.Date)]
        public DateTime EndDate
        {
            get { return _endDate; }
            set { this._endDate = value; }
        }
    }
}