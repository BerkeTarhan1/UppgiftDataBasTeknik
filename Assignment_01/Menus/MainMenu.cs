namespace Assignment_01.Menus;

internal class MainMenu
{
    private readonly UserMenu _userMenu;
    private readonly DeviceMenu _deviceMenu;

    public MainMenu(UserMenu userMenu, DeviceMenu deviceMenu)
    {
        _userMenu = userMenu;
        _deviceMenu = deviceMenu;
    }

    public async Task StartAsync()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Main Menu: ");
            Console.WriteLine("1: Manage Users");
            Console.WriteLine("2. Manage Devices");
            Console.Write("Choose one option ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await _userMenu.ManageUsers();
                    break;
                case "2":
                    await _deviceMenu.ManageDevices();
                    break;
                

            }

        } while (true);

    }

}
