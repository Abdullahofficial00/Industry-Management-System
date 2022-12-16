using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using industry_wc.BL;
using industry_wc.UI;

namespace industry_wc.DL
{
    class drama_dl
    {
        static private List<drama_bl> u = new List<drama_bl>();
        static public void drama_check(string drama ,string date)
        {
            int count= 0;
            for (int i = 0; i < u.Count; i++)
            {
                count++;
            }
            if (count == 0)
            {
                drama_bl s = new drama_bl();
                s.serial = drama;
                s.sdate = date;
                u.Add(s);
            }

        }
        static public void view_drama(int idx)
        {
            user_ui.header();
            Console.SetCursorPosition(30, 8);
            Console.WriteLine("_______________ DRAMA DETAILS_______________");
            Console.WriteLine("");
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("DRAMA :");
            Console.SetCursorPosition(30, 11);
            Console.WriteLine("RELEASE DATE :");
            for (int i = 0; i < u.Count; i++)
            {
                Console.SetCursorPosition(60, 10);
                Console.WriteLine(u[idx].serial);
                Console.SetCursorPosition(60, 11);
                Console.WriteLine(u[idx].sdate);
                int d = 0, p = 0, w = 0, a = 0;

                user_dl.show_char(u[idx].serial,u[idx].sdate);

                
            }
            user_ui.clear_screen();
        }
        static public void show_drama()
        {
            user_ui.header();
            Console.SetCursorPosition(30, 8);
            Console.WriteLine("_______________ DRAMAS _______________");
            Console.WriteLine("");

            Console.SetCursorPosition(20, 10);
            Console.WriteLine("NO.");
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("DRAMA ");

            int y = 12;
            int x = 1;
            for (int i = 0; i < u.Count; i++)
            {
                Console.SetCursorPosition(20, y);
                Console.WriteLine(x);
                Console.SetCursorPosition(30, y);
                Console.WriteLine(u[i].serial);
                y++;
                x++;
            }

            int point;
            y++;
            y++;
            Console.SetCursorPosition(30, y);
            Console.WriteLine("ENTER THE NUMBER OF DRAMA : ");
            Console.SetCursorPosition(60, y);
            point = int.Parse(Console.ReadLine());
            view_drama(point);


        }



    }
}
