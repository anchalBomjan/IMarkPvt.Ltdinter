using Application.DTOs;
using Application.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DeveloperService
    {

        private readonly IDeveloperRepository _developerrepository;
        public DeveloperService(IDeveloperRepository repository)
        {
            _developerrepository = repository;
        }

        public async Task<IEnumerable<DeveloperDTO>> GetAllDeveloperAsync()
        {

            var developers = await _developerrepository.GetAllDeveloperAsync();

            return developers.Select(d => new DeveloperDTO
            {
                Id = d.Id,
                Name = d.Name,
                Email = d.Email,
                YearsOfExperience = d.YearsOfExperience,
                EstimateIncome = d.EstimateIncome,
                //AddressId = d.AddressId,
                //Address = new AddressDTO
                //{
                //    Id = d.Address.Id,
                //    Country = d.Address.Country
                //}
                AddressId = d.AddressId, // Include AddressId for completeness
                Address = d.Address != null ? new AddressDTO
                {
                    Id = d.Address.Id,
                    Country = d.Address.Country
                } : null


            }).ToList();

        }
        public async Task<DeveloperDTO?> GetDeveloperById(int id)
        {



            var developer = await _developerrepository.GetDeveloperByIdAsync(id);
            if (developer == null)
                return null;

            //convert domain to Dto
            return new DeveloperDTO
            {
                Id = developer.Id,
                Name = developer.Name,
                Email = developer.Email,
                YearsOfExperience = developer.YearsOfExperience,
                EstimateIncome = developer.EstimateIncome,
                AddressId = developer.AddressId,
                //Address = new AddressDTO
                //{
                //    Id = developer.Address.Id,
                //    Country = developer.Address.Country
                //}
                Address = developer.Address != null ? new AddressDTO
                {
                    Id = developer.Address.Id,
                    Country = developer.Address.Country
                } : null

            };
        }

        public async Task AddDeveloperAsync(DeveloperCreateDTO developerDTOs)
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

        public async Task UpdateDeveloperAsync(int id, DeveloperCreateDTO developerDTOs)
        {
            var student = await _developerrepository.GetDeveloperByIdAsync(id);
            if (student == null)

                throw new Exception("Not Found");


            student.Name = developerDTOs.Name;
            student.Email = developerDTOs.Email;
            student.YearsOfExperience = developerDTOs.YearsOfExperience;
            student.EstimateIncome = developerDTOs.EstimateIncome;
            student.AddressId = developerDTOs.AddressId;
            await _developerrepository.UpdateDeveloperAsync(student);
        }

        public async Task DeleteDeveloperAsync(int id)
        {
            await _developerrepository.DeleteDeveloperAsync(id);
        }

    }
}
