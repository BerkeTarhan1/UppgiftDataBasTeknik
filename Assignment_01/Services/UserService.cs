using Assignment_01.Entities;
using Assignment_01.Models;
using Assignment_01.Repositories;

namespace Assignment_01.Services;

internal class UserService
{
    private readonly AddressRepository _addressRepositiry;
    private readonly UserRepository _userRepositiry;

    public UserService(AddressRepository addressRepository, UserRepository userRepositiry)
    {
        _addressRepositiry = addressRepository;
        _userRepositiry = userRepositiry;
    }

    public async Task <bool> CreateCustomerAsync(UserRegistrationForm form)
    { 
        //check user //om den inte finns vill vi dubbelkolla adress och användare
        if (!await _userRepositiry.ExistsAsync(x => x.Email == form.Email)) 
        {
            //check address
            AddressEntity addressEntity = await _addressRepositiry.GetAsync(x => x.StreetName == form.SreetName && x.PostalCode == form.PostalCode);
            addressEntity ??= await _addressRepositiry.CreateAsync(new AddressEntity { StreetName = form.SreetName, PostalCode = form.PostalCode, City = form.City});

            //create user
            UserEntity userEntity = await _userRepositiry.CreateAsync(new UserEntity { FirstName = form.FirstName, LastName = form.LastName, Email = form.Email, AddressId = addressEntity.Id });
            if (userEntity != null)
                return true;
            

            
        }

        return false;

        
    }

    public async Task <IEnumerable<UserEntity>> GetAllAsync()
    {
        var customers = await _userRepositiry.GetAllAsync();
        return customers;
    }
}
