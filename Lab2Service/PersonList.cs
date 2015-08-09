using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Lab2Service
{
    [CollectionDataContract]
    public class PersonList : List<Person>
    {
       /// <summary>
       /// Default "PersonList" constructor
       /// </summary>
        public PersonList() { }
       
        /// <summary>
        /// IEnumerable "PersonList" constructor of "Person" based on source
        /// </summary>
        /// <param name="source"></param>
        public PersonList(IEnumerable<Person> source) : base(source) { }
    }
}