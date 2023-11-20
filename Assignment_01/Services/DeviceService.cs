using Assignment_01.Entities;
using Assignment_01.Models;
using Assignment_01.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Assignment_01.Services;

internal class DeviceService
{
    private readonly DeviceEntity _device;
    private readonly DeviceRepository _deviceRepository;
    private readonly CurrencyUnitRepository _currencyUnitRepository;
    private readonly DeviceCategoryRepository _deviceCategoryRepository;

    public DeviceService(DeviceRepository deviceRepository, CurrencyUnitRepository currencyUnitRepository, DeviceCategoryRepository deviceCategoryRepository)
    {
        _deviceRepository = deviceRepository;
        _currencyUnitRepository = currencyUnitRepository;
        _deviceCategoryRepository = deviceCategoryRepository;
    }

    

    public async Task<bool> CreateProductAsync(DeviceRegistrationForm form)
    {
        if(! await _deviceRepository.ExistsAsync(x => x.DeviceName == form.DeviceName))
        {
            // check if pricing unit exists else create
            var currencyUnitEntity = await _currencyUnitRepository.GetAsync(x => x.Unit == form.Unit);
           currencyUnitEntity ??= await _currencyUnitRepository.CreateAsync(new CurrencyUnitEntity { Unit = form.Unit });

            //check if category exists else create
            var deviceCategoryEntity = await _deviceCategoryRepository.GetAsync(x => x.CategoryName == form.DeviceCategory);
            deviceCategoryEntity ??= await _deviceCategoryRepository.CreateAsync(new DeviceCategoryEntity { CategoryName = form.DeviceCategory });


            //create product
            var deviceEntity = await _deviceRepository.CreateAsync(new DeviceEntity
            {
                DeviceName = form.DeviceName,
                DeviceDescription = form.DeviceDescription,
                DevicePrice = form.DevicePrice,
                CurrencyUnitId = currencyUnitEntity.Id,
                DeviceCategoryId = deviceCategoryEntity.Id
            });

            if (deviceEntity != null)
                return true;

        }

        return false;
    }

    public async Task<IEnumerable<DeviceEntity>> GetAllAsync()
    {
        var devices = await _deviceRepository.GetAllAsync();
        return devices;
    }

    public async Task<IEnumerable<CurrencyUnitEntity>> GetAllPricingUnitsAsync()
    {
        var units = await _currencyUnitRepository.GetAllAsync();
        return units;
    }

    public async Task<bool> DeleteDeviceAsync(int id)
    {
        var result = await _deviceRepository.DeleteAsync(x => x.Id == id);
        return result;
    }

    public async Task UpdateAsync(int id)
    {
        try
        {
            var devices = await _deviceRepository.GetAsync(x => x.Id == id);
            if (devices == null)
            {
                Console.Clear();
                Console.WriteLine("Update was done correctly");
                Console.ReadKey();
                await _deviceRepository.UpdateAsync(devices);
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Update was not done correctly");
                Console.ReadKey();
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }


}
