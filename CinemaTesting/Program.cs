using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaDataBaseLibrary.Engine;



namespace CinemaTesting
{
    class Program
    {
        public interface IWriteMessage
        {
            void WriteMessage();
        }

        class ClassA
        {
            public virtual void WriteMessage()
            {
                Console.WriteLine("ClassA - WriteMessage");
            }
        }

        class ClassB : ClassA, IWriteMessage
        {
            public void WriteMessage()
            {
                Console.WriteLine("ClassB - WriteMessage");
            }
            
            void IWriteMessage.WriteMessage()
            {
                Console.WriteLine("ClassB - IWriteMess");
            }
        }




        static void Main(string[] args)
        {
            IWriteMessage ob1 = new ClassB();
            ob1.WriteMessage();
            ClassB ob2 = new ClassB();
            ob2.WriteMessage();
            ClassA ob3 = new ClassB();
            ob3.WriteMessage();

            object a = "1";
            object b = 1;
            Console.WriteLine(a==b);

            //DbEngine db = new DbEngine();
            //db.myExeption += Db_myExeption;
            //db.ShowMessage += Db_ShowMessage;

            //var res = from s in db.Data.Sessions
            //          join f in db.Data.Films on s.SessionFilm equals f
            //          join r in db.Data.Rooms on s.SessionRoom equals r
            //          select new { SN = s.SessionId, SF = f.FilmName, SR = r.RoomName };

            //foreach (var p in res)
            //{
            //    Console.WriteLine($"{p.SN} {p.SF} {p.SR}");
            //}

            //var phones = from p in db.Phones
            //             join c in db.Companies on p.CompanyId equals c.Id
            //             select new { Name = p.Name, Company = c.Name, Price = p.Price };

            

            Console.ReadKey();
                
        }

        private static void Db_ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        private static void Db_myExeption(string message)
        {
            Console.WriteLine(message);
        }
    }
}
