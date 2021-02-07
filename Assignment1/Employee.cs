using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Assignment1
{
    /// <summary>
    /// Employee class must implement the Comparable interface.
    /// The comparison of employees is based on the EmployeeID.
    /// </summary>
    public class Employee : IComparable<Employee>
    {
        private int employeeId;
        private string firstName = null;
        private string lastName = null;

        /// <summary>
        /// Constructor, initializes only the employeeID, but sets the other fields to null
        /// </summary>
        /// <param name="employeeId"></param>
        public Employee(int employeeId)
        {
            this.employeeId = employeeId;
        }

        /// <summary>
        /// Constructor, initializes private fields using parameter values
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public Employee(int employeeId, string firstName, string lastName)
        {
            this.employeeId = employeeId;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        /// <summary>
        /// Returns the employeeID
        /// </summary>
        /// <returns>employeeId</returns>
        public int EmployeeID()
        {
            return this.employeeId;
        }

        /// <summary>
        /// Returns the firstName
        /// </summary>
        /// <returns>firstName</returns>
        public string FirstName()
        {
            return this.firstName;
        }

        /// <summary>
        /// Returns the lastName
        /// </summary>
        /// <returns>lastName</returns>
        public string LastName()
        {
            return this.lastName;
        }

        /// <summary>
        /// Employees must be comparable with one another based on their EmployeeID value.
        /// Larger values are bigger than smaller values.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public int CompareTo(Employee o)
        {
            return employeeId.CompareTo(o.employeeId);

            //if (this.employeeId < o.EmployeeID())
            //{
            //    return -1;
            //}
            //else if (this.employeeId > o.EmployeeID())
            //{
            //    return 1;
            //}
            //else
            //{
            //    return 0;
            //}
        }

        /// <summary>
        /// When printed, an employee will appear as ‘id fname lname’ 
        /// (e.g. ‘6782342 John Doe’ or ‘77853224 null null’).
        /// </summary>
        /// <returns>Prints: employeeId firstName lastName</returns>
        public override String ToString()
        {
            string fN, lN;
            fN = String.IsNullOrEmpty(this.firstName) ? "null" : this.firstName;
            lN = String.IsNullOrEmpty(this.lastName) ? "null" : this.lastName;

            return this.employeeId + " " + fN + " " + lN;
        }


    }
}
