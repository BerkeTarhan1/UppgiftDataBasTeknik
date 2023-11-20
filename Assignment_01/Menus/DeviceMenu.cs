using Assignment_01.Entities;
using Assignment_01.Models;
using Assignment_01.Repositories;
using Assignment_01.Services;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Assignment_01.Menus;

internal class DeviceMenu
{
    private readonly DeviceEntity _device;
    private readonly DeviceRepository _deviceRepository;
    private readonly DeviceService _deviceService;

    public DeviceMenu (DeviceService deviceService)
    {
        _deviceService = deviceService;

       
    }


    public async Task ManageDevices()
    {

        Console.WriteLine("1 : View All Devices");
        Console.WriteLine("2 : Add New Device");
        Console.WriteLine("3 : Delete an Device");
        Console.WriteLine("4 : Update an device");
        
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
            case "3":
                Console.Clear();
                Console.WriteLine("Provide an id for the device you want to delete");
                var respons = int.Parse(Console.ReadLine()!);
                await DeleteAsync(respons);
                break;

            case "4":
                Console.Clear();
                Console.WriteLine("Provide the Id for the device you wish to update.");
                var respons2 = int.Parse(Console.ReadLine()!);

                await UpdateAsync(respons2);
                break;



        }
    }

    public async Task ListAllAsync()
    {
        var devices = await _deviceService.GetAllAsync();
        foreach (var device in devices)
        {
            Console.WriteLine($"{device.DeviceName} {device.DeviceCategory.CategoryName}");
            Console.WriteLine($"{device.DevicePrice} {device.CurrencyUnit.Unit}");
        }

        Console.ReadKey();
    }

    public async Task CreateAsync()
    {
        var form = new DeviceRegistrationForm();

        Console.Clear();
        Console.Write(" Device Name ");
        form.DeviceName = Console.ReadLine()!;

        Console.Write(" Device Description ");
        form.DeviceDescription = Console.ReadLine()!;

        Console.WriteLine("Device Category");
        form.DeviceCategory = Console.ReadLine()!;

        Console.Write(" Currency (sek) ");
        form.DevicePrice = decimal.Parse(Console.ReadLine()!);

        Console.Write(" Device Pricing Unit (st,pkt,tim ");
        form.Unit = Console.ReadLine()!;

        var result = await _deviceService.CreateProductAsync(form);

        if (result)
            Console.WriteLine("device has been added succesfully");
        else
            Console.WriteLine("The device can not be added");
    }

    public async Task DeleteAsync(int id)
    {
        var result = await _deviceService.DeleteDeviceAsync(id);
        if (result)
            Console.WriteLine($"Device was  {id} was deleted successfully.");
        else
            Console.WriteLine($"Could not locate an device with the current id: {id}.");

    }

    public async Task UpdateAsync(int id)
    {
        var device = await _deviceService.GetAllAsync();

        Console.Clear();
        Console.WriteLine("Choose to update one option");
        Console.WriteLine(" 1 : Device name/ device description");
        Console.WriteLine(" 2 : Device price etc");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":

                Console.Clear();

                Console.WriteLine("Device name");
                _device.DeviceName = Console.ReadLine()!;

                Console.WriteLine("Device Description");
                _device.DeviceDescription = Console.ReadLine()!;
                
                break;

            case "2":
                Console.Clear();
                Console.WriteLine("Device Price");
                _device.DevicePrice = decimal.Parse(Console.ReadLine()!);
                await _deviceService.UpdateAsync(id);

                break;

                


        }
    }



    
    
}

    



