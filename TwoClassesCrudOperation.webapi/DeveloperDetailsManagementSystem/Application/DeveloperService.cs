using DeveloperDetailsManagementSystem.Application.DTOs;
using DeveloperDetailsManagementSystem.Domain;
using DeveloperDetailsManagementSystem.Infrastructure;

namespace DeveloperDetailsManagementSystem.Application
{
    public class DeveloperService
    {
        private readonly IDeveloperRepository _developerrepository;
        public DeveloperService(IDeveloperRepository repository)
        {
            _developerrepository = repository;
        }

        public async Task<IEnumerable<DeveloperDTOs>> GetAllDeveloperAsync()
        {

            var developers=await _developerrepository.GetAllDeveloperAsync();

            return developers.Select(d => new DeveloperDTOs
            {
                Id = d.Id,
                Name = d.Name,
                Email = d.Email,
                YearsOfExperience = d.YearsOfExperience,
                EstimateIncome = d.EstimateIncome,
              //  AddressId = d.AddressId,
                Address = new AddressDTOs
                {
                   Id = d.Address.Id,
                    Country = d.Address.Country
                }
            }).ToList();

        }
        public async Task<DeveloperDTOs?> GetDeveloperById(int id)
        {
 


            var developer = await _developerrepository.GetDeveloperByIdAsync(id);
            if (developer == null)
                return null;

            return new DeveloperDTOs
            {
                Id = developer.Id,
                Name = developer.Name,
                Email = developer.Email,
                YearsOfExperience = developer.YearsOfExperience,
                EstimateIncome = developer.EstimateIncome,
                AddressId = developer.AddressId,
                Address = new AddressDTOs
                {
                    Id = developer.Address.Id,
                    Country = developer.Address.Country
                }
            };
        }

        public async Task AddDeveloperAsync(DeveloperCreateDTOs developerDTOs)
        {
            //convert DTOs to Domain Model
            var developer = new Developer
            {

                Name = developerDTOs.Name,
                Email = developerDTOs.Email,
                YearsOfExperience = developerDTOs.YearsOfExperience,
                EstimateIncome = developerDTOs.EstimateIncome,
                AddressId = developerDTOs.AddressId



            };
            await _developerrepository.AddDeveloperAsync(developer);
           
        }

        public async Task UpdateDeveloperAsync(int id, DeveloperCreateDTOs developerDTOs)
        {
            var student= await _developerrepository.GetDeveloperByIdAsync(id);
            if (student == null)
            
                throw new Exception("Not Found");

            
            student.Name=developerDTOs.Name;
            student.Email=developerDTOs.Email;
            student.YearsOfExperience=developerDTOs.YearsOfExperience;
            student.EstimateIncome=developerDTOs.EstimateIncome;
            student.AddressId=developerDTOs.AddressId;
            await _developerrepository.UpdateDeveloperAsync(student);
        }

        public async Task DeleteDeveloperAsync(int id)
        {
            await _developerrepository.DeleteDeveloperAsync(id);
        }


    }
}
