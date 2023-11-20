using Assignment_01.Models;
using Assignment_01.Services;

namespace Assignment_01.Menus;

internal class UserMenu
{
    private readonly UserService _userService;

    public UserMenu(UserService userService)
    {
        _userService = userService;
    }

    public async Task ManageUsers()
    {

        Console.WriteLine("1 : View All Users");
        Console.WriteLine("2 : Add Users");
        Console.WriteLine("Choose one option");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await ListAllAsync();
                break;
            case "2":
                await CreateAsync();
                break;


        }
    }

    public async Task CreateAsync()
    {
        var form = new UserRegistrationForm();
        
        Console.Clear();
        Console.Write("First Name: ");
        form.FirstName = Console.ReadLine()!;

        Console.Clear();
        Console.Write("Last Name: ");
        form.LastName = Console.ReadLine()!;

        Console.Clear();
        Console.Write("Email: ");
        form.Email = Console.ReadLine()!;

        Console.Clear();
        Console.Write("Street Name: ");
        form.SreetName = Console.ReadLine()!;

        Console.Clear();
        Console.Write("Postal Code: ");
        form.PostalCode = Console.ReadLine()!;

        Console.Clear();
        Console.Write("City: ");
        form.City = Console.ReadLine()!;

        var result = await _userService.CreateCustomerAsync(form);

        if (result)
            Console.WriteLine("User has been created succesfully");
        else
            Console.WriteLine("User can not be created");

    }

    public async Task ListAllAsync()
    {
        var users = await _userService.GetAllAsync();
        foreach (var user in users)
        {
            Console.WriteLine($"{user.FirstName} {user.LastName}");
            Console.WriteLine($"{user.Address.StreetName} {user.Address.PostalCode} {user.Address.City}");
        }
        
        Console.ReadKey();
    }
}

