using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management
{
    public class LibraryBooks
    {
        public int bksBorrowed;
        public object[,] book = new object[5, 2];
        public object[,] bookIssue = new object[3, 2];

        public virtual void catalouge()
        {
            System.Console.WriteLine("Admin's Catalouge Management");
        }
        public LibraryBooks()
        {
            char va = 'a';
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    book[i, j] = va;
                    va++;
                }
                for (int j = 1; j < 2; j++)
                {
                    book[i, j] = 5;
                }
            }
        }
    }
    public interface Lib
    {
        bool searchB(string s);
        void borrow(String bor, DateTime t);
        void returnBook(string s);
        void Details();
    }
    class Faculty:LibraryBooks,Lib
    {
        public Faculty() : base()
        {
            bksBorrowed = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    bookIssue[i, j] = 0;
                }
            }
        }
        public bool searchB(string s)
        {
            bool a=true;
            for(int i=0;i<5;i++)
            {
                for(int j=0;j<1;j++)
                {
                    Console.WriteLine("The Book was :"+book[i,j].ToString());
                    String ff=book[i,j].ToString();
                    Console.WriteLine(ff.Equals(s));
                    if(ff.Equals(s))
                    {
                        a=true;
                        return a;
                    }
                    else
                    {
                        a=false;
                    }
                }
                
            }
            return a;
        }
            public void borrow(String bor, DateTime t)
            {
                if(bor.Equals("b"))
                {
                    Console.WriteLine("You Can't borrow this journal , It is only for reference !");
                    return;
                }
                Console.WriteLine("You issued "+this.bksBorrowed+" books");
                if(this.bksBorrowed<5)
                {
                    bookIssue[this.bksBorrowed,0]=bor;
                    bookIssue[this.bksBorrowed,1]=t;
                   this.bksBorrowed++;
                }
                else
                {
                    Console.WriteLine("Sorry! you are not eligible !!!!");
                }
            }
        public void returnBook(string s)
        {
            for(int i=0;i<5;i++)
            {
                for(int j=0;j<1;j++)
                {
                    if(book[i,j].Equals(s))
                    {
                        book[i,j+1]=(int)book[i,j+1]+1;
                    }
                }
            }
            for(int i=0;i<this.bksBorrowed;i++)
            {
                for(int j=0;j<1;j++)
                {
                    if(this.bookIssue[i,j].Equals(s))
                    {
                        TimeSpan f;

                        f=DateTime.Today-(DateTime)this.bookIssue[i,j+1];
                        Console.WriteLine("The TimeSpan is "+f);
                        if(f.TotalDays>365)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Your Penalty is "+f.TotalDays*2);
                            Console.WriteLine("");
                        }
                    }
                }
            }
            bksBorrowed--;
        }
        public void Details()
        {
            Console.WriteLine("Name "+"    "+"Issued Date");
            for(int i=1;i<this.bksBorrowed;i++)
            {
                for(int j=0;j<2;j++)
                {
                    Console.Write(this.bookIssue[i,j]+"  "+"  ");
                }
                Console.WriteLine();
            }
        }
        public void renew(string k)
        {
            DateTime u;
            for(int i=0;i<this.bksBorrowed;i++)
            {
                for(int j=0;j<1;j++)
                {
                    if(bookIssue[i,j].Equals(k))
                    {
                        bookIssue[i,j+1]=DateTime.Today;
                    }
                }
            }
            Console.WriteLine("Book has been Renewed!!!");
        }
    }
   public  sealed class Admin:LibraryBooks
    {
        public int FacNo;
        public int StuNo;
        public Admin()
        {
            FacNo=0;
            StuNo=0;
        }
        String[,] fname=new String[5,2];
        public void createFaculty(String name,String pwd)
        {
            for(int i=0;i<=this.FacNo;i++)
            {
                for(int j=0;j<1;j++)
                {
                    this.fname[i,j]=name;
                }
                for(int j=1;j<2;j++)
                {
                    this.fname[i,j]=pwd;
                }
            }
        }
        String[,] sname = new String[5, 2];
        public void createStudent(String name,String pawd)
        {
            for(int i=0;i<=this.StuNo;i++)
            {
                for(int j=0;j<1;j++)
                {
                    this.sname[i,j]=name;
                }
                for(int j=1;j<2;j++)
                {
                    this.sname[i,j]=pawd;
                }
            }
        }
        public int facchk(String n,String p)
        {
            Console.WriteLine("Faculty no. is "+this.FacNo);
            int dla=0;
            if(this.FacNo==0)
            {
                return 2;
            }
            else
            {
                for(int i=0;i<this.FacNo;i++)
                {
                    for(int j=0;j<1;j++)
                    {
                        string ko=this.fname[i,j];
                        Console.WriteLine("Name Recieved "+ko);
                        if(ko.Equals(n))
                        {
                            dla=1;
                            if(this.fname[i,j+1].Equals(p))
                            {
                                return 1;
                            }
                        }
                    }
                }
            }
            if(dla==0)
                return 2;
            else
                return 0;
          
        }
        public int  Stuchk(String n, String p)
        {
            int dla = 0;
            if (this.StuNo == 0)
            {
                return 2;
            }
            else {
                for (int i=0; i<StuNo; i++)
                {
                    for (int j=0; j<1; j++)
                    {
                        if (this.sname[i,j+1].Equals(n))
                        {
                            dla=1;
                            if (this.sname[i,j+1].Equals(n))
                            {
                                return 1;
                            }
                        }
                    }
                }
            }
            if (dla == 0)
                return 2;
            else
                return 0;
        }

        public void viewFac()
        {
            Console.WriteLine("Name " + "    " + "Password");
            for (int i=0; i<this.FacNo; i++)
            {
                for (int j=0; j<2; j++)
                {
                    Console.Write(this.fname[i, j] + "         ");
                }
                Console.WriteLine(" ");
            }
        }
        public void viewStu()
        {
            Console.WriteLine("Name " + "    " + "Password");
            for (int i = 0; i < this.StuNo; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(this.sname[i, j] + "         ");
                }
                Console.WriteLine(" ");
            }
        }
        public void catalogue()
        {
            String ans ="yes";
            do
            {
                Console.WriteLine("");
                Console.WriteLine("|------------------------|");
                Console.WriteLine("| 1.view Books           |");
                Console.WriteLine("| 2.Add Books            |");
                Console.WriteLine("| 3.Delete Books         |");
                Console.WriteLine("| 4.Return to main menu  |");
                Console.WriteLine("|------------------------|");
                Console.WriteLine("");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Console.WriteLine("Book name " + "  " + "Available copies");
                        for (int i=0; i<5; i++)
                        {
                            for (int j=0; j<2; j++)
                            {
                                Console.Write(this.book[i,j] +"              ");
                            }
                            Console.WriteLine("");
                        }

                        break;

                    case 2:
                        Console.WriteLine("Enter the name of the books");
                        String sn = Console.ReadLine();
                        Console.WriteLine("Enter the no. of copies you want to add?");
                        int ner=int.Parse(Console.ReadLine());
                        for (int i=0; i<5; i++)
                        {
                            for (int j=0; j<1; j++)
                            {
                                String sd = book[i,j].ToString();
                                if (sd.Equals(sn))
                                {
                                   Console.WriteLine("Found you !!!!!");
                                    book[i,j+1]=(int)book[i,j+1]+ner;
                                    break;
                                }
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter the name of the books");
                        String sn1=Console.ReadLine();
                        Console.WriteLine("Enter the no. of copies you want to remove?");
                        int n2 = int.Parse(Console.ReadLine());
                        for (int i=0; i<5; i++)
                        {
                            for (int j=0; j<1; j++)
                            {
                                Console.WriteLine("The book is " + book[i,j]);
                                String sd = book[i,j].ToString();
                                if (sd.Equals(sn1))
                                {
                                    Console.WriteLine("Found !!!!!!!! This book is available.");
                                    book[i,j+1]=(int)book[i,j+1]-n;
                                    break;
                                }
                            }
                        }
                        break;
                    case 4:
                        return;
                }
            }while(ans.Equals("yes"));
        }
    }
    class Student:LibraryBooks,Lib
    {
        public Student():base()
        {
            bksBorrowed=1;
            for(int i=0;i<3;i++)
            {
                for(int j=0;j<2;j++)
                {
                    bookIssue[i,j]=0;
                }
            }
        }
        public bool searchB(string s)
        {
            bool a=true;
            for(int i=0;i<5;i++)
            {
                for(int j=0;j<1;j++)
                {
                   Console.WriteLine("The Book Was : "+book[i,j].ToString());
                    String ff=book[i,j].ToString();
                    Console.WriteLine(ff.Equals(s));
                    if(ff.Equals(s))
                    {
                        a=true;
                        return a;
                    }
                    else
                        a=false;
                }
            }
            return a;
        }
        public void borrow(String bor,DateTime t)
        {
            if(bor.Equals("b"))
            {
                Console.WriteLine("Sorry !!! The book is  only for Reference");
                return;
            }
            Console.WriteLine("You issued " + this.bksBorrowed + " books");
            if(this.bksBorrowed<2)
            {
                bookIssue[this.bksBorrowed,0]=bor;
                bookIssue[this.bksBorrowed,1]=t;
                this.bksBorrowed++;
            }
            else
            {
                Console.WriteLine("Sorry !!! You Can't borrow anymore books!!!!");
                Console.WriteLine("");
            }
        }
        public void returnBook(string s)
        {
            for(int i=0;i<5;i++)
            {
                for(int j=0;j<1;j++)
                {
                 if(book[i,j].Equals(s))
                 {
                     book[i,j+1]=(int)book[i,j+1]+1;
                 }
                }
            }
            for(int i=0;i<this.bksBorrowed;i++)
            {
                for(int j=0;j<1;j++)
                {
                 if(this.bookIssue[i,j].Equals(s))
                 {
                     TimeSpan f;
                     f=DateTime.Today-(DateTime)this.bookIssue[i,j+1];                 
                     Console.WriteLine("The Timespan is "+f);
                    if(f.TotalDays==15)
                     {
                         Console.WriteLine("Your Penalty is "+f.TotalDays*2);
                         Console.WriteLine("");
                     }
                 }
                }
            }
            bksBorrowed--;
        }
        public void Details()
        {
            Console.WriteLine("Name "+"     "+"Issue Date");
            for(int i=1;i<this.bksBorrowed;i++)
            {
                for(int j=0;j<2;j++)
                {
                    Console.Write(this.bookIssue[i,j]+"       "+"       ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("");
        }
    }
    public class Program
    {
       public  static void Main(string[] args)
        {
            String ans="yes";
            Admin ade=new Admin();
            do
            {
                Console.WriteLine("");
                Console.WriteLine("|--------------------------------------------------------------|");
                Console.WriteLine("|                                                              |");
                Console.WriteLine("|-------------WELCOME TO LIBRARY MANAGEMENT SYSTEM-------------|");
                Console.WriteLine("|         Please Login into One of Following Accounts :        |");
                Console.WriteLine("|                                                              |");
                Console.WriteLine("| 1.Admin                                                      |");
                Console.WriteLine("| 2.Faculty                                                    |");
                Console.WriteLine("| 3.Student                                                    |");
                Console.WriteLine("| 4.Exit                                                       |");
                Console.WriteLine("|--------------------------------------------------------------|");
                Console.WriteLine("");
                int ch=int.Parse(Console.ReadLine());
                Program p=new Program();
                switch(ch)
                {
                    case 1:
                        p.adm(ade);
                        break;
                    case 2:
                        Console.WriteLine("Please enter your name");
                        String name=Console.ReadLine();
                        Console.WriteLine("Please enter your password");
                        String pwd=Console.ReadLine();
                        int w=ade.facchk(name,pwd);
                        if(w==1)
                            p.fac(ade);
                        else if (w == 2)
                        {
                            Console.WriteLine("New User !!!");
                            ade.createFaculty(name, pwd);
                            p.fac(ade);
                        }
                        else
                        {
                            Console.WriteLine("Wrong Password or Username!!!!");
                        }
                        break;
                      case 3:
            Console.WriteLine("Please enter your name");
            String nam=Console.ReadLine();
            Console.WriteLine("Please enter your Password");
            String pw=Console.ReadLine();
            int b=ade.Stuchk(nam,pw);
            if(b==1)
                p.Stu(ade);
            else if(b==2)
            {
               Console.WriteLine("New User !!!");
               ade.createStudent(nam,pw);
               p.Stu(ade);
            }
            else
                Console.WriteLine("Wrong Password or Username!!!!");
            break;
                    case 4:
            Environment.Exit(0);
            break;
       default:
            Console.WriteLine("Please Enter a valid Choice");
            break;
                }
            Console.WriteLine("Do You want to Continue ?  yes / no");
            ans=Console.ReadLine();
            if (ans.Equals("no"))
            {
                Environment.Exit(0);
            }
            }
            while(ans.Equals("yes"));
        }
        public void fac(Admin ade)
        {
            String ans="yes";
            Faculty f=new Faculty();
            ade.FacNo+=1;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("|--------------------------------------------------------------|");
                Console.WriteLine("|                                                              |");
                Console.WriteLine("|           Please make a Choice from the following :          |");
                Console.WriteLine("| 1.Search Books                                               |");
                Console.WriteLine("| 2.Return Books                                               |");
                Console.WriteLine("| 3.Borrow Books                                               |");
                Console.WriteLine("| 4.Renew a Book                                               |");
                Console.WriteLine("| 5.View Book issue Details                                    |");
                Console.WriteLine("| 6.Return to Main menu                                        |");
                Console.WriteLine("|--------------------------------------------------------------|");
                Console.WriteLine("");
            int ch=int.Parse(Console.ReadLine());
            ade.catalouge();
            switch(ch)
            {
                case 1:
                    Console.WriteLine("Enter the name of Book");
                    String name=Console.ReadLine();
                    bool p=f.searchB(name);
                    if(p==true)
                        Console.WriteLine("Book Found");
                    else
                        Console.WriteLine("Book not Found");
                    break;
                case 2:
            Console.WriteLine("Enter the book you want to Return");
            String g=Console.ReadLine();
            f.returnBook(g);
            break;
                case 3:
                    Console.WriteLine("Enter the name of Book");
                    string y=Console.ReadLine();
                    Console.WriteLine("Enter the issue Date");
                    DateTime t=Convert.ToDateTime(Console.ReadLine());
                    f.borrow(y,t);
                    break;
                case 4:
            Console.WriteLine("Enter the book to Renew");
            string k=Console.ReadLine();
            f.renew(k);
            break;
                case 5:
            f.Details();
            break;
                case 6:
            return;
            }
            Console.WriteLine("Do you want to Continue ? yes / no");
            ans=Console.ReadLine();
            if (ans.Equals("no"))
            {
                Environment.Exit(0);
            }
            }
            while(ans.Equals("yes"));
        }
        public void Stu(Admin ade)
        {
            String ans = "yes";
            Faculty f=new Faculty();
            ade.StuNo++;
            Student l = new Student();
            do
            {
                Console.WriteLine("");
                Console.WriteLine("|--------------------------------------------------------------|");
                Console.WriteLine("|                                                              |");
                Console.WriteLine("|           Please make a Choice from the following :          |");
                Console.WriteLine("| 1.Search Books                                               |");
                Console.WriteLine("| 2.Return Books                                               |");
                Console.WriteLine("| 3.Borrow Books                                               |");
                Console.WriteLine("| 4.View Book issue Details                                    |");
                Console.WriteLine("| 5.Return to Main menu                                        |");
                Console.WriteLine("|--------------------------------------------------------------|");
                Console.WriteLine("");
                int ch = int.Parse(Console.ReadLine());
                l.catalouge();
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Enter the name of Book");
                        String name = Console.ReadLine();
                        bool p = l.searchB(name);
                        if (p == true)
                            Console.WriteLine("Book Found");
                        else
                            Console.WriteLine("Book not Found");
                        break;
                    case 2:
                        Console.WriteLine("Enter the book you want to Return");
                        String g = Console.ReadLine();
                        l.returnBook(g);
                        break;
                    case 3:
                        Console.WriteLine("Enter the name of Book");
                        string y = Console.ReadLine();
                        Console.WriteLine("Enter the issue Date");
                        DateTime t = Convert.ToDateTime(Console.ReadLine());
                        l.borrow(y, t);
                        break;
                    case 4:
                        l.Details();
                        break;
                    case 5:
                        return;
                }
                Console.WriteLine("Do you want to Continue ? yes / no");
                ans = Console.ReadLine();
                if (ans.Equals("no"))
                {
                    Environment.Exit(0);
                }
            }
            while (ans.Equals("yes"));
        }

             public void adm(Admin ade)
        {
            String ans="yes";
            ade.StuNo++;
            Student l=new Student();
            do
            {
                Console.WriteLine("");
                Console.WriteLine("|--------------------------|");
                Console.WriteLine("| 1.Manage Faculties       |");
                Console.WriteLine("| 2.Manage Students        |");
                Console.WriteLine("| 3.Mantain Books          |");
                Console.WriteLine("| 4.Return to main menu    |");
                Console.WriteLine("| Please enter your choice |");
                Console.WriteLine("|--------------------------|");
                Console.WriteLine("");
            int ch=int.Parse(Console.ReadLine());
            l.catalouge();
            switch(ch)
            {
                case 1:
                    ade.viewFac();
                    break;
                case 2:
                    ade.viewStu();
                    break;
                case 3:
                    ade.catalogue();
                    break;
                case 4:
                    return;
            }
            Console.WriteLine("Do you want to Continue ? yes / no");
            ans=Console.ReadLine();
            if (ans.Equals("no"))
            {
                Environment.Exit(0);
            }
            }
            while(ans.Equals("yes"));
             }
    }
}