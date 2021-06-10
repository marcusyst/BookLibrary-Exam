using AutoMapper;
using BookLibrary.DAL.Entities;
using BookLibrary.DAL.Repositories.Interfaces;
using BookLibrary.Services.Models;
using BookLibrary.Services.Services.Interfaces;
using System.Collections.Generic;

namespace BookLibrary.Services.Services.Implementations
{
    public class SubscriberService: ISubscriberService
    {
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IMapper _mapper;

        public SubscriberService(ISubscriberRepository subscriberRepository, IMapper mapper)
        {
            _subscriberRepository = subscriberRepository;
            _mapper = mapper;
        }

        public void CreateSubscriber(SubscriberModel subscriberToAdd)
        {
            Subscriber subscriber = _mapper.Map<Subscriber>(subscriberToAdd);
            _subscriberRepository.CreateSubscriber(subscriber);
        }

        public void UpdateSubscriber(SubscriberModel subscriberModel, int subscriberId)
        {
            Subscriber subscriber = _mapper.Map<Subscriber>(subscriberModel);
            _subscriberRepository.UpdateSubscriber(subscriber, subscriberId);
        }

        public void DeleteSubscriber(int subscriberId)
        {
            _subscriberRepository.DeleteSubscriber(subscriberId);
        }

        public SubscriberModel GetSubscriberById(int id)
        {
            Subscriber subscriber = _subscriberRepository.GetSubscriberById(id);
            SubscriberModel subscriberModel = _mapper.Map<SubscriberModel>(subscriber);
            return subscriberModel;
        }

        public List<SubscriberModel> GetSubscribers()
        {
            List<Subscriber> subscribers = _subscriberRepository.GetSubscribers();
            List<SubscriberModel> subscriberModels = _mapper.Map<List<SubscriberModel>>(subscribers);
            return subscriberModels;
        }
    }
}
