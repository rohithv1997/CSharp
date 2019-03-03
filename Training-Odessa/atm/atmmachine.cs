using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace atm
{
    class atmmachine
    {
        int atmbal;
        SqlConnection conn;
        SqlDataReader reader = null;
        SqlCommand cmd;
        public atmmachine()
        {
            conn = new SqlConnection("Data Source=LW-RVENKAT\\SQL2016;Initial Catalog=atmcustomers;Integrated Security=true;");
            reader = null;
        }
        public void viewbal(int uid, int pwd)
        {

            try
            {
                conn.Open();
                cmd = new SqlCommand("select bal from cususer where userid=@userid and pwd=@password", conn);
                cmd.Parameters.Add(new SqlParameter("@userid", uid));
                cmd.Parameters.Add(new SqlParameter("@password", pwd));
                reader = cmd.ExecuteReader();
                //conn.Close();
                if (reader.Read())
                {
                    string balance = null;
                    balance = reader["bal"].ToString();
                    Console.WriteLine("The Current Account Balance: " + balance);
                    reader.Close();
                    conn.Close();
                    Console.ReadKey();
                    return;

                }
                else
                {
                    Console.WriteLine("Invalid Login Credentials\nTry Again :(");
                    Console.ReadKey();
                    reader.Close();
                    conn.Close();
                    return;
                }

            }
            catch (Exception e)
            {
                reader.Close();
                conn.Close();
                Console.WriteLine(e);
                Console.ReadKey();
                //Console.ReadKey();
            }
            return;
        }
        public void withdraw(int uid, int pwd)
        {
            try
            {
                double balance = 0;
                atmbal = 0;
                int ch2 = 7;
                conn.Open();
                cmd = new SqlCommand("select bal from cususer where userid=@userid and pwd=@password", conn);
                cmd.Parameters.Add(new SqlParameter("@userid", uid));
                cmd.Parameters.Add(new SqlParameter("@password", pwd));
                reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    balance = Convert.ToDouble((reader[0].ToString()));
                }
                Console.WriteLine("Current Balance: " + balance);
                //reader.Close();
                conn.Close();

                conn.Open();
                cmd = new SqlCommand("select c20 from machine", conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    atmbal = Convert.ToInt32((reader[0].ToString()));
                }
                Console.WriteLine("Machine Balance: "+atmbal*20);
                // reader.Close();
                conn.Close();

                while (ch2 != 6)
                {

                    Console.WriteLine("\n\n\n\n");
                    Console.WriteLine("Withdrawal Menu");
                    Console.WriteLine("1. $20");
                    Console.WriteLine("2. $40");
                    Console.WriteLine("3. $60");
                    Console.WriteLine("4. $100");
                    Console.WriteLine("5. $200");
                    Console.WriteLine("6. Exit");
                    Console.Write("Choice: ");
                    ch2 = Convert.ToInt32(Console.ReadLine());
                    if (ch2 == 1)
                    {
                        if (balance >= 20.00 && atmbal >= 1)
                        {
                            --atmbal;
                            balance -= 20.00;
                        }
                        else if (atmbal < 1)
                        {
                            Console.WriteLine("ATM has less cash :(");
                            return;
                        }
                        else if (balance < 20.00)
                        {
                            Console.WriteLine("You have less cash :(");
                            return;
                        }
                        Console.ReadKey();
                    }
                    else if (ch2 == 2)
                    {
                        if (balance >= 40.00 && atmbal >= 2)
                        {
                            atmbal -= 2;
                            balance -= 40.00;
                        }
                        else if (atmbal < 2)
                        {
                            Console.WriteLine("ATM has less cash :(\nSelect Lower Denomination.");
                            return;
                        }
                        else if (balance < 40.00)
                        {
                            Console.WriteLine("You have less cash :(\nSelect Lower Denomination.");
                            return;
                        }
                        Console.ReadKey();

                    }
                    else if (ch2 == 3)
                    {
                        if (balance >= 60.00 && atmbal >= 3)
                        {
                            atmbal -= 3;
                            balance -= 60.00;
                        }
                        else if (atmbal < 3)
                        {
                            Console.WriteLine("ATM has less cash :(\nSelect Lower Denomination.");
                            return;
                        }
                        else if (balance < 60.00)
                        {
                            Console.WriteLine("You have less cash :(\nSelect Lower Denomination.");
                            return;
                        }
                        Console.ReadKey();
                    }
                    else if (ch2 == 4)
                    {
                        if (balance >= 100.00 && atmbal >= 5)
                        {
                            atmbal -= 5;
                            balance -= 100.00;
                        }
                        else if (atmbal < 5)
                        {
                            Console.WriteLine("ATM has less cash :(\nSelect Lower Denomination.");
                            return;
                        }
                        else if (balance < 100.00)
                        {
                            Console.WriteLine("You have less cash :(\nSelect Lower Denomination.");
                            return;
                        }
                        Console.ReadKey();
                    }
                    else if (ch2 == 5)
                    {
                        if (balance >= 200.00 && atmbal >= 10)
                        {
                            atmbal -= 10;
                            balance -= 200.00;
                        }
                        else if (atmbal < 10)
                        {
                            Console.WriteLine("ATM has less cash :(\nSelect Lower Denomination.");
                            return;
                        }
                        else if (balance < 200.00)
                        {
                            Console.WriteLine("You have less cash :(\nSelect Lower Denomination.");
                            return;
                        }
                        Console.ReadKey();
                    }
                    else if (ch2 == 6)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Option :3");
                        Console.ReadKey();

                    }
                    conn.Open();
                    Console.WriteLine("Take Cash :");
                    cmd = new SqlCommand("update cususer set bal=@balance where userid=@userid and pwd=@password", conn);
                    cmd.Parameters.Add(new SqlParameter("@balance", balance));
                    cmd.Parameters.Add(new SqlParameter("@userid", uid));
                    cmd.Parameters.Add(new SqlParameter("@password", pwd));
                    reader = cmd.ExecuteReader();
                    Console.ReadKey();
                    Console.WriteLine("Thank You :)");
                    reader.Close();
                    conn.Close();
                    conn.Open();

                    cmd = new SqlCommand("update machine set c20=@w", conn);
                    cmd.Parameters.Add(new SqlParameter("@w", atmbal));
                    reader = cmd.ExecuteReader();
                    Console.ReadKey();
                    reader.Close();
                    conn.Close();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
                conn.Close();
                reader.Close();
            }

        }
        public void deposit(int uid, int pwd)
        {
            
            double balance2=0.00;
            atmbal = 0;
            try
            {
                int ch3 = 1;

                conn.Open();
                cmd = new SqlCommand("select bal from cususer where userid=@userid and pwd=@password", conn);
                cmd.Parameters.Add(new SqlParameter("@userid", uid));
                cmd.Parameters.Add(new SqlParameter("@password", pwd));
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    balance2 = Convert.ToDouble((reader[0].ToString()));
                }

                //reader.Close();
                conn.Close();

                while (ch3 != 0)
                {
                    Console.WriteLine("Enter Amount to be Deposited:");
                    double x = Convert.ToDouble(Console.ReadLine()) / 100;
                    if (x == 0.00)
                    {
                        Console.WriteLine("Aborting the Transaction");
                        return;
                    }
                    else {
                        bool flag = true;
                        balance2 = balance2 + x;
                        Console.WriteLine();
                        Console.WriteLine("Insert the Deposit Envelope into the Deposit Slot");
                        DateTime start;
                        start = DateTime.Now;
                        while(((DateTime.Now- start).TotalSeconds)<=120 && Console.KeyAvailable)
                            flag=true;
                        if(flag==false)
                        {
                            Console.WriteLine("Transaction Aborted");
                            return;
                        }
                        conn.Open();
                        Console.WriteLine("Loaded Cash.\nCheck Balance after 2 minutes.");
                        cmd = new SqlCommand("update cususer set bal=@balance2 where userid=@userid and pwd=@password", conn);
                        cmd.Parameters.Add(new SqlParameter("@balance2", balance2));
                        cmd.Parameters.Add(new SqlParameter("@userid", uid));
                        cmd.Parameters.Add(new SqlParameter("@password", pwd));
                        reader = cmd.ExecuteReader();
                        Console.ReadKey();
                        Console.WriteLine("Thank You :)");
                        reader.Close();
                        conn.Close();
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                reader.Close();
                Console.WriteLine(e);
                Console.ReadKey();
                conn.Close();
            }
        }

        public void menu(int uid, int pwd)
        {
            int ch = 5;
            while (ch != 4)
            {
                Console.Clear();
                //Console.WriteLine("\n\n\n\n");
                Console.WriteLine("ATM Menu");
                Console.WriteLine("1. View Balance");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Exit");
                Console.Write("Choice: ");
                ch = Convert.ToInt32(Console.ReadLine());
                if (ch == 1)
                {
                    viewbal(uid, pwd);
                }
                else if (ch == 2)
                {
                    withdraw(uid, pwd);

                }
                else if (ch == 3)
                {

                    deposit(uid, pwd);
                }
                else if (ch == 4)
                {
                    Console.WriteLine("Good Bye!!");
                    return;

                }
            }
        }
        public int signin(int uid, int pwd)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=LW-RVENKAT\\SQL2016;" +
                "Initial Catalog=atmcustomers;" +
                "Integrated Security=true;";
            reader = null;
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from cususer where userid=@userid and pwd=@password", conn);
                cmd.Parameters.Add(new SqlParameter("@userid", uid));
                cmd.Parameters.Add(new SqlParameter("@password", pwd));

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    conn.Close();
                    menu(uid, pwd);
                    //reader.Close();

                    return 2;

                }
                else
                {
                    Console.WriteLine("Invalid Login Credentials\nTry Again :(");
                    reader.Close();
                    conn.Close();
                    return 1;
                }
                //conn.Close();
            }
            catch (Exception e)
            {
                //reader.Close();
                Console.WriteLine(e);
                Console.ReadKey();
                conn.Close();
            }
            return 0;
        }
    }
}
