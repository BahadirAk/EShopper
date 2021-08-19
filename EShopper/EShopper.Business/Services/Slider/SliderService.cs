using EShopper.Common.Middleware;
using EShopper.DataAccess.Entities;
using EShopper.DataAccess.Repositories;
using EShopper.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EShopper.Business.Services
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly CurrentUser _currentUser;
        public SliderService(ISliderRepository sliderRepository, CurrentUser currentUser)
        {
            _sliderRepository = sliderRepository;
            _currentUser = currentUser;
        }

        public List<SliderDto> GetList()
        {
            var sliderResult = _sliderRepository.GetList(x => x.IsDeleted == false && x.IsActive == true).ToList();

            return sliderResult.Select(x => new SliderDto
            {
                Id = x.Id,
                Description = x.Description,
                ImagePath = x.ImagePath,
                Name = x.Name
            }).ToList();
        }
    }
}
