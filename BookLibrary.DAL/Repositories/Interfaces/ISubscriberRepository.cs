using BookLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DAL.Repositories.Interfaces
{
    public interface ISubscriberRepository
    {
        public void CreateSubscriber(Subscriber blogToAdd);
        public void UpdateSubscriber(Subscriber blog, int blogId);
        public void DeleteSubscriber(int blogId);

        public List<Subscriber> GetSubscribers();
        public Subscriber GetSubscriberById(int id);

    }
}
