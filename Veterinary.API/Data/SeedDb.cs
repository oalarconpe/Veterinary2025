using Veterinary.API.Helpers;
using Veterinary.Shared.Entities;
using Veterinary.Shared.Enums;

namespace Veterinary.API.Data
{
    public class SeedDb
    {
private readonly DataContext _context;
private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context , IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;

        }


        public async Task SeedDbAsync() {

            await _context.Database.EnsureCreatedAsync();
            await CheckPetTypesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("123", "OAP", "OAP", "CR 78 9687", " tragrammigrako-1348@yopmail.com", UserType.Admin);




        }

        private async Task<User> CheckUserAsync(string document, string firstName, string lastName,  string direccion, string email, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {

                    Document = document,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Direccion = direccion,


                    UserName = email,


                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }


        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckPetTypesAsync()
        {
            if (!_context.PetTypes.Any())
            {
                _context.PetTypes.Add(new PetType { Name = "Dog" });
                _context.PetTypes.Add(new PetType { Name = "Cat" });
                _context.PetTypes.Add(new PetType { Name = "Bird" });
            }
        }



    }

}