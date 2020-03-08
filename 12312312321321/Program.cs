using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;


namespace _12312312321321
{
    delegate double resultate(double a, double b, double c);
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("If you want to run the program - click '1' . To exit - click '2' ");
                int f = Convert.ToInt32(Console.ReadLine());
                if (f == 1)
                {
                    INPut vhod = new INPut();
                    First_Win player1 = new First_Win();
                    Second_Win player2 = new Second_Win();


                    vhod.OnInput1 += player1.Message;
                    vhod.OnInput2 += player2.Message;
                    vhod.Input();
                }
                else
                {
                    break;
                }
                
            



            }

        }


        public class INPut
        {

   

            public delegate void MethodRate1();
            public event MethodRate1 OnInput1;
            public event MethodRate1 OnInput2;

            public string date { get; set; }

            public string player_first { get; set; }

            public string player_second { get; set; }
            double outcome(double a, double b, double c)
            {
                return a + 0.8 * (0.5 * b + 0.9 * c);
            }
            public void Input()
            {
                    Console.WriteLine("Enter the date of the match in tenis (dd/mm/yyyy):");
                    date =Console.ReadLine();
                
                 string pattern = @"\b(?<month>\d{2})/(?<day>\d{2})/(?<year>\d{4})\b";
                  while (true)
                  {
                      if (!Regex.IsMatch(date, pattern))
                      {
                          Console.WriteLine("Incorrect format of date!" +
                              "Enter the date of the match(dd/mm/yyyy):");
                          date = Console.ReadLine();
                      }
                      else
                      {
                          break;
                      }
                  }

                Console.WriteLine("Enter the name of the first player");
                     player_first = Console.ReadLine();
                    Console.WriteLine("Enter the name of the second player");
                     player_second = Console.ReadLine();

                Console.Clear();   


                    tenis m = new tenis(date, player_first, player_second);
                    Console.WriteLine("Enter the skill(from 1 to 99) and lucky(from 1 to 99) for the first player ");
                    int i = 1;
                    characteristics_teams first = new characteristics_teams();
                    double result1 = first.characteristics_players(i);

                    Console.WriteLine("Enter the age of " + player_first + "'s coach, his physical form(from 1 to 10) , his defeats and wins ");
                    // Console.WriteLine(result1);
                    int coach_cond1 = first.condition();
                    int coach_phys1 = first.winstrike();
                    resultate res1 = new resultate(outcome);
                    double resall1 = res1(result1, coach_cond1, coach_phys1);

                    
                Console.Clear();
                Console.WriteLine("\nTotal skill of the team: " + resall1 + "\n");

                Console.WriteLine("Enter the skill(from 1 to 99) and lucky(from 1 to 99) for the second player ");
                    i = 2;
                    characteristics_teams second = new characteristics_teams();
                    double result2 = second.characteristics_players(i);

                    Console.WriteLine("Enter the age of " + player_second + "'s coach, his physical form(from 1 to 10) , his defeats and wins ");
                    int coach_cond2 = second.condition();
                    int coach_phys2 = second.winstrike();
                    // resultate res2 = new resultate(outcome);
                    double resall2 = res1(result2, coach_cond2, coach_phys2);

                    Console.WriteLine("\nTotal skill of the team: " + resall2+"\n");

                if (resall1 > resall2)
                        {
                            if (OnInput1 != null)
                            { 
                                OnInput1();

                            }
                        }
                        else if (result1 < result2)
                        {
                            if (OnInput2 != null)
                            {
                                OnInput2();

                            }
                           
                        }
                    
                
            }
        }
        public class First_Win
        {

            public void Message()
            {
                Console.WriteLine("The first player is win!!\n\n");
            }
        }
        public class Second_Win
        {
            public void Message()
            {
                Console.WriteLine("The second player  is win!!\n\n");
            }
        }




        public class tenis
        {
            public string date;
            public string player_first { get; set; }

            public string player_second { get; set; }


            public tenis(string date, string team_first, string team_second)
            {
                date = this.date;
                team_first = this.player_first;
                team_second = this.player_second;
            }

        }

        interface Icoach
        {

            int condition();
            int winstrike();
        }

        public class characteristics_teams : Icoach
        {

            /*static bool IsValid(string num)
            {
                if (int.TryParse(num, out int res))
                {
                    if (res <= 99 && res >= 0)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }*/



            public double skill { get; set; }
            public double lucky { get; set; }
            public int age { get; set; }
            public int defeats { get; set; }
            public int wins { get; set; }
            public int phys_form { get; set; }
            // Dictionary<int, int> players = new Dictionary<int, int>(11);

            public double characteristics_players(int i)
            {

                Random rnd = new Random();
                List<double> all_characteristics = new List<double>(2);

               
                    Console.WriteLine("Player " + i+ "\nSkill:");

                

              skill = Convert.ToDouble(Console.ReadLine());
  
                    skill *= 4;
               
                Console.WriteLine("Lucky:");
              
                    lucky = Convert.ToDouble(Console.ReadLine());
                

                  
                    lucky *= rnd.Next(0, 10);
                    all_characteristics.Add(skill + lucky);
               
                double result = 0;
                foreach (int j in all_characteristics)
                {
                    result += j;
                }
                return result;
            }

            public int condition()
            {

                Console.WriteLine("AGE : ");
                age = Convert.ToInt32(Console.ReadLine());
                age = age / age * 10;
                Console.WriteLine("Physicla form : ");
                phys_form = Convert.ToInt32(Console.ReadLine());
                return age * phys_form;

            }

            public int winstrike()
            {

                Console.WriteLine("defeats : ");
                defeats = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("wins : ");
                wins = Convert.ToInt32(Console.ReadLine());
                return wins - defeats;
            }
        }
        

       
        
            
            

                
        

    }
}
