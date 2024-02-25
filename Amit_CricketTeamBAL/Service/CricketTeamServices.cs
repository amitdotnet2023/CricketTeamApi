using Amit_CricketTeamBAL.Interfaces;
using Amit_CricketTeamBAL.ViewModel;
using Amit_CricketTeamDAL.DBContextF;
using Amit_CricketTeamDAL.Models;
using Amit_CricketTeamDAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amit_CricketTeamBAL.Service
{
    public class CricketTeamServices : ICricketTeamServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CricketTeamMaster> _criketteamMastersRepository;
        private readonly DBContextFiledb _dbContext;
        public CricketTeamServices(IUnitOfWork unitOfWork, DBContextFiledb dbContext,
            IRepository<CricketTeamMaster> criketteamMastersRepository)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
            _criketteamMastersRepository = criketteamMastersRepository;
        }

        public async Task<IEnumerable<CricketTeamMaster>> CriketTeamList()
        {
            return await _criketteamMastersRepository.GetAllAsync();
        }

        public async Task<int> CriketTeamRegistration(CriketTeamRegistrationVM entity)
        {
            var IsEmail = await _dbContext.CricketTeamMasters.Where(x => x.Email == entity.Email).FirstOrDefaultAsync();
            var IsContactNumber = await _dbContext.CricketTeamMasters.Where(x => x.ContactNumber == entity.ContactNumber).FirstOrDefaultAsync();

            if (_dbContext.CricketTeamMasters.Count() >= 16)
            {
                return 4; // Maximum registrations reached.
            }
            if (entity.Role.ToLower() == "team coach" && _dbContext.CricketTeamMasters.Any(u => u.Role.ToLower() == "team coach"))
            {
                return 5; //Team coach already registered.
            }

            if (entity.Role.ToLower() == "team coach" && _dbContext.CricketTeamMasters.Count(u => u.Role.ToLower() == "team coach") >= 1)
            {
                return 6; // Maximum team coaches reached.
            }

            if (entity.Role.ToLower() == "captain" && _dbContext.CricketTeamMasters.Any(u => u.Role.ToLower() == "captain"))
            {
                return 7; // Captain already registered.
            }

            if (entity.Role.ToLower() == "captain" && _dbContext.CricketTeamMasters.Count(u => u.Role.ToLower() == "captain") >= 1)
            {
                return 8; // Maximum captains reached.
            }


            if (IsEmail != null && IsContactNumber != null)
            {
                return 1; // email and ContactNumber exist
            }
            else if (IsEmail == null && IsContactNumber != null)
            {
                return 2; // email exist
            }
            else if (IsEmail != null && IsContactNumber == null)
            {
                return 3; // ContactNumber exist
            }
            else
            {

                CricketTeamMaster cricketTeamMaster = new()
                {
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    TotalMatchesPlayed = entity.TotalMatchesPlayed,
                    ContactNumber = entity.ContactNumber,
                    Email = entity.Email,
                    DateOfBirth = entity.DateOfBirth,
                    Height = entity.Height,
                    Weight = entity.Weight,
                    Role = entity.Role,
                    CreatedDate = DateTime.Now,
                    Password = "team1234",
                    IsActive = true
                };

                await _criketteamMastersRepository.AddAsync(cricketTeamMaster);
                await _unitOfWork.SaveChangesAsync();

                return 0;
            }

        }

        public async Task<int> TeamLogin(TeamLoginVM entity)
        {
            var IsEmail = await _dbContext.CricketTeamMasters.Where(x => x.Email == entity.Email).FirstOrDefaultAsync();
            var IsPassword = await _dbContext.CricketTeamMasters.Where(x => x.Email == entity.Email && x.Password == entity.Password).FirstOrDefaultAsync();

            if (IsEmail != null && IsPassword != null)
            {
                return 1; // login
            }
            else if (IsEmail == null && IsPassword != null)
            {
                return 2; // email wrong
            }
            else if (IsEmail != null && IsPassword == null)
            {
                return 3; // password wrong
            }
            return 0;
        }
    }
}
