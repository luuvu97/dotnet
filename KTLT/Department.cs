using System.Collections.Generic;
using System;

namespace KTLT
{
    public class Department
    {
        private string name;
        private List<Employee> listEmployee;
        private List<Employee> listLeader;
        private List<Employee> listAssitiant;
        private int numOfEmployee;
        
        public Department(String name)
        {
            this.listEmployee = new List<Employee>();
            this.listLeader = new List<Employee>();
            this.listAssitiant = new List<Employee>();
            this.name = name;
            this.numOfEmployee = 0;
        }

        public bool addEmployee(Employee e)
        {
            if(e.GetPosition() == Position.NHANVIEN){
                this.listEmployee.Add(e);
                this.updateNumOfEmployee();
                return true;
            }else if(e.GetPosition() == Position.CHUTICH || e.GetPosition() == Position.TRUONGPHONG || e.GetPosition() == Position.TONGGIAMDOC){
                this.listLeader.Add(e);
                this.updateNumOfEmployee();
                return true;
            }else if(e.GetPosition() == Position.PHOPHONG || e.GetPosition() == Position.PHOGIAMDOC){
                this.listAssitiant.Add(e);
                this.updateNumOfEmployee();
                return true;
            }
            return false;
        }

        public void displayBriefInformation()
        {
            Console.WriteLine($"{this.name} have {this.listLeader.Count + this.listAssitiant.Count + this.listEmployee.Count}");
            foreach(Employee e in this.listLeader){
                e.displayBriefInformation();
            }
            foreach(Employee e in this.listAssitiant){
                e.displayBriefInformation();
            }
        }

        public void displayAllInformation()
        {
            Console.WriteLine($"{this.name} have {this.listLeader.Count + this.listAssitiant.Count + this.listEmployee.Count}");
            foreach(Employee e in this.listLeader){
                e.displayBriefInformation();
            }
            Console.WriteLine();
            foreach(Employee e in this.listAssitiant){
                e.displayBriefInformation();
            }
            Console.WriteLine();
            foreach(Employee e in this.listEmployee){
                e.displayBriefInformation();
            }
        }

        public String getName()
        {
            return this.name;
        }

        public void updateNumOfEmployee()
        {
            this.numOfEmployee = this.listLeader.Count + this.listAssitiant.Count + this.listEmployee.Count;
        }

        public int getNumOfEmployee()
        {
            return this.numOfEmployee;
        }
    }
}