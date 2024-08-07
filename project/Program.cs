namespace StudentManagementProject
{
    class Student
    {
        public string Name
        {
            get;
            //To set the value from Constructor....Protection
            private set;
        }

        public int Roll
        {
            get;
            private set;
        }
        public DateTime Date_of_birth
        {
            get;
            private set;
        }
        public int CalculateAge()
        {
            if (string.IsNullOrEmpty(Date_of_birth.ToString()))
            {
                return 0;
            }
            else if (Date_of_birth > DateTime.Now)
            {
                throw new ArgumentException("Invalid Date Input!");
            }
            else
            {
                return DateTime.Now.Year - Date_of_birth.Year;
            }
        }
        public string IsBirthDay()
        {
            if (string.IsNullOrEmpty(Date_of_birth.ToString()))
            {
                return "Invalid Date!";
            }
            else
            {
                if (DateTime.Now.Month == Date_of_birth.Month && DateTime.Now.Day == Date_of_birth.Day)
                {
                    return "It's your Birthday! Happy Birthday";
                }
                else
                {
                    return "It's Not Your Birthday!!";
                }
            }
        }
        public void PrintStudentInfo()
        {
            Console.WriteLine($"============Student Info===========");
            Console.WriteLine($"___________________________________");
            Console.WriteLine($"Name: {Name.ToUpper()}");
            Console.WriteLine($"Age: {CalculateAge()}");
            Console.WriteLine($"Roll Number: {Roll}");
            Console.Write($"Date of Birth: {Date_of_birth.ToString("dd/MM/yyyy")}");
            Console.WriteLine($" ({Date_of_birth.ToString("dddd, dd-MMMM-yyyy")})");
            Console.WriteLine($"Birthday: {IsBirthDay()}");
        }
        public Student(string _name, int _roll, DateTime _date_of_birth)
        {
            if(_date_of_birth == default){
                //default = the min date value
                throw new ArgumentException("Invalid Date!");
            }

            if (_date_of_birth > DateTime.Now)
            {
                throw new ArgumentException("Invalid Birthday!");
            }
            else
            {
                Date_of_birth = _date_of_birth;
            }

            Name = _name;
            Roll = _roll;
            Date_of_birth = _date_of_birth;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string name;
                int roll;
                DateTime date_of_birth;

                Console.Write($"Enter Your Name: ");
                name = Console.ReadLine();
                NullCheck(name);

                Console.Write($"Enter Your Roll: ");
                roll = int.Parse(Console.ReadLine());
                if (roll <= 0)
                {
                    throw new ArgumentException("Invalid Roll Number! Negative Roll number is not Possible.");
                }

                Console.Write($"Enter Your Date Of Birth(YYYY-MM-DD): ");
                date_of_birth = Convert.ToDateTime(Console.ReadLine());

                Student user_student = new Student(name, roll, date_of_birth);
                user_student.PrintStudentInfo();

            }

            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error: {ex.ParamName}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Error: Input is Too long or Too short!");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Error: Invalid Format Or Null!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            static void NullCheck(string _name)
            {
                if (_name == "" || int.TryParse(_name, out int num))
                {
                    throw new ArgumentNullException("Input can not Be Nullable Or integer.");
                }
                if (_name.Length > 30)
                {
                    throw new ArgumentException("Input Is too Long..");
                }
            }

        }
    }
}
