using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using industry_wc.BL;
using industry_wc.UI;

namespace industry_wc.DL
{
    class user_dl
    {
        static public List<user> u = new List<user>();
        static public List<viewers> v = new List<viewers>();
       
        
        static public bool load(string path)
        {
            
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;

                while ((record = file.ReadLine()) != null)
                {
                    user u = new user();
                    u.user_name = parse(record, 1);
                    u.user_pass = parse(record, 2);
                    u.role = parse(record, 3);
                    u.cnic = parse(record, 4);
                    u.contact = parse(record, 5);
                    u.address = parse(record, 6);
                    u.pay = int.Parse(parse(record, 7));
                    u.dramas = parse(record, 8);
                    u.date = parse(record, 9);
                    StoreInList(u);
                }
                file.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        static public bool loadviewer(string v_path)
        {

            if (File.Exists(v_path))
            {
                StreamReader file = new StreamReader(v_path);
                string record;

                while ((record = file.ReadLine()) != null)
                {
                    viewers v = new viewers();
                    v.user_name = parse(record, 1);
                    v.user_pass = parse(record, 2);
                    v.role = parse(record, 3);
                    StoreViewerInList(v);
                }
                file.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        static public void sort()
        {
            int position = 0;


            for (int i = 0; i < u.Count; i++)
            {
                position = i;
                int large = func(position);

                int temp = u[i].pay;
                u[i].pay = u[large].pay;
                u[large].pay = temp;

                string temp_1;
                temp_1 = u[i].user_name;
                u[i].user_name = u[large].user_name;
                u[large].user_name = temp_1;

                temp_1 = u[i].role;
                u[i].role = u[large].role;
                u[large].role = temp_1;

                temp_1 = u[i].cnic;
                u[i].cnic = u[large].cnic;
                u[large].cnic = temp_1;

                temp_1 = u[i].contact;
                u[i].contact = u[large].contact;
                u[large].contact = temp_1;

                temp_1 = u[i].address;
                u[i].address = u[large].address;
                u[large].address = temp_1;

                temp_1 = u[i].dramas;
                u[i].dramas = u[large].dramas;
                u[large].dramas = temp_1;

                temp_1 = u[i].date;
                u[i].date = u[large].date;
                u[large].date = temp_1;
            }
        }
        static public int func(int position)
        {
            int largest = u[position].pay;
            int idx = position;
            for (int i = position; i < u.Count; i++)
            {
                if (largest <= u[i].pay)
                {
                    largest = u[i].pay;

                    idx = i;
                }
            }
            return idx;
        }
        static public void StoreInList(user f)
        {
            u.Add(f);
        }
        static public void StoreViewerInList(viewers f)
        {
            v.Add(f);
        }
        static public string parse(string record, int field)
        {
            string term = "";
            int comma = 1;
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    term = term + record[i];
                }
            }
            return term;
        }
        static public void signup( )
        {
            string rol="USER";
            user_ui.add_viewer(rol);
        }
        static public bool check_user(string name, string pass)
        {
            int count = 0;
            foreach(user i in u)
            {
                if(i.user_name==name && i.user_pass==pass)
                {
                    count++;
                }
            }
            foreach (viewers i in v)
            {
                if (i.user_name == name && i.user_pass == pass)
                {
                    count++;
                }
            }
            if (count>0)
            {
                return false;
            }
            return true;
        }
        static public string roll_return(string user, string pass)
        {
            for (int x = 0; x < u.Count; x++)
            {
                if (user == u[x].user_name && pass == u[x].user_pass)
                {
                    return u[x].role;
                }
            }
            for (int x = 0; x < v.Count; x++)
            {
                if (user == v[x].user_name && pass == v[x].user_pass)
                {
                    return v[x].role;
                }
            }
            return "not include";
        }
        static public  void storeIndustry(string path)
        {
            path = "industry.txt";
            if (File.Exists(path))
            {
                StreamWriter file = new StreamWriter(path);
                for (int i = 0; i < u.Count; i++)
                {
                    file.WriteLine(u[i].user_name + "," + u[i].user_pass + "," + u[i].role + "," + u[i].cnic + "," + u[i].contact + "," + u[i].address + "," + u[i].pay + "," + u[i].dramas + "," + u[i].date);
                }
                file.Flush();
                file.Close();
            }
            else
            {
                Console.WriteLine("file not exist");
                Console.ReadKey();
            }
        }
        static public void storeViewers(string v_path)
        {
            if (File.Exists(v_path))
            {
                StreamWriter file = new StreamWriter(v_path);
                for (int i = 0; i < v.Count; i++)
                {
                    file.WriteLine(v[i].user_name + "," + v[i].user_pass + "," + v[i].role);
                }
                file.Flush();
                file.Close();
            }
            else
            {
                Console.WriteLine("file not exist");
                Console.ReadKey();
            }
        }
        static public int user_idx(string rol)
        {
            int idx = 0;
            for (int x = 0; x < u.Count; x++)
            {
                if (rol == u[x].role)
                {
                    return x;
                }
            }
            return idx;
        }
        
        static public bool check_remove(string nam, string rol)
        {
            char y = ' ';
            for (int x = 0; x < u.Count; x++)
            {

                if (nam == u[x].user_name && u[x].role == rol)
                {
                    Console.SetCursorPosition(15, 12);
                    Console.WriteLine("PRESS Y TO DELETE THIS USER ");
                    y = char.Parse(Console.ReadLine());
                    if (y == 'Y')
                    {
                        u.RemoveAt(x);
                    }
                    return true;

                }
            }
            return false;
        }
        static public int check_update(string nam, string rol)
        {
            for (int x = 0; x < u.Count; x++)
            {

                if (nam == u[x].user_name && u[x].role == rol)
                {
                    return x;
                }
            }
            return 100000;
        }
        static public void view_user(string rol)
        {
            user_ui.header();
            Console.SetCursorPosition(30, 8);
            Console.WriteLine("_______________ VIEW ALL " + rol + " _______________");
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("NAME ");
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
            int y = 11;
            for (int x = 0; x < u.Count; x++)
            {
                if (u[x].role == rol)
                {

                    Console.SetCursorPosition(0, y);
                    Console.WriteLine(u[x].user_name);
                    Console.SetCursorPosition(30, y);
                    Console.WriteLine(u[x].role);
                    Console.SetCursorPosition(40, y);
                    Console.WriteLine(u[x].cnic);
                    Console.SetCursorPosition(60, y);
                    Console.WriteLine(u[x].contact);
                    Console.SetCursorPosition(80, y);
                    Console.WriteLine(u[x].address);
                    Console.SetCursorPosition(100, y);
                    Console.WriteLine(u[x].pay);
                    Console.SetCursorPosition(110, y);
                    Console.WriteLine(u[x].dramas);
                    Console.SetCursorPosition(120, y);
                    Console.WriteLine(u[x].date);
                    y++;
                }
            }
            user_ui.clear_screen();
        }

        static public void check()
        {
            for (int i = 0; i < u.Count; i++)
            {
                drama_dl.drama_check(u[i].dramas, u[i].date);
            }
        }
        static public void show_char(string drama , string date)
        {
            int d = 0, w = 0, p = 0, a = 0;
            for (int x = 0; x < user_dl.u.Count; x++)
            {

                if (u[x].dramas == drama && u[x].date == date)
                {

                    Console.SetCursorPosition(35, 13);
                    Console.WriteLine("DIRECTOR");

                    if (user_dl.u[x].role == "DIRECTOR")
                    {
                        Console.SetCursorPosition(45, 13);
                        Console.WriteLine(user_dl.u[x].user_name);
                        d++;
                    }

                    Console.SetCursorPosition(35, 14);
                    Console.WriteLine("WRITER");

                    if (user_dl.u[x].role == "WRITER")
                    {
                        Console.SetCursorPosition(45, 14);
                        Console.WriteLine(user_dl.u[x].user_name);
                        w++;
                    }

                    Console.SetCursorPosition(35, 15);
                    Console.WriteLine("PRODUCER");

                    if (user_dl.u[x].role == "PRODUCER")
                    {
                        Console.SetCursorPosition(45, 15);
                        Console.WriteLine(user_dl.u[x].user_name);
                        p++;
                    }

                    Console.SetCursorPosition(35, 16);
                    Console.WriteLine("ACTOR");

                    if (user_dl.u[x].role == "ACTOR")
                    {
                        Console.SetCursorPosition(45, 16);
                        Console.WriteLine(user_dl.u[x].user_name);
                        a++;
                    }
                }
            }
            if (d == 0)
            {
                Console.SetCursorPosition(45, 13);
                Console.WriteLine("NEED DIRECTOR");
            }
            if (w == 0)
            {
                Console.SetCursorPosition(45, 14);
                Console.WriteLine("NEED WRITER");
            }
            if (p == 0)
            {
                Console.SetCursorPosition(45, 15);
                Console.WriteLine("NEED PRODUCER");
            }
            if (a == 0)
            {
                Console.SetCursorPosition(45, 16);
                Console.WriteLine("NEED ACTORS");
            }
        }

    }
}
