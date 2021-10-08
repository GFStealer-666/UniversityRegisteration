using System;
using System.Collections.Generic;
using System.Collections;

namespace UniversityRegisteration
{
    enum Mainmenu
    {
        Login = 1,
        Register,
        ForgetPassword
    }

    enum TeacherMainmenu
    {
        Create = 1 ,
        ShowStudent,
        LogOut
    }

    class Program
    {
        static PersonList personList;
        static SubjectList subjectList;
        static StudentList studentlist;
        

        static void Main(string[] args)
        {

            Program.personList = new PersonList();
            Program.subjectList = new SubjectList();
            Program.studentlist = new StudentList();

            SetBasicValue();
            
            PrintMainMenu();
        }
        static void SetBasicValue()
        {
            Student Naroj = new Student("Naroj Taweewongworaphanit", "SleepingDart", "63120501005");
            Student Untika = new Student("Untika Umnunkasoradej", "AmieAem", "63120501037");
            Student Pop = new Student("Weerapat Humlek ", "Pound03", "6320501420");

            Program.studentlist.AddNewStudent(Naroj);
            Program.studentlist.AddNewStudent(Untika);
            Program.studentlist.AddNewStudent(Pop);
            Program.personList.AddNewPerson(Naroj);
            Program.personList.AddNewPerson(Untika);
            Program.personList.AddNewPerson(Pop);

            Subject subject = new Subject("History", 20, 3);
            Subject subject1 = new Subject("Calculus", 40, 1.5);
            Subject subject2 = new Subject("Architecture", 60, 2);
            Subject subject3 = new Subject("Programming", 1, 10);
            Subject subject4 = new Subject("English", 20, 1.5);
            Subject subject5 = new Subject("Dota2", 20, 20);

            Program.subjectList.AddSubject(subject);
            Program.subjectList.AddSubject(subject1);
            Program.subjectList.AddSubject(subject2);
            Program.subjectList.AddSubject(subject3);
            Program.subjectList.AddSubject(subject4);
            Program.subjectList.AddSubject(subject5);

        }

        static void PrintMainMenu()
        {
            PrintHeader(1);
            PrintMenuList();
            InputMenuFromKeyboard();
        }

        static void PrintMenuList()
        {
            Console.WriteLine("1. Login ");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Forget Password");
        }

        static void InputMenuFromKeyboard()
        {
            Console.Write("Select Menu : ");
            Mainmenu menu = (Mainmenu)(int.Parse(Console.ReadLine()));

            PresentMenu(menu);
        }

        static void PresentMenu(Mainmenu menu)
        {
            if (menu == Mainmenu.Login)
            {
                LoginMenu();
            }
            else if (menu == Mainmenu.Register)
            {
                RegisterMenu();
            }
            else if(menu == Mainmenu.ForgetPassword)
            {
                PrintHeader(7);

                string name;                             
                ForgetPassword(name = InputName());
            }
            else
                InputMainMenuError();

        }

        static void LoginMenu()
        {
            PrintHeader(3);
            DisplayLogin();
        }

        static void DisplayLogin()
        {
            string name = InputName();
            string password = InputPassword();

            LoginStuff(name, password);
        }

        static void LoginStuff(string name, string password)
        {           

            Person Test = new Person("0", "0");

            int counter = 0;

            foreach (Person person in Program.personList.GetPersonList())
            {
                if (name == person.username)
                {
                    Test = person;
                    break;
                } 
                
                counter++;
            }

            if (Test.username == "0")
            {
                Console.WriteLine("Invalid User name Input, please try again");

                Console.WriteLine("");

                PrintMainMenu();
            }

            if (password == Test.GetPassword())
            {
                Console.WriteLine("User exist on Database ");

            }
            else
            {
                Console.WriteLine("Invaild Password Input , please try again");

                Console.WriteLine("");

                PrintMainMenu();
            }
            
            if (Test is Student)
            {
                List<Person> numberList = personList.GetPersonList();
                Student TStudent = numberList[counter] as Student;

                PrintHeader(4);
                PrintName(name);
                PrintStudentID(TStudent.studentID); 
                
                PrintHeader(6);
                
                Console.WriteLine("Credit left : {0} ", TStudent.credit);
                PrintSubjectList(TStudent);
            }

            if (Test is Teacher)
            {
                List<Person> numberList = personList.GetPersonList();
                Teacher TTeacher = numberList[counter] as Teacher; 

                PrintHeader(5);
                PrintName(name);
                PrintTeacherID(TTeacher.teacherID);

                PrintTeacherMainmenu();
               
            }
        }

