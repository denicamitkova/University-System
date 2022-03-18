using AppService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        [OperationContract]
        List<UniversityDTO> GetUniversities();

        [OperationContract]
        string PostUniversity(UniversityDTO universityDTO);

        [OperationContract]
        UniversityDTO GetUniversityById(int id);

        [OperationContract]
        string PutUniversity(UniversityDTO universityDTO);

        [OperationContract]
        string DeleteUniversity(int id);


        //StudentManagmentService
        [OperationContract]
        List<StudentDTO> GetStudents();

        [OperationContract]
        string PostStudent(StudentDTO studentDTO);

        [OperationContract]
        StudentDTO GetStudentById(int id);

        [OperationContract]
        string DeleteStudent(int id);

        //TeacherManagmentService
        [OperationContract]
        List<TeacherDTO> GetTeachers();

        [OperationContract]
        string PostTeacher(TeacherDTO teacherDTO);

        [OperationContract]
        TeacherDTO GetTeacherById(int id);

        [OperationContract]
        string DeleteTeacher(int id);

    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfService.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
