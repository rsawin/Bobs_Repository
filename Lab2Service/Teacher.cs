using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Lab2Service
{
   [DataContract]
   public class Teacher: Person
    {

        #region Properties

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public DateTime DateOfHire { get; set; }

        [DataMember]
        public int Salary { get; set; }

        #endregion Properties
    }
}