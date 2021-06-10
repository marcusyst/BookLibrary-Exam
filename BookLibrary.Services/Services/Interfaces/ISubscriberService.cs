using BookLibrary.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Services.Services.Interfaces
{
    public interface ISubscriberService
    {
        public void CreateSubscriber(SubscriberModel subscriberToAdd);
        public void UpdateSubscriber(SubscriberModel subscriber, int subscriberId);
        public void DeleteSubscriber(int subscriberId);

        public List<SubscriberModel> GetSubscribers();
        public SubscriberModel GetSubscriberById(int id);
    }
}