        static void PrintTeacherMainmenu()
        {
            PrintHeader(8);

            Console.Write("Select Menu : ");
            TeacherMainmenu teachermenu = (TeacherMainmenu)(int.Parse(Console.ReadLine())); 

            PresentTeacherMainmenu(teachermenu);
        }
        
        static void PresentTeacherMainmenu(TeacherMainmenu menu)
        {
            if (menu == TeacherMainmenu.Create)
            {                              
                CreateSubject();
            }
            else if (menu == TeacherMainmenu.ShowStudent)
            {
                ShowStudentList();
            }
            else if(menu == TeacherMainmenu.LogOut)
            {
                Logout();
            }
            else
                InputTeacherMainMenuError();

        }

        static void CreateSubject()
        {
            PrintHeader(9);
            
            Console.Write("How many subject you want to create : ");

            int subject = int.Parse(Console.ReadLine());

            CreatingSubject(subject);
        }

        static void CreatingSubject(int left)
        {
            for(int x = 0; x < left; x++)
            {
                Console.Write("Input subject name : ");

                string name = Console.ReadLine();

                Console.Write("Input Maximum student : ");

                int student = int.Parse(Console.ReadLine());

                Console.Write("Input Subject total credit : ");

                int credit = int.Parse(Console.ReadLine());
                
                Subject subject = CreateNewSubject(name, student , credit);
                Program.subjectList.AddSubject(subject);

                Console.WriteLine("----------------------"); 
            }
            
            PrintTeacherMainmenu();
        }

        static void Logout()
        {
            PrintMainMenu();
        }

        static void PrintSubjectList(Student student)
        {
            Program.subjectList.PrintSubjectList();

            StudentRegisteration(student); 

        }

        static void ShowStudentList()
        {
            Program.studentlist.PrintStudentList();

            PrintTeacherMainmenu();
        }
        
        static void StudentRegisteration(Student Tstudent)
        {
            string test = "I'm too sleepy this is so hard ";

            string command = "BLA BLA";

            double credit = Tstudent.credit;
          
            while (credit != 0 || command != "end")
            {
                Console.Write("What subject you want to register? : "); 

                test = Console.ReadLine();

                Subject TSubject = new Subject("0", 0, 0);              

                foreach (Subject subject in Tstudent.GetSubjectList()) 
                {
                    if (test == subject.subjectname)
                    {
                        Console.WriteLine("Already Register this subject please try again");

                        continue;
                    }                    

                }

                foreach (Subject subject in Program.subjectList.GetSubjectList())
                {
                    if (test == subject.subjectname)
                    {
                        TSubject = subject;
                        break;
                    }
                }
                
                if(TSubject.subjectname == "0")
                {
                    Console.WriteLine("Invaild Subject name input please try again ");
                    
                    Console.WriteLine(" ");

                }
                else
                {
                    
                    
                    
                    if(credit < TSubject.credit)
                    {
                        Console.WriteLine("Credit is not enough , please select another subject"); 
                    }
                    else
                    {
                        credit = credit - TSubject.credit; 

                        Tstudent.AddSubject(TSubject);

                        Console.WriteLine("Current credit left : {0}", credit);

                        TSubject.left--;

                        if (TSubject.left == 0)
                        {
                            subjectList.RemoveSubject(TSubject);
                        }

                        Console.WriteLine("Subject Registeration complete ");

                        Console.WriteLine("If you wish to continue press any key to continue");

                        Console.WriteLine("Otherwise type end to stop registeration ");

                        command = Console.ReadLine();

                        command = command.ToLower();


                    }                      
                }
                
                if(credit <= 0 || command == "end")
                {
                    break;
                    
                }           
            }

            Console.WriteLine("Thanks for registerating");

            Console.WriteLine("-------------------------");

            PrintMainMenu();

        }
        
        static void PrintName(string name)
        {
            Console.WriteLine("Name : {0}", name);
        }

        static void PrintStudentID(string input) 
        {
            Console.WriteLine("Student ID : {0}", input);
        }

