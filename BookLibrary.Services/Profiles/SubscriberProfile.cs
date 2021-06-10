using AutoMapper;
using BookLibrary.DAL.Entities;
using BookLibrary.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Services.Profiles
{
    class SubscriberProfile: Profile
    {
        public SubscriberProfile()
        {
            CreateMap<Subscriber, SubscriberModel>().ReverseMap();
        }
    }
}
