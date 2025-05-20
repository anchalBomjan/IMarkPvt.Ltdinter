using DeveloperDetailsManagementSystem.Application.DTOs;
using DeveloperDetailsManagementSystem.Domain;

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
            var developers = await _developerrepository.GetAllDeveloperAsync();

            return developers.Select(d => new DeveloperDTOs
            {
                Id = d.Id,
                Name = d.Name,
                Email = d.Email,
                YearsOfExperience = d.YearsOfExperience,
                EstimateIncome = d.EstimateIncome,
                Address=new AddressDTOs
                {
                    Country=d.Address.Country,
                }
                
            }).ToList();
        }
        public async Task<DeveloperDTOs?> GetDeveloperById(int id)
        {
            var student=await _developerrepository.GetDeveloperByIdAsync(id);
            if(student == null)
            {
                return null;

            }
            return new DeveloperDTOs
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                YearsOfExperience = student.YearsOfExperience,
                EstimateIncome = student.EstimateIncome,
                Address = new AddressDTOs
                {
                    Country = student.Address.Country
                }

            };
        }

        public async Task AddDeveloperAsync(DeveloperDTOs developerDTOs)
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

        public async Task UpdateDeveloperAsync(int id, DeveloperDTOs developerDTOs)
        {
            var student= await _developerrepository.GetDeveloperByIdAsync(id);
            if (student == null)
            
                throw new Exception("Not Found");

            
            student.Name=developerDTOs.Name;
            student.Email=developerDTOs.Email;
            student.YearsOfExperience=developerDTOs.YearsOfExperience;
            student.EstimateIncome=developerDTOs.EstimateIncome;
            student.AddressId=developerDTOs.AddressId;
        }

        public async Task DeleteDeveloperAsync(int id)
        {
            await _developerrepository.DeleteDeveloperAsync(id);
        }


    }
}