        static void PrintTeacherID(string teacherid)
        {
            Console.WriteLine("Teacher ID : {0}", teacherid); 
        }

        static void RegisterMenu()
        {
            PrintHeader(2);
            RegisterFromKeyboard();
        }

        static void RegisterFromKeyboard()
        {
            string name = InputName();            

            Person TestUsername = new Person("0", "0");

            foreach (Person person in Program.personList.GetPersonList())
            {
                if (name == person.username)
                {
                    TestUsername = person;
                    break;
                }
            }

            if (TestUsername.username == name)
            {
                Console.WriteLine(" ");
                
                Console.WriteLine("This user name already exist please use another one ");

                PrintMainMenu();
            }
            else
            {
                string password = InputPassword();
                int menutype = InputUserType();

                CheckWhatType(name, password, menutype);
            }          
        }
        
        static void PrintHeader(int menu)
        {
            if (menu == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("Welcome to the KMUTT subject Registeration!");
                Console.WriteLine("If your're here for the 1st time , Please Register new account first!");
                Console.WriteLine("-------------------------------");
            }

            if (menu == 2)
            {
                Console.WriteLine("");
                Console.WriteLine("Register new Person");
                Console.WriteLine("--------------------");
            }

            if (menu == 3)
            {
                Console.WriteLine("");
                Console.WriteLine("Login Screen");
                Console.WriteLine("-----------------");
            }

            if (menu == 4)
            {
                Console.WriteLine(""); 
                Console.WriteLine("Student Information");
                Console.WriteLine("-------------------");
            }

            if (menu == 5)
            {
                Console.WriteLine("");
                Console.WriteLine("Teacher Information");
                Console.WriteLine("--------------------");
            }

            if (menu == 6)
            {
                Console.WriteLine(""); 
                Console.WriteLine("Registeration your subject");
                Console.WriteLine("---------------------------");
            }

            if(menu == 7)
            {
                Console.WriteLine("");
                Console.WriteLine("Forget Password");
                Console.WriteLine("----------------");
            }
            
            if(menu == 8)
            {
                Console.WriteLine("");
                Console.WriteLine("Teacher management");
                Console.WriteLine("------------------");
                Console.WriteLine("1.Register new subject");
                Console.WriteLine("2.Show Student list");
                Console.WriteLine("3.Logout");

            }

            if(menu == 9)
            {
                Console.WriteLine("");
                Console.WriteLine("Create new Subject");
                Console.WriteLine("------------------");
            }

        }
        
        static string InputName()
        {
            Console.Write("Input Username : ");

            string name = Console.ReadLine();

            return name;
        }

        static string InputPassword()
        {
            Console.Write("Input password : ");

            string password = Console.ReadLine();

            return password;
        }


        static int InputUserType()
        {
            Console.Write("Input User Type 1 = Student, 2 = Teacher : ");

            int usertype = int.Parse(Console.ReadLine());

            return usertype;
        }
       
        static string StudentID()
        {
            Console.Write("Student ID : ");

            string studentid = Console.ReadLine();

            foreach (Student student in Program.personList.GetPersonList())
            {
                if (studentid == student.studentID)
                {
                    Console.WriteLine("This Stuent ID already exist please input a new one");

                    PrintMainMenu();
                }
            }

            return studentid;
        }

        static string TeacherID()
        {
            Console.Write("Teacher ID : ");

            string teacherid = Console.ReadLine();

            Person TestTeacherID = new Person("0", "0");

            foreach (Teacher teacher in Program.personList.GetPersonList())
            {
                if (teacherid == teacher.teacherID)
                {
                    Console.WriteLine("This Teacher ID already exist please input a new one");

                    PrintMainMenu();
                }
            }

           

            return teacherid;
        }

        static void InputMainMenuError()
        {
            Console.WriteLine("Invaild menu input , Please try again ");

            PrintMainMenu();
        }

        static void InputTeacherMainMenuError()
        {
            Console.WriteLine("Invaild menu input , Please try again ");

            PrintTeacherMainmenu();
        }

        static void ForgetPassword(string name)
        {          
            Person Test1 = new Person("0", "0");

            int counter = 0;

            foreach (Person person in Program.personList.GetPersonList())
            {
                if (name == person.username)
                {
                    Test1 = person;
                    break;
                }


                counter++;
            }

            if (Test1.username == "0")
            {
                Console.WriteLine("This username doesn't exist in database , please try again ");

                PrintMainMenu();
            }
            else
            {
                string password = Test1.GetPassword();
                
                Console.WriteLine("Your password : {0}" , password);

                PrintMainMenu();
            }

        }

