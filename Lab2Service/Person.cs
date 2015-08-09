using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Lab2Service
{
    [KnownType(typeof(Student))]
    [KnownType(typeof(Teacher))]
    [DataContract]
    public class Person
    {
        #region Properties
        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public DateTime DOB { get; set; }

        [DataMember]
        public GenderEnum Gender { get; set; }

        #endregion Properties
    }
}