using System;
using System.Collections.Generic;

namespace KTLT
{
    class Program
    {
        private List<Employee> listEmployee;
        private List<Department> listDepartment;
        
        public Program()
        {
            this.listEmployee = new List<Employee>();
            this.listDepartment = new List<Department>();
            this.init();
        }

        public void init()
        {
            Employee.setListEmployee(this.getListEmployee());
            Employee.read();
            foreach(Employee e in this.listEmployee){
                Department d = this.findDepartment(e.getDepartment());
                if(d == null){
                    d = new Department(e.getDepartment());
                    this.listDepartment.Add(d);
                    d.addEmployee(e);
                }else{
                    d.addEmployee(e);
                }
            }
        }

        public Department findDepartment(String name)
        {
            foreach(Department d in this.listDepartment){
                if(d.getName().Equals(name) == true){
                    return d;
                }
            }
            return null;
        }

        public List<Employee> getListEmployee()
        {
            return this.listEmployee;
        }

        static void Main(string[] args)
        {
            Program main = new Program();
            main.control();
        }

        public void displayListDepartment()
        {
            for(int i = 0; i < this.listDepartment.Count; i++){
                Console.Write($"\n{i + 1}\t");
                Console.Write($"{this.listDepartment[i].getName()}");
                Console.WriteLine();
            }
        }

        public void displayListDepartmentAndBriefInfo()
        {
            for(int i = 0; i < this.listDepartment.Count; i++){
                Console.Write($"{i}\t");
                this.listDepartment[i].displayBriefInformation();
                Console.WriteLine();
            }
        }

        public void control()
        {
            while(true){
                Console.WriteLine("1: Introduct about company");
                Console.WriteLine("2: Information about one department");
                Console.WriteLine("3: Find employee");
                Console.WriteLine("0: Exit");
                Console.WriteLine("Input one key");
                char ch = Console.ReadKey().KeyChar;
                switch(ch){
                    case '1':
                        int numOfEmployee = 0;
                        foreach(Department d in this.listDepartment){
                            numOfEmployee += d.getNumOfEmployee();
                        }
                        Console.WriteLine($"Tổng số nhân viên: {numOfEmployee}");
                        this.displayListDepartmentAndBriefInfo();
                        break;
                    case '2':
                        int index = 0;
                        this.displayListDepartment();
                        while(true){
                            Console.WriteLine("\nInput the number aspect with department");
                            String str = Console.ReadLine();
                            index = Int32.Parse(str);
                            if(index >= 1 && index <= this.listDepartment.Count){
                                this.listDepartment[index - 1].displayAllInformation();
                                break;
                            }else{
                                Console.WriteLine("Please try again!");
                            }
                        }
                        break;
                    case '0':
                        return;
                }
            }
        }
    }
}
