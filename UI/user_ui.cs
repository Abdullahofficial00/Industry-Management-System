using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using industry_wc.BL;
using industry_wc.DL;

namespace industry_wc.UI
{
    class user_ui
    {
        static public string page()
        {
            string name;
            string pass;
            bool flag = false;
            while (flag == false)
            {
                header();
                Console.SetCursorPosition(30, 8);
                Console.WriteLine("_______________ SIGN IN _______________");
                Console.SetCursorPosition(30, 10);
                Console.WriteLine("USER NAME ");
                Console.SetCursorPosition(30, 11);
                Console.WriteLine("PASSWARD");
                Console.SetCursorPosition(50, 10);
                name = Console.ReadLine();
                Console.SetCursorPosition(50, 11);
                pass = Console.ReadLine();
                string check = user_dl.roll_return(name, pass);
                if (check== "not include")
                {
                    header();
                    Console.SetCursorPosition(40, 8);
                    Console.WriteLine("ENTER THE VALID USERNAME OR PASSWARD");
                    Console.WriteLine("");
                    clear_screen();
                }
                else
                {
                    flag = true;
                    return check;
                }
            }
            return "1";
        }
        static public string Admin()
        {
            string op = "0";
            header();
            Console.SetCursorPosition(30, 8);
            Console.WriteLine("_______________ ADMIN MENU _______________");
            Console.WriteLine("");
            Console.WriteLine("1. DIRECTOR    ");
            Console.WriteLine("2. WRITER      ");
            Console.WriteLine("3. PRODUCER    ");
            Console.WriteLine("4. ACTOR       ");
            Console.WriteLine("5. EMPLOYEE    ");
            Console.WriteLine("6. DRAMAS    ");
            Console.WriteLine("7. EXIT    ");
            op = Console.ReadLine();
            return op;
        }
        static public string director_1(string rol)
        {
            header();
            string op1 = "0";
            Console.SetCursorPosition(30, 8);
            Console.WriteLine("_______________" + rol + "_______________");
            Console.WriteLine("");
            Console.WriteLine("1. ADD ", rol);
            Console.WriteLine("2. REMOVE  ", rol);
            Console.WriteLine("3. UPDATE ", rol);
            Console.WriteLine("4. VIEW ALL ", rol);
            Console.WriteLine("5. EXIT ");
            op1 = Console.ReadLine();
            return op1;
        }
        static public void add_user(string rol)
        {
            user u = new user();
            header();
            Console.SetCursorPosition(30, 8);
            Console.WriteLine("_______________ ADD " + rol + " _______________");
            Console.WriteLine("");
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("USERNAME :");
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("PASSWARD :");
            Console.SetCursorPosition(0, 12);
            Console.WriteLine("ROLE :");
            u.role = rol;
            Console.SetCursorPosition(0, 13);
            Console.WriteLine("CNIC :");
            Console.SetCursorPosition(0, 14);
            Console.WriteLine("CONTACT NO / EMAIL :");
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("ADRESS :");
            Console.SetCursorPosition(0, 16);
            Console.WriteLine("PAY :");
            Console.SetCursorPosition(0, 17);
            Console.WriteLine("DRAMA :");
            Console.SetCursorPosition(0, 18);
            Console.WriteLine("RELEASING DATE :");

            Console.SetCursorPosition(30, 10);
            u.user_name = Console.ReadLine();
            Console.SetCursorPosition(30, 11);
            u.user_pass = Console.ReadLine();
            u.role = rol;
            Console.SetCursorPosition(30, 12);
            Console.WriteLine(u.role);
            Console.SetCursorPosition(30, 13);
            u.cnic = Console.ReadLine();
            Console.SetCursorPosition(30, 14);
            u.contact = Console.ReadLine();
            Console.SetCursorPosition(30, 15);
            u.address = Console.ReadLine();
            Console.SetCursorPosition(30, 16);
            u.pay = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(30, 17);
            u.dramas = Console.ReadLine();
            Console.SetCursorPosition(30, 18);
            u.date = Console.ReadLine();

            Console.SetCursorPosition(20, 24);
            Console.WriteLine(u.role + " IS ADDED");
            Console.WriteLine("");
            user_dl.StoreInList(u);
            clear_screen();
        }
        static public void add_viewer(string rol)
        {
            viewers u = new viewers();

            bool check =false;
            while (check != true)
            {
                header();
                Console.SetCursorPosition(30, 8);
                Console.WriteLine("_______________ ADD " + rol + " _______________");
                Console.WriteLine("");
                Console.SetCursorPosition(0, 10);
                Console.WriteLine("USERNAME :");
                Console.SetCursorPosition(0, 11);
                Console.WriteLine("PASSWARD :");
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("ROLE :");
                u.role = rol;

                string name, pass;
                Console.SetCursorPosition(30, 10);
                name = Console.ReadLine();
                Console.SetCursorPosition(30, 11);
                pass = Console.ReadLine();
                if (user_dl.check_user(name,pass) == true)
                {
                    u.user_name = name;
                    u.user_pass = pass;
                    check = true;
                }
                else
                {
                    Console.SetCursorPosition(0, 14);
                    Console.WriteLine("THIS USER NAME ALREADY EXIST");
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("USE ANOTHER USERNAME OR PASSWARD");
                    Console.WriteLine();
                    Console.SetCursorPosition(0, 17);
                    clear_screen();
                    check =false;
                }
            }
            u.role = rol;
            Console.SetCursorPosition(30, 12);
            Console.WriteLine(u.role);


            Console.SetCursorPosition(20, 24);
            Console.WriteLine(u.role + " IS ADDED");
            Console.WriteLine("");
            user_dl.StoreViewerInList(u);
            clear_screen();
        }
        static public void remove_user( string rol)
        {
            string nam;
            header();
            Console.SetCursorPosition(30, 8);
            Console.WriteLine("_______________ REMOVE " + rol + " _______________");
            Console.WriteLine("");
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("USERNAME :");
            Console.SetCursorPosition(30, 10);
            nam = Console.ReadLine();

            
            bool check = user_dl.check_remove(nam, rol);
            if(check==true)
                {
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine(nam + " IS REMOVED.......");
                }
                else
                {
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine(nam + " IS NOT A " + rol);
                    Console.WriteLine("");
                    Console.WriteLine("ENTER THE VALID USERNAME.......... ");
                }
            clear_screen();
        }
        static public void update_user(string rol)
        {
            string nam;
            header();
            Console.SetCursorPosition(30, 8);
            Console.WriteLine("_______________ UPDATE " + rol + "_______________");
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("USERNAME :");
            Console.SetCursorPosition(30, 10);
            nam = Console.ReadLine();

            char y = ' ';
            
            int x = user_dl.check_update(nam, rol);
            
                if (x != 100000)
                {
                    header();
                    Console.SetCursorPosition(30, 8);
                    Console.WriteLine("_______________ UPDATE ", rol, " _______________");

                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine("UPDATE USERNAME :");
                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine("UPDATE PASSWARD :");
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine("UPDATE ROLE :");

                    Console.SetCursorPosition(0, 13);
                    Console.WriteLine("UPDATE CNIC :");
                    Console.SetCursorPosition(0, 14);
                    Console.WriteLine("UPDATE CONTACT NO / EMAIL :");
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("UPDATE ADRESS :");
                    Console.SetCursorPosition(0, 16);
                    Console.WriteLine("UPDATE PAY :");
                    Console.SetCursorPosition(0, 17);
                    Console.WriteLine("UPDATE DRAMA :");
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine("UPDATE RELEASING DATE :");

                    Console.SetCursorPosition(30, 10);
                    user_dl.u[x].user_name = Console.ReadLine();
                    Console.SetCursorPosition(30, 11);
                user_dl.u[x].user_pass = Console.ReadLine();
                    Console.SetCursorPosition(30, 12);
                user_dl.u[x].role = Console.ReadLine();
                    Console.SetCursorPosition(30, 13);
                user_dl.u[x].cnic = Console.ReadLine();
                    Console.SetCursorPosition(30, 14);
                user_dl.u[x].contact = Console.ReadLine();
                    Console.SetCursorPosition(30, 15);
                user_dl.u[x].address = Console.ReadLine();
                    Console.SetCursorPosition(30, 16);
                user_dl.u[x].pay = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(30, 17);
                user_dl.u[x].dramas = Console.ReadLine();
                    Console.SetCursorPosition(30, 18);
                user_dl.u[x].date = Console.ReadLine();
                y = 'Y';
                }
                else
                {
                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine(nam + " IS NOT A " + rol);
                    Console.WriteLine("ENTER THE VALID USERNAME.......... ");
                }
            
            if (y == 'y')
            {
                Console.SetCursorPosition(0, 12);
                Console.WriteLine(nam + " IS UPDATED.......");
            }
            clear_screen();
        }
        
