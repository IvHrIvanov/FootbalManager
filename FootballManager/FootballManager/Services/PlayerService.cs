using FootballManager.Contracts;
using FootballManager.Data.Models;
using FootballManager.ViewModels;
using Sms.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public PlayerService(
           IRepository _repo,
           IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }
        public (bool created, string error) Add(AddPlayerViewModel model)
        {
            bool created = false;
            string error = null;

            var (isValid, validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }
            Player player = new Player()
            {
                FullName = model.FullName,
                ImageUrl=model.ImageUrl,
                Position=model.Position,
                Speed=model.Speed,
                Endurance=model.Endurance,
                Description=model.Description,

            };
            try
            {
                
                repo.Add(player);
                repo.SaveChanges();
                created = true;
                   
            }
            catch (Exception)
            {
                error = "Cannot save Player";
                throw;
            }
            return (created, error);
        }

        public IEnumerable<AddPlayerViewModel> GetPlayers()
        {
            return repo.All<Player>()
                .Select(model => new AddPlayerViewModel()
                {
                    FullName = model.FullName,
                    ImageUrl = model.ImageUrl,
                    Position = model.Position,
                    Speed = model.Speed,
                    Endurance = model.Endurance,
                    Description = model.Description,
                })
                .ToList();
        }
    }
}
