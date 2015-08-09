using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;

namespace Lab2Service
{
	public class SchoolService : ISchoolService
	{
        /// <summary>
        /// Create a new student record with all available attributes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="dob"></param>
        /// <param name="gender"></param>
        /// <param name="major"></param>
        /// <param name="units"></param>
        /// <param name="gpa"></param>
        /// <returns></returns>
        public Student AddStudent(string id, string lastName, string firstName, DateTime dob, 
            GenderEnum gender, string major, float units, float gpa)
		{
			var data = DataStore.LoadData();
			Student result = null;
			var student = GetStudent(id);
			if (student == null)
			{
				// Student doesn't exist
				result = new Student() { ID = id, LastName = lastName, FirstName = firstName,
					DOB = dob, Gender = gender, Major = major, Units = units, GPA = gpa	};
				data.Add(result);
				DataStore.SaveData();
			}
			return result;
		}

        /// <summary>
        /// Deletes a student record based on the student's ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteStudent(string id)
		{
			var data = DataStore.LoadData();
			data.RemoveAll(person => person is Student && (person as Student).ID == id);
			DataStore.SaveData();
		}

        /// <summary>
        /// Find Student based on a student's ID number
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public Student GetStudent(string id)
		{
			var data = DataStore.LoadData();
			var query = from person in data
						let student = person as Student
						where student != null && student.ID == id
						select student;
			return query.FirstOrDefault();
		}

        /// <summary>
        /// Find all students and returns a list
        /// </summary>
        /// <returns></returns>
		public List<Student> GetStudents()
		{
			var data = DataStore.LoadData();
			var query = from person in data
						let student = person as Student
						where student != null
						select student;
			return query.ToList();
		}

        /// <summary>
        /// Updates all attributes of a students record based on their student ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="dob"></param>
        /// <param name="gender"></param>
        /// <param name="major"></param>
        /// <param name="units"></param>
        /// <param name="gpa"></param>
        /// <returns></returns>
		public Student UpdateStudent(string id, string lastName, string firstName, DateTime dob, GenderEnum gender, string major, float units, float gpa)
		{
			// Simplest technique is to remove then add
			DeleteStudent(id);
			return AddStudent(id, lastName, firstName, dob, gender, major, units, gpa);
		}

        /// <summary>
        /// Create a new teacher record with all available attributes provided
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="dob"></param>
        /// <param name="gender"></param>
        /// <param name="doh"></param>
        /// <param name="salary"></param>
        /// <returns></returns>
        public Teacher AddTeacher(int id, string lastName, string firstName, DateTime dob, GenderEnum gender, DateTime doh, int salary)
        {
            var data = DataStore.LoadData();
            Teacher result = null;
            var teacher = GetTeacher(id);
            if (teacher == null)
            {
                // Teacher doesn't exist
                result = new Teacher()
                {
                    ID = id,
                    LastName = lastName,
                    FirstName = firstName,
                    DOB = dob,
                    Gender = gender,
                    DateOfHire = doh,
                    Salary = salary,
                };
                data.Add(result);
                DataStore.SaveData();
            }
            return result;
        }

        /// <summary>
        /// Deletes a teacher based on a specified ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteTeacher(int id)
        {
            var data = DataStore.LoadData();
            data.RemoveAll(person => person is Teacher && (person as Teacher).ID == id);
            DataStore.SaveData();
        }

        /// <summary>
        /// Returns a list of all teachers
        /// </summary>
        /// <returns></returns>
        public List<Teacher> GetTeachers()
        {
            var data = DataStore.LoadData();
            var query = from person in data
                        let teacher = person as Teacher
                        where teacher != null
                        select teacher;
            return query.ToList();
        }

        /// <summary>
        /// Returns a specified teacher based on their ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Teacher GetTeacher(int id)
        {
            var data = DataStore.LoadData();
            var query = from person in data
                        let teacher = person as Teacher
                        where teacher != null && teacher.ID == id
                        select teacher;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Updates all avalable attributes in teacher's record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="dob"></param>
        /// <param name="gender"></param>
        /// <param name="doh"></param>
        /// <param name="salary"></param>
        /// <returns></returns>
        public Teacher UpdateTeacher(int id, string lastName, string firstName, DateTime dob, GenderEnum gender, DateTime doh, int salary)
        {
            // Simplest technique is to remove then add
            DeleteTeacher(id);
            return AddTeacher(id, lastName, firstName, dob, gender, doh, salary);
        }

        /// <summary>
        /// Returns a list of persons to PersonList() based on First and Last name
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public PersonList GetPeople(string lastName, string firstName)
		{
			var data = DataStore.LoadData();
			var query = data.AsQueryable();
			if (!string.IsNullOrEmpty(lastName))
			{
				query = query.Where(p => p.LastName == lastName);
			}
			if (!string.IsNullOrEmpty(firstName))
			{
				query = query.Where(p => p.FirstName == firstName);
			}
			return new PersonList(query);
		}
    }
}
