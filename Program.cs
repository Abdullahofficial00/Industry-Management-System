using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using industry_wc.BL;
using industry_wc.DL;
using industry_wc.UI;

namespace industry_wc
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "industry.txt";
            string v_path = "viewers.txt";
            

            string main;

            bool CheckLoad = user_dl.load(path);
            bool CheckViewerLoad = user_dl.loadviewer(v_path);
            user_dl.sort();
            user_dl.storeIndustry(path);
            user_dl.storeViewers(v_path);

            user_dl.check();
            ;

            String option = "1";
            bool check = false;
            while (check != true)
            {
                string rol;
                option = user_ui.sign();
                if (option == "1")
                {
                    main = user_ui.page();
                    if (main == "DIRECTOR")
                    {
                        string op = "1";
                        while (op != "7")
                        {

                            op = user_ui.Admin();
                            if (op == "1")
                            {
                                string op1 = "2";
                                while (op1 != "5")
                                {
                                    rol = "DIRECTOR";
                                    op1 = user_ui.director_1(rol);
                                    if (op1 == "1")
                                    {
                                        user_ui.add_user( rol);
                                    }
                                    else if (op1 == "2")
                                    {
                                        user_ui.remove_user(rol);
                                    }
                                    else if (op1 == "3")
                                    {
                                        user_ui.update_user(rol);
                                    }
                                    else if (op1 == "4")
                                    {
                                        user_dl.sort();
                                        user_dl.view_user(rol);
                                    }
                                    else if (op1 != "5")
                                    {
                                        Console.WriteLine("ENTER THE VALID OPTION");
                                        user_ui.clear_screen();
                                    }
                                    user_dl.storeViewers(v_path);
                                    user_dl.storeIndustry(path);
                                    user_dl.check();
                                }
                            }
                            else if (op == "2")
                            {

                                string op1 = "1";
                                while (op1 != "5")
                                {
                                    rol = "WRITER";
                                    op1 = user_ui.director_1(rol);
                                    if (op1 == "1")
                                    {
                                        user_ui.add_user( rol);
                                    }
                                    else if (op1 == "2")
                                    {
                                        user_ui.remove_user(rol);
                                    }
                                    else if (op1 == "3")
                                    {
                                        user_ui.update_user( rol);
                                    }
                                    else if (op1 == "4")
                                    {
                                        user_dl.sort();

                                        user_dl.view_user( rol);
                                    }
                                    else if (op1 != "5")
                                    {
                                        Console.WriteLine("ENTER THE VALID OPTION");
                                        user_ui.clear_screen();
                                    }
                                    user_dl.storeViewers(v_path);
                                    user_dl.storeIndustry(path);
                                    user_dl.check();
                                }
                            }
                            else if (op == "3")
                            {

                                string op1 = "2";
                                while (op1 != "5")
                                {
                                    rol = "PRODUCER";
                                    op1 = user_ui.director_1(rol);
                                    if (op1 == "1")
                                    {
                                        user_ui.add_user( rol);
                                    }
                                    else if (op1 == "2")
                                    {
                                        user_ui.remove_user( rol);
                                    }
                                    else if (op1 == "3")
                                    {
                                        user_ui.update_user( rol);
                                    }
                                    else if (op1 == "4")
                                    {
                                        user_dl.sort();
                                        user_dl.view_user( rol);
                                    }
                                    else if (op1 != "5")
                                    {

                                        Console.WriteLine("ENTER THE VALID OPTION");
                                        user_ui.clear_screen();
                                    }
                                    user_dl.storeViewers(v_path);
                                    user_dl.storeIndustry(path);
                                    user_dl.check();
                                }
                            }
                            else if (op == "4")
                            {

                                string op1 = "2";
                                while (op1 != "5")
                                {
                                    rol = "ACTOR";
                                    op1 = user_ui.director_1(rol);
                                    if (op1 == "1")
                                    {
                                        user_ui.add_user( rol);
                                    }
                                    else if (op1 == "2")
                                    {
                                        user_ui.remove_user( rol);
                                    }
                                    else if (op1 == "3")
                                    {
                                        user_ui.update_user( rol);
                                    }
                                    else if (op1 == "4")
                                    {
                                        user_dl.sort();
                                        user_dl.view_user( rol);
                                    }
                                    else if (op1 != "5")
                                    {
                                        Console.WriteLine("ENTER THE VALID OPTION");
                                        user_ui.clear_screen();
                                    }
                                    user_dl.storeViewers(v_path);
                                    user_dl.storeIndustry(path);
                                    user_dl.check();
                                }
                            }
                            else if (op == "5")
                            {

                                string op1 = "2";
                                while (op1 != "5")
                                {
                                    rol = "EMPLOYEE";
                                    op1 = user_ui.director_1(rol);
                                    if (op1 == "1")
                                    {
                                        user_ui.add_user( rol);
                                    }
                                    else if (op1 == "2")
                                    {
                                        user_ui.remove_user(rol);
                                    }
                                    else if (op1 == "3")
                                    {
                                        user_ui.update_user( rol);
                                    }
                                    else if (op1 == "4")
                                    {
                                        user_dl.sort();
                                        user_dl.view_user( rol);
                                    }
                                    else if (op1 != "5")
                                    {
                                        Console.WriteLine("ENTER THE VALID OPTION");
                                        user_ui.clear_screen();
                                    }
                                    user_dl.storeViewers(v_path);
                                    user_dl.storeIndustry(path);
                                    user_dl.check();
                                }
                            }
                            else if (op == "6")
                            {
                                user_dl.sort();
                                
                                {
                                    drama_dl.show_drama();
                                }
                            }
                        }
                    }

                    else if (main == "WRITER" || main == "PRODUCER" || main == "ACTOR" || main == "EMPLOYEE")
                    {
                        user_dl.sort();
                        rol = main;
                        string op2 = "1";

                        while (op2 != "4")
                        {
                            op2 = user_ui.user_page(rol);

                            if (op2 == "1")
                            {
                                user_ui.user_profile(rol);
                            }
                            else if (op2 == "2")
                            {
                                user_ui.user_pay(rol );
                            }
                            else if (op2 == "3")
                            {
                                user_ui.user_role(rol);
                            }
                            else if (op2 != "4")
                            {
                                Console.WriteLine("ENTER THE VALID OPTION");
                                user_ui.clear_screen();
                            }
                        }
                    }

                    else if (main == "USER")
                    {
                        user_dl.sort();
                        drama_dl.show_drama();
                    }
                }
                else if (option == "2")
                {
                    rol = "user";
                    user_dl.signup( );
                    user_dl.storeViewers(v_path);
                    user_dl.storeIndustry(path);
                }
                else if (option == "3")
                {
                    break;
                }
            }

        }
    }
}
