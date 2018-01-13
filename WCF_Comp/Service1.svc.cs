using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_Comp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        
        public void DoWork()
        {
        }

        public List<Students> GetAllStudents()
        {
            List<Attend> attendList = new List<Attend>();
            StudentCompetitionEntities tstDb = new StudentCompetitionEntities();
            var lstAttd = from k in tstDb.Attends select k;

            List<Students> studentList = new List<Students>();
            var lstStd = from k in tstDb.Students select k;
            foreach (var stdItem in lstStd)
            {
                foreach (var attdItem in lstAttd)
                    if (stdItem.StudentId == attdItem.StudentId)
                    {
                        Students usr = new Students();
                        usr.StudentId = stdItem.StudentId;
                        usr.Name = stdItem.Name;
                        usr.Email = stdItem.Email;
                        usr.Phone = stdItem.Phone;
                        usr.TechnicalInterest = stdItem.TechnicalInterest;
                        usr.SocialNetworkInterest = stdItem.SocialNetworkInterest;
                        usr.AcceptRegret = attdItem.AcceptRegret;
                        studentList.Add(usr);
                    }

            }

            return studentList;
        }

        public List<Students> GetAllGoing()
        {
            List<Attend> attendList = new List<Attend>();
            StudentCompetitionEntities tstDb = new StudentCompetitionEntities();
            var lstAttd = from k in tstDb.Attends select k;

            List<Students> studentListGoing = new List<Students>();
            var lstStd = from k in tstDb.Students select k;
            foreach (var stdItem in lstStd)
            {
                foreach (var attdItem in lstAttd)
                    if (stdItem.StudentId == attdItem.StudentId && attdItem.AcceptRegret == "Accepted")
                    {
                        Students usr = new Students();
                        usr.StudentId = stdItem.StudentId;
                        usr.Name = stdItem.Name;
                        usr.Email = stdItem.Email;
                        usr.Phone = stdItem.Phone;
                        usr.TechnicalInterest = stdItem.TechnicalInterest;
                        usr.SocialNetworkInterest = stdItem.SocialNetworkInterest;
                        usr.AcceptRegret = attdItem.AcceptRegret;
                        studentListGoing.Add(usr);
                    }

            }

            return studentListGoing;
        }

        public Students GetGoingById(int id)
        {

            StudentCompetitionEntities tstDb = new StudentCompetitionEntities();
            Students usr = new Students();

            List<Attend> attendList = new List<Attend>();
            var lstAttd = from k in tstDb.Attends where k.StudentId == id select k;
            

            List<Students> studentListGoing = new List<Students>();
            var lstStd = from k in tstDb.Students where k.StudentId == id select k;

            foreach (var stdItem in lstStd)
            {
                foreach (var attdItem in lstAttd)
                    if (stdItem.StudentId == attdItem.StudentId)
                    {
                        usr.StudentId = stdItem.StudentId;
                        usr.Name = stdItem.Name;
                        usr.Email = stdItem.Email;
                        usr.Phone = stdItem.Phone;
                        usr.TechnicalInterest = stdItem.TechnicalInterest;
                        usr.SocialNetworkInterest = stdItem.SocialNetworkInterest;
                        usr.AcceptRegret = attdItem.AcceptRegret;
                        
                    }

            }
            

            return usr;
        }

        public int AddStudent(int StudentId, string Name, string Email, string Phone, string TechnicalInterest, string SocialNet, string accRegret)
        {
            Student student = new Student();
            student.StudentId = StudentId;
            student.Name = Name;
            student.Email = Email;
            student.Phone = Phone;
            student.TechnicalInterest = TechnicalInterest;
            student.SocialNetworkInterest = SocialNet;
            

            Attend attendance = new Attend();
            attendance.StudentId = StudentId;
            attendance.AcceptRegret = accRegret;


            StudentCompetitionEntities tstDb = new StudentCompetitionEntities();
            tstDb.Students.Add(student);
            tstDb.Attends.Add(attendance);
            int Retval = tstDb.SaveChanges();
            return Retval;
        }

    }
}
