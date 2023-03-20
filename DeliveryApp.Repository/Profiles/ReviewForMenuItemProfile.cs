using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Repository.Profiles
{
    public class ReviewForMenuItemProfile:BaseProfile
    {
        public ReviewForMenuItemProfile()
        {
            CreateMap<ReviewForMenuItem, ReviewForMenuItems>().ReverseMap()
                .ForPath(x => x.User.Image, opt => opt.MapFrom(x => x.User.Photos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<ReviewForMenuItems, ReviewForMenuItemDto>().ReverseMap();
        }
    }
}
