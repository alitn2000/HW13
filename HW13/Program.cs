
using HW13.AdminService;
using HW13.BookService;
using HW13.Entities;
using HW13.Repository;
using System.Xml.Serialization;
Console.WriteLine("<---------Library--------->");


IUserService _userService = new UserService();
IBookRepository _bookRepository = new BookRepository();
IAdminService _adminService = new AdminService();   
bool flag = true;
bool exit = false;
bool trueexit = false;
while (trueexit is false)
{
    while (flag)
    {
        Console.WriteLine("<--- Library --->");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Register");
        Console.WriteLine("3. Exit");
        Console.Write("Please choose an option: ");
        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            Console.ReadKey();
            Console.Clear();
            continue;
        }

        switch (choice)
        {
            case 1: // Login
                Console.Write("Enter your username: ");
                string userName = Console.ReadLine();
                Console.Write("Enter your password: ");
                string Pass = Console.ReadLine();

                bool OnlineFlag = _userService.LogIn(userName, Pass);

                if (OnlineFlag)
                {
                    if (UserService.OnlineUser != null)
                    {
                        Console.WriteLine("LogIn Successful as User!");
                        exit = true; 
                        flag = false; 
                    }
                    else if (UserService.OnlineAdmin != null)
                    {
                        Console.WriteLine("LogIn Successful as Admin!");
                        exit = true;  
                        flag = false; 
                    }
                    else
                    {
                        Console.WriteLine("Error: User not found!");
                    }
                }
                else
                {
                    Console.WriteLine("Username or Password is incorrect!");
                }
                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();
                break;

            case 2:
                Console.Write("Enter your FirstName: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter your LastName: ");
                string LastName = Console.ReadLine();
                Console.Write("Enter your NationalCode: ");
                string nationalCode = Console.ReadLine();
                Console.Write("Enter your username: ");
                string UserName = Console.ReadLine();
                Console.Write("Enter your Password: ");
                string Password = Console.ReadLine();
                var user = new User()
                {
                    FirstName = firstName,
                    LastName = LastName,
                    NationalCode = nationalCode,
                    UserName = UserName,
                    Password = Password
                };
                var RegisterFlag = _userService.Register(user);

                if (RegisterFlag )
                {
                    Console.WriteLine("Register Successfull");
                    UserService.OnlineUser = user;
                    exit = true;
                    flag = false;
                }
                else
                {
                    Console.WriteLine("User already exist!!!");
                }
                Console.WriteLine("Press Any Key To Continiue...");
                Console.ReadKey();
                Console.Clear();
                break;

            case 3:
                trueexit = true;
                Console.WriteLine("Exiting the program.");
                Console.ReadKey();
                Console.Clear();
                break;

            default:
                Console.WriteLine("Invalid choice!!!");
                Console.ReadKey();
                Console.Clear();
                break;
        }

        if (trueexit)
            break;
    }

    while (exit is true && UserService.OnlineUser is not null && UserService.OnlineAdmin is null)
    {
        Console.WriteLine("<---- User console ---->");
        Console.WriteLine("1. Borrow Book");
        Console.WriteLine("2. Give back book");
        Console.WriteLine("3. Show all borrowed books");
        Console.WriteLine("4. Show all availble books");
        Console.WriteLine("5. LogOut");
        Console.Write("Please choose an option: ");

        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            continue;
        }

        switch (choice)
        {
            case 1:
                var existBook = _userService.ShowAllAvailbleBooks();
                if (!existBook)
                {
                    Console.WriteLine("no book availble!!!");
                    Console.WriteLine("Press Any Key To Continiue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                Console.Write("Enter book id:");
                if (!int.TryParse(Console.ReadLine(), out int BorrowBookId))
                {
                    Console.WriteLine("Invalid input for book id!!!");
                    Console.WriteLine("Press Any Key To Continiue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                var BorrowFlag =_userService.BorrowBook(UserService.OnlineUser.Id,BorrowBookId);
                if (BorrowFlag)
                {
                    Console.WriteLine("Book borrowed");
                    Console.WriteLine("Press Any Key To Continiue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                    
                }
                Console.WriteLine("Book cannot be borrowed");
                Console.WriteLine("Press Any Key To Continiue...");
                Console.ReadKey();
                Console.Clear();
                break;

            case 2:
                bool borrowList = _userService.ShowAllBorrowedBooks(UserService.OnlineUser.Id);
                if (!borrowList)
                {
                    Console.WriteLine("You dont have any books!!!");
                    Console.WriteLine("Press Any Key To Continiue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                Console.Write("Enter bookid that you wanna give back : ");
                if (!int.TryParse(Console.ReadLine(), out int GiveBackBookId))
                {
                    Console.WriteLine("Invalid input for book id!!!");
                    Console.WriteLine("Press Any Key To Continiue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                bool GiveBackFlag = _userService.GiveBackBook(UserService.OnlineUser.Id, GiveBackBookId);
                if (GiveBackFlag)
                {
                    Console.WriteLine("Book gived back successfully.");
                    Console.WriteLine("Press Any Key To Continiue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                Console.WriteLine("Book id is incorrect!!!");
                Console.WriteLine("Press Any Key To Continiue...");
                Console.ReadKey();
                Console.Clear();
                break;

            case 3:

                bool borrowedList = _userService.ShowAllBorrowedBooks(UserService.OnlineUser.Id);
                if (!borrowedList)
                {
                    Console.WriteLine("you dont have any books!!!");
                    Console.WriteLine("Press Any Key To Continiue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                Console.WriteLine("Press Any Key To Continiue...");
                Console.ReadKey();
                Console.Clear();
                break;

            case 4:
                var existsBook = _userService.ShowAllAvailbleBooks();
                if (!existsBook)
                {
                    Console.WriteLine("no book availble!!!");
                    Console.WriteLine("Press Any Key To Continiue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                Console.WriteLine("Press Any Key To Continiue...");
                Console.ReadKey();
                Console.Clear();
                break;

            case 5: 
                UserService.OnlineUser = null; 
                exit = false; 
                flag = true; 
                Console.WriteLine("Logged Out!!!");
                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();
                break;

            default:
                Console.WriteLine("Invalid choice!!!");
                Console.ReadKey();
                Console.Clear();
                break;
        }
    }
    while (exit is true && UserService.OnlineAdmin is not null && UserService.OnlineUser is null)
    {
        Console.WriteLine("<---- Admin console ---->");
        Console.WriteLine("1. Show all books with Status");
        Console.WriteLine("2. Show all users");
        Console.WriteLine("3. Add book");
        Console.WriteLine("4. Increase user license");
        Console.WriteLine("5. LogOut");
        Console.Write("Please choose an option: ");

        if (!int.TryParse(Console.ReadLine(), out int Adminchoice))
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            continue;
        }

        switch(Adminchoice)
        {
            case 1:
                var ShowBookFlag = _adminService.ShowBooks();
                if (!ShowBookFlag)
                {
                    Console.WriteLine("no book to show!!!");
                    Console.WriteLine("Press Any Key To Continiue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                Console.WriteLine("Press Any Key To Continiue...");
                Console.ReadKey();
                Console.Clear();
                break;

            case 2:
                var existUser = _adminService.ShowUsers();
                if (!existUser)
                {
                    Console.WriteLine("no user registered!!!");
                    Console.WriteLine("Press Any Key To Continiue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                Console.WriteLine("Press Any Key To Continiue...");
                Console.ReadKey();
                Console.Clear();
                break;

            case 3:
                Console.Write("Enter your Title: ");
                string Title = Console.ReadLine();
                Console.Write("Enter your Author: ");
                string Author = Console.ReadLine();
                Console.Write("Enter your Publisher: ");
                string Publisher = Console.ReadLine();
                bool CheckBook = _adminService.CheckBookExist(Title, Author, Publisher);
                if (CheckBook)
                {
                    Console.WriteLine("Book already exist!!!");
                    Console.WriteLine("Press Any Key To Continiue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                Console.Write("Enter your Price: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal Price))
                {
                    Console.WriteLine("Invalid input for Price!!!");
                    Console.WriteLine("Press Any Key To Continiue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                var newBook = new Book()
                {
                    Title = Title,
                    Author = Author,
                    Publisher = Publisher,
                    Price = Price
                };

                _adminService.AddBook(newBook);
                Console.WriteLine("Book added sucsessfully!!!");
                Console.WriteLine("Press Any Key To Continiue...");
                Console.ReadKey();
                Console.Clear();
                break;

            case 4: 
                Console.Write("Enter the user ID : ");
                if (!int.TryParse(Console.ReadLine(), out int userId))
                {
                    Console.WriteLine("Invalid user ID!");
                    break;
                }
                Console.Write("Enter the number days: ");
                if (!int.TryParse(Console.ReadLine(), out int Days))
                {
                    Console.WriteLine("Invalid number of days!");
                    break;
                }

                bool result = _adminService.IncreaseLicense(userId, Days);
                if (result)
                {
                    Console.WriteLine("Membership extended successfully!");
                    Console.WriteLine("Press Any Key To Continiue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Failed to extend membership.");
                    Console.WriteLine("Press Any Key To Continiue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }

            case 5: 
                UserService.OnlineAdmin = null; 
                exit = false; 
                flag = true; 
                Console.WriteLine("Logged Out!!!");
                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();
                break;

            default:
                Console.WriteLine("Invalid choice!!!");
                Console.ReadKey();
                Console.Clear();
                break;

        }
    }
}


