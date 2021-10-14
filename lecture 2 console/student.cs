using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lecture_2_console
{
    public class student
    {
        public string srStudentName;
        public long irStudentNumber;

        public string returnStudentProperties()
        {
            return srStudentName + " : no: " + irStudentNumber;
        }
    }

    public class student2
    {
        public string srStudentName;
        public long irStudentNumber;

        public static string returnStudentProperties(student2 myStudent)
        {
            return myStudent.srStudentName + " : no: " + myStudent.irStudentNumber;
        }
    }

    public class propFieldExample
    {
        public propFieldExample(int irInput)
        {
            irField_1 = irInput;
            irProp_1 = irInput;
            irProp_2 = irInput;
            irProp_3 = irInput;
            irProp_4 = irInput;
        }

        public int irField_1;//field
        public int irProp_1 { get; set; }//default property

        private int _irProp2; //private field

        public int irProp_2   //public property
        {
            get { return _irProp2; }   // get method
            set { _irProp2 = value; }  // set method
        }

        private int _irProp3; // field

        public int irProp_3     //public property
        {
            get { return _irProp3 * _irProp3; }   // get method
            set { _irProp3 = value; }  // set method
        }

        private int _irProp4; // field

        public int irProp_4   //public property
        {
            get { return _irProp4; }   // get method
            set { _irProp4 = value / 2; }  // set method
        }

        public int returnSumofPrivateValues()
        {
            return _irProp2 + _irProp3 + _irProp4;
        }

        protected  int returnSumofPrivateValues_protected()
        {
            return _irProp2 + _irProp3 + _irProp4;
        }

        internal int returnSumofPrivateValues_internal()
        {
            return _irProp2 + _irProp3 + _irProp4;
        }

        public int returnSumofPrivateValues2()
        {
            return _irProp2 + _irProp3 + _irProp4;
        }
    }
}
