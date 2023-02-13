//Zeldene van Vuren 577115 --- Cooperation= Very good
//Edward Charles McCabe 577774 --- Cooperation= Good
//Azael Mashikinya Dennis Junior Letsoalo 577194--- Cooperation= None
//Thizwilondi Nembahe 578002 --- Cooperation= None
using System.Collections;
namespace Project1
{
    class LawryStore_Credit
    {
        enum Menu
        {
            Details = 1, //Capture Details
            Credit, //Check credit qualification
            Stats, //Show qualification stats
            Exit  // Exit the program
        }

        static void Main(string[] args)
        {
            string name = " ", employment = " ", terminate;
            double debt = 0.0, jobYears = 0.0, resYears = 0.0, salary = 0.0;
            int child = 0, i =0;
            int option = 0;
            ArrayList store = new ArrayList();  //arraylist for all applicants' details
            ArrayList stats = new ArrayList();  //arraylist for applicants who qualify for credit
            do
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Capture Details                 Press ---1---");
                Console.WriteLine("Check credit qualification      Press ---2---");
                Console.WriteLine("Show qualification stats        Press ---3---");
                Console.WriteLine("Exit the program                Press ---4---");
                try
                {
                  option   = Convert.ToInt32(Console.ReadLine());
                }catch (Exception err)
                {
                    
                }
                Console.WriteLine("");

                switch ((Menu)option)
                {
                    case Menu.Details:
                        Console.WriteLine("****");
                        do
                        { 
                            while (true)
                            {
                            Console.WriteLine("Name: ");
                           
                                string sName = Console.ReadLine();
                                if (sName != "")
                                {
                                    name = sName; // Get applicant's name
                                    break;      
                                }
                                else Console.WriteLine("Invalid Input");
                            }
                               
                            while (true)
                            {
                            Console.WriteLine("Is the applicant employed (True or False): ");
                           
                                string emp = Console.ReadLine();
                                if ((emp.ToLower() == "true")  || (emp.ToLower() == "false"))
                                {  
                                    employment = emp;        //Get applicant's employment status
                                    break;
                                }
                                else Console.WriteLine("Invalid Input");
                            }
                            

                            while (true)
                            {
                                Console.WriteLine("Years in current job (if any): ");
                                try
                                {
                                    jobYears = Convert.ToDouble(Console.ReadLine());    //Get amount of years at current job
                                    break;
                                }
                                catch (Exception error)
                                {
                                    Console.WriteLine("Incorrect format");
                                }
                            }

                            while (true)
                            {
                                Console.WriteLine("Years at current residence: ");
                                try
                                {
                                    resYears = Convert.ToDouble(Console.ReadLine());       //Get amount of years at current residence
                                    break;
                                }
                                catch (Exception error)
                                {
                                    Console.WriteLine("Incorrect format");
                                }
                            }

                            while (true)
                            {
                                Console.WriteLine("Monthly Salary: ");
                                try
                                {
                                    salary = Convert.ToDouble(Console.ReadLine());      //Get applicant's salary
                                    break;
                                }
                                catch (Exception error)
                                {
                                    Console.WriteLine("Incorrect format");
                                }
                            }
                            while (true)
                            {
                                Console.WriteLine("Amount of non-mortgage debt: ");
                                try
                                {
                                    debt = Convert.ToDouble(Console.ReadLine());    //Get amount of non-mortgage debt
                                    break;
                                }
                                catch (Exception error)
                                {
                                    Console.WriteLine("Incorrect format");
                                }
                            }

                            while (true)
                            {
                                Console.WriteLine("Number of children: ");
                                try
                                {
                                    child = Convert.ToInt32(Console.ReadLine());    //Get number of children
                                    break;
                                }
                                catch (Exception error)
                                {
                                    Console.WriteLine("Incorrect format");
                                }
                            }
                            i++;
                            
                            ApplicantDetails(store,name, employment, jobYears, resYears, salary, debt, child);

                           Console.WriteLine("Do you want to capture any more applicants?\n" + "Press ---N--- for NO\n" + "Press ---Y--- for YES");
                           
                        } while (Console.ReadKey().Key is not ConsoleKey.N and ConsoleKey.Y);

                        break;

                    case Menu.Credit:
                        determine(store, stats);
                        Console.WriteLine("done\n" + "Press Enter");
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    case Menu.Stats:
                        int count = 0;
                        i = stats.Count / 7;
                        
                        for (int z = 0; z< i; z++)
                        {
                            Console.WriteLine("--------------------------------------------------------");
                            Console.WriteLine("Name: " + stats[0 +count]);              
                            Console.WriteLine("Employment Status: " + stats[1+count]);    
                            Console.WriteLine("Years in current job: " + stats[2+count]); 
                            Console.WriteLine("Years at current residence: " + stats[3+count]); 
                            Console.WriteLine("Monthly Salary: " + stats[4+count]); 
                            Console.WriteLine("Amount of non-mortgage debt: " + stats[5+count]); 
                            Console.WriteLine("Children: " + stats[6+count]);
                            Console.WriteLine();
                            count += 7;
                        }
                        break;

                    case Menu.Exit:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            } while (Console.ReadKey().Key is not ConsoleKey.D4); 
        }
        public static ArrayList ApplicantDetails(ArrayList store,string name, string employment, double jobYears, double resYears, double salary, double debt, int child)         
        {                                                   
            ArrayList applicants = new ArrayList();         
            applicants.Add(name);               //stores applicant's name                           0
            applicants.Add(employment);         //stores applicant's employment status              1
            applicants.Add(jobYears);           //stores number of years in current job(if any)     2
            applicants.Add(resYears);           //stores number of years at current residence       3
            applicants.Add(salary);             //stores monthly salary                             4
            applicants.Add(debt);               //stores amount of non-mortgage debt                5
            applicants.Add(child);              //stores number of children                         6

            for (int i = 0; i < applicants.Count; i++)
            {
                store.Add(applicants[i]); // store all the applicants in one arraylist
            }
            return store;
        }