        static public void header()
        {
            Console.Clear();
            ConsoleColor color = ConsoleColor.Green;
            Console.ForegroundColor = color;
            Console.SetCursorPosition(30, 0);
            Console.WriteLine("=====  =    =  ======  =    =  ======  =======  ======  =     =");
            color = ConsoleColor.Red;
            Console.ForegroundColor = color;
            Console.SetCursorPosition(30, 1);
            Console.WriteLine("  =    = =  =  =    =  =    =  =          =     =    =   =   =");
            color = ConsoleColor.DarkYellow;
            Console.ForegroundColor = color;
            Console.SetCursorPosition(30, 2);
            Console.WriteLine("  =    =  = =  =    =  =    =    =        =     ======     =");
            color = ConsoleColor.Blue;
            Console.ForegroundColor = color;
            Console.SetCursorPosition(30, 3);
            Console.WriteLine("  =    =   ==  =    =  =    =      =      =     = =        =");
            color = ConsoleColor.DarkGray;
            Console.ForegroundColor = color;
            Console.SetCursorPosition(30, 4);
            Console.WriteLine("=====  =    =  ======  ======  ======     =     =   =      =");

            color = ConsoleColor.Black;
            Console.ForegroundColor = color;

        }
        static public void clear_screen()
        {
            Console.WriteLine("");
            Console.WriteLine(" PRESS ANY KET TO CONTINUE ..... ");
            Console.ReadLine();
            Console.Clear();
        }
        static public string sign()
        {
            string op = "0";
            while (op != "3")
            {
                header();
                Console.SetCursorPosition(30, 8);
                Console.WriteLine("_______________ SIGN UP / SIGN IN_______________");
                Console.SetCursorPosition(30, 10);
                Console.WriteLine("1.SIGN IN            ");
                Console.SetCursorPosition(30, 11);
                Console.WriteLine("2 SIGN UP            ");
                Console.SetCursorPosition(30, 12);
                Console.WriteLine("3.EXIT            ");
                Console.WriteLine("");
                Console.SetCursorPosition(30, 13);
                Console.WriteLine("ENTER THE OPTION");
                Console.SetCursorPosition(60, 13);
                op = Console.ReadLine();
                if (op != "1" && op != "2" && op != "3")
                {
                    header();
                    Console.SetCursorPosition(30, 8);
                    Console.WriteLine("_______________ SIGN UP / SIGN IN_______________");
                    Console.SetCursorPosition(30, 10);
                    Console.WriteLine("ENTER THE RIGHT OPTION");
                    Console.SetCursorPosition(30, 11);
                    Console.WriteLine("PRESS ANY KEY TO CONTINUE");
                    Console.ReadKey();
                }
                else
                {
                    return op;
                }
            }
            return "3";
        }
        static public void user_role(string rol)
        {
            header();
            Console.SetCursorPosition(30, 8);
            int y = 10;
            Console.WriteLine("_______________ " + rol + " ROLE _______________");
            Console.SetCursorPosition(0, y);
            Console.WriteLine("NAME ");
            Console.SetCursorPosition(20, y);
            Console.WriteLine("ROLE ");
            Console.SetCursorPosition(40, y);
            Console.WriteLine("DRAMA ");
            Console.SetCursorPosition(60, y);




            int n = 12;
            int x = user_dl.user_idx(rol);
            Console.SetCursorPosition(0, n);
            Console.WriteLine(user_dl.u[x].user_name);
            Console.SetCursorPosition(20, n);
            Console.WriteLine(user_dl.u[x].role);
            Console.SetCursorPosition(40, n);
            Console.WriteLine(user_dl.u[x].dramas);
            Console.SetCursorPosition(60, n);
            clear_screen();
        }
        static public void user_pay(string rol)
        {
            header();
            Console.SetCursorPosition(30, 8);
            Console.WriteLine("_______________ " + rol + " PAY _______________");
            Console.WriteLine("");
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("NAME ");
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("ROLE ");
            Console.SetCursorPosition(40, 10);
            Console.WriteLine("PAY ");
            Console.SetCursorPosition(60, 10);

            int x = user_dl.user_idx(rol);
            

                    Console.SetCursorPosition(0, 12);
                    Console.WriteLine(user_dl.u[x].user_name);
                    Console.SetCursorPosition(20, 12);
                    Console.WriteLine(user_dl.u[x].role);
                    Console.SetCursorPosition(40, 12);
                    Console.WriteLine(user_dl.u[x].pay);
                    Console.SetCursorPosition(60, 12);
                
            clear_screen();
        }
        static public void user_profile(string rol )
        {
            header();
            Console.SetCursorPosition(30, 8);
            Console.WriteLine("_______________ " + rol + " PROFILE _______________");
            Console.WriteLine("");
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("NAME ");
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("PASSWARD ");
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("ROLE ");
            Console.SetCursorPosition(40, 10);
            Console.WriteLine("CNIC ");
            Console.SetCursorPosition(60, 10);
            Console.WriteLine("CONTACT ");
            Console.SetCursorPosition(80, 10);
            Console.WriteLine("ADDRESS ");
            Console.SetCursorPosition(100, 10);
            Console.WriteLine("PAY ");
            Console.SetCursorPosition(110, 10);
            Console.WriteLine("DRAMA ");
            Console.SetCursorPosition(120, 10);
            Console.WriteLine("RELEASE DATE ");
            int y = 12;
            int x = user_dl.user_idx(rol);

            Console.SetCursorPosition(0, y);
                    Console.WriteLine(user_dl.u[x].user_name);
                    Console.SetCursorPosition(20, y);
                    Console.WriteLine(user_dl.u[x].user_pass);
                    Console.SetCursorPosition(30, y);
                    Console.WriteLine(user_dl.u[x].role);
                    Console.SetCursorPosition(40, y);
                    Console.WriteLine(user_dl.u[x].cnic);
                    Console.SetCursorPosition(60, y);
                    Console.WriteLine(user_dl.u[x].contact);
                    Console.SetCursorPosition(80, y);
                    Console.WriteLine(user_dl.u[x].address);
                    Console.SetCursorPosition(100, y);
                    Console.WriteLine(user_dl.u[x].pay);
                    Console.SetCursorPosition(110, y);
                    Console.WriteLine(user_dl.u[x].dramas);
                    Console.SetCursorPosition(120, y);
                    Console.WriteLine(user_dl.u[x].date);
                    y++;
            clear_screen();
        }
        
        static public string user_page(string rol)
        {
            header();
            string op = "0";
            Console.SetCursorPosition(30, 8);
            Console.WriteLine("_______________ " + rol + " PAGE _______________");
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("1.PROFILE ");
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("2.PAY");
            Console.SetCursorPosition(0, 12);
            Console.WriteLine("3.MY DRAMAS");
            Console.SetCursorPosition(0, 13);
            Console.WriteLine("4.EXIT");
            Console.SetCursorPosition(0, 14);
            op = Console.ReadLine();
            return op;
        }
        
    }
}