        static void CheckWhatType(string name, string password, int usertype)
        {
            if (usertype == 1)
            {
                Student student = CreateNewStudent(name, password);
                Program.personList.AddNewPerson(student);
                Program.studentlist.AddNewStudent(student);
                
                

                PrintMainMenu();
            }
            else if (usertype == 2)
            {
                Teacher teacher = CreateNewTeacher(name, password);
                Program.personList.AddNewPerson(teacher);

                PrintMainMenu();

            }
            else
                Console.WriteLine("Incorrect type input please try again");

                PrintMainMenu();
        }

        static Student CreateNewStudent(string name, string password)
        {
            return new Student(name, password, StudentID());
        }

        static Teacher CreateNewTeacher(string name, string password)
        {
            return new Teacher(name, password, TeacherID());
        }

        static Subject CreateNewSubject(string name , int left , int credit)
        {
            return new Subject(name, left , credit);
        }
    }
    
    }
    class Person
    {
        public string username;

        protected string password;

        public Person(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string GetName()
        {
            return this.username;
        }

        public string GetPassword()
        {
            return this.password;
        }

        
    }

    class SubjectList
    {
        protected List<Subject> subjectlist;

        public SubjectList()
        {
            this.subjectlist = new List<Subject>();
        }

        public void AddSubject(Subject subject)
        {
            this.subjectlist.Add(subject);
        }

        public void PrintSubjectList()
        {
            Console.WriteLine("Subject List");
            Console.WriteLine("-------------");
            foreach (Subject subject in this.subjectlist)
            {
                Console.WriteLine("Subject name : {0}" , subject.subjectname);
                Console.WriteLine("Subject place available : {0}" , subject.left);
                Console.WriteLine("Subject total credit : {0} ",subject.credit);

                Console.WriteLine("---------------");
            }
        }

        public List<Subject> GetSubjectList()
        {
            return this.subjectlist;
        }

        public void RemoveSubject(Subject subject)
        {
        this.subjectlist.Remove(subject);
        }

}


    class PersonList
    {
        protected List<Person> personlist;

        public PersonList()
        {
            this.personlist = new List<Person>();
        }

        public void AddNewPerson(Person person)
        {
            this.personlist.Add(person);
        }

        public List<Person> GetPersonList()
        {
            return this.personlist;
        }

        
       
    }
        
    class StudentList
    {
        protected List<Student> studentlist;

        public StudentList()
        {
            this.studentlist = new List<Student>();
        }

        public void PrintStudentList()
        {
            Console.WriteLine("Student List");
            Console.WriteLine("-------------");
            foreach (Student student in this.studentlist)
            {
               Console.WriteLine("Student name : {0} , Student ID : {1}", student.GetName(), student.GetStudentID());
            }   
        }

        public void AddNewStudent(Student student)
        {
            this.studentlist.Add(student); 
        }

        public List<Student> GetStudentList()
        {
            return this.studentlist;
        }
    }

    class Student : Person
    {
        protected List<Subject> registersubjectlist = new List<Subject>();
    
        public void BasicAdding()
        {
            Subject Test = new Subject("Basic University", 0, 0); 
            AddSubject(Test); 
        }
        

        public string studentID;

        public double credit = 20; 

        public Student(string username, string password, string studentID) : base(username, password)
        {
            this.studentID = studentID;

        }
    
        public string GetStudentID()
        {
            return this.studentID; 
        }

        public void AddSubject(Subject subject)
        {
            this.registersubjectlist.Add(subject);
        }

        public List<Subject> GetSubjectList()
        {
            return this.registersubjectlist; 
        }

}

    class Teacher : Person
    {
        public string teacherID;

        public Teacher(string username, string password, string employeeID) : base(username, password)
        {
            this.teacherID = employeeID;
        }

        public string GetEmployeeID()
        {
            return this.teacherID;
        }
    }

    class Subject
    {
        public int left = 0;

        public string subjectname;

        public double credit;

        public Subject(string subjectname , int left , double credit)
        {
            this.subjectname = subjectname;

            this.left = left;

            this.credit = credit;
        }
    }