        public static ArrayList determine(ArrayList applicants, ArrayList applicantsQualify)
        {
            ArrayList check = new ArrayList();
            int amount=0, amountQ = 0;
            int count = applicants.Count; //number of elements in arraylist
            int i = count / 7;            //get number of applicants
            for (int j = 0; j < applicants.Count; j++)
            {
                check.Add(applicants[j]);  //store applicant's details in a temporary arraylist to be able to modify it
            }
            for (int k = 0; k < i; k++)
            {
                if (((double)check[5] < ((double)check[4] * 2)) && ((int)check[6] < 6))//checks if the person owes two months’ salary in non-mortgage debt
                {                                                                       // or if the person has more than six children
                    if ((check[1] == "true")  && ((double)check[2] > 1.0))
                    { //checks that the person is not jobless and that the person is at the same job for more than a year
                        applicantsQualify.Add(check[0]);
                        applicantsQualify.Add(check[1]);
                        applicantsQualify.Add(check[2]);
                        applicantsQualify.Add(check[3]); // The applicants who qualify for credit are stored in their own collection
                        applicantsQualify.Add(check[4]);
                        applicantsQualify.Add(check[5]);
                        applicantsQualify.Add(check[6]);
                        Console.WriteLine(check[0] + " qualifies for credit");
                        amountQ++;
                    }
                    else if (((double)check[3] >= 2)) //checks that the person has lived in the same location for at least 2 years
                    {
                        applicantsQualify.Add(check[0]);
                        applicantsQualify.Add(check[1]);
                        applicantsQualify.Add(check[2]);
                        applicantsQualify.Add(check[3]); // The applicants who qualify for credit are stored in their own collection
                        applicantsQualify.Add(check[4]);
                        applicantsQualify.Add(check[5]);
                        applicantsQualify.Add(check[6]);
                        Console.WriteLine(check[0] + " qualifies for credit");
                        amountQ++;
                    }
                    else
                    {
                        Console.WriteLine(check[0] + " does not qualify for credit");
                        amount++;
                    }
                } else {
                    Console.WriteLine(check[0] + " does not qualify for credit");
                    amount++;
                }

                check.RemoveRange(0,7); //remove the current applicant from the temporary arraylist to check the next applicant
            }
            Console.WriteLine("===========================================");
            Console.WriteLine(amountQ + " qualifies for credit.");
            Console.WriteLine(amount + " does not qualify for credit.");
            return applicantsQualify;  //returns the arraylist that contains the applicants who qualify for credit
            
        }
    }
}
