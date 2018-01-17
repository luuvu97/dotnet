using System;
using System.Collections.Generic;
using System.IO;

namespace KTLT
{
    public class Employee
    {
        private static List<Employee> listEmployee;
        public static string fileURL = "employee.txt";
        private int ID;
        private string lastName;
        private string firstName;
        private string department;
        private Position position;
        private DateTime birthday;
        private string nativeLand;
        private string address;
        private string email;
        private string tel;
        private DateTime startWorkOn;
        private List<TimeOfWork> workTime = new List<TimeOfWork>();

        public static void setListEmployee(List<Employee> list)
        {
            Employee.listEmployee = list;
        }
        public static void read()
        {
            StreamReader file = new StreamReader(fileURL);
            String[] arr = File.ReadAllLines(fileURL);
            int i = 0;
            while (i < arr.Length)
            {
                Employee e = new Employee();
                e.ID = e.parseID(arr[i++]);
                e.lastName = arr[i++].ToUpper();
                e.firstName = arr[i++].ToUpper();
                e.department = arr[i++].ToUpper();
                e.position = e.parsePosition(arr[i++].ToUpper());
                e.birthday = TimeOfWork.parseDateString(arr[i++].ToUpper());
                e.nativeLand = arr[i++].ToUpper();
                e.address = arr[i++].ToUpper();
                e.email = arr[i++].ToUpper();
                e.tel = arr[i++].ToUpper();
                e.startWorkOn = TimeOfWork.parseDateString(arr[i++].ToUpper());

                //Insert work time list
                TimeOfWork tow = new TimeOfWork();
                while(arr[i].StartsWith("NV") == false)
                {
                    tow = new TimeOfWork();
                    tow.setData(arr[i++].ToUpper());
                    e.workTime.Add(tow);
                    if(i == arr.Length)
                        break;
                }
                Employee.listEmployee.Add(e);
            }            
            Console.WriteLine("End");

        }
        
        private int parseID(String str)
        {
            return Int32.Parse(str.Substring(2));
        }

        private Position parsePosition(String str)
        {
            switch(str){
                case "CHU TICH": return Position.CHUTICH;
                case "TONG GIAM DOC": return Position.TONGGIAMDOC;
                case "PHO GIAM DOC": return Position.PHOGIAMDOC;
                case "TRUONG PHONG": return Position.TRUONGPHONG;
                case "PHO PHONG": return Position.PHOPHONG;
                default: return Position.NHANVIEN;
            }
        }

        private string displayPosition()
        {
            switch(this.position){
                case Position.CHUTICH: return "CHỦ TỊCH";
                case Position.TONGGIAMDOC: return "TỔNG GIÁM ĐỐC";;
                case Position.PHOGIAMDOC: return "PHÓ GIÁM ĐỐC";
                case Position.TRUONGPHONG: return "TRƯỞNG PHÒNG";
                case Position.PHOPHONG: return "PHÓ PHÒNG";
                default: return "NHÂN VIÊN";
            }
        }

        public void displayAllInformation()
        {
            Console.WriteLine($"NV{this.ID}");
            Console.WriteLine($"{this.lastName} {this.firstName}");
            Console.WriteLine($"{this.department}");
            Console.WriteLine($"{this.displayPosition()}");
            Console.WriteLine($"{this.birthday.ToString()}");
            Console.WriteLine($"{this.nativeLand}");
            Console.WriteLine($"{this.address}");
            Console.WriteLine($"{this.email}");
            Console.WriteLine($"{this.tel}");
            Console.WriteLine($"{this.startWorkOn.ToString()}");
            foreach(TimeOfWork t in this.workTime)
            {
                t.display();
                Console.WriteLine();
            }
        }

        public void displayBriefInformation()
        {
            Console.WriteLine($"NV{this.ID}\t{this.lastName} {this.firstName}");
        }

        public Position GetPosition()
        {
            return this.position;
        }

        public String getDepartment()
        {
            return this.department;
        }
    }
}