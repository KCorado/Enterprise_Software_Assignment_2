using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_Comp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        List<Students> GetAllStudents();

        [OperationContract]
        List<Students> GetAllGoing();

        [OperationContract]
        Students GetGoingById(int id);

        [OperationContract]
        int AddStudent(int StudentId, string Name, string Email, string Phone, string TechnicalInterest, string SocialNet, string accRegret);
    }


    [DataContract]
    public class Students
    {
        [DataMember]
        public int StudentId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string TechnicalInterest { get; set; }
        [DataMember]
        public string SocialNetworkInterest { get; set; }
        [DataMember]
        public string AcceptRegret { get; set; }

    }
}
