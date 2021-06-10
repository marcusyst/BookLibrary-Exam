using BookLibrary.DAL.Entities;
using BookLibrary.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DAL.Repositories.Implementations
{
    public class SubscriberRepository: ISubscriberRepository
    {
        private readonly BibliotecaContext _bibliotecaContext;
        private readonly ILogger<SubscriberRepository> _logger;

        public SubscriberRepository(BibliotecaContext bibliotecaContext, ILogger<SubscriberRepository> logger)
        {
            _bibliotecaContext = bibliotecaContext;
            _logger = logger;
        }

        public void CreateSubscriber(Subscriber subscriberToAdd)
        {
            try
            {
                if (subscriberToAdd != null)
                {
                    _bibliotecaContext.Add(subscriberToAdd);
                    _bibliotecaContext.SaveChanges();
                }
                else throw new ArgumentNullException();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message + "\n Impossible to perform the action");
            }
        }
        public void UpdateSubscriber(Subscriber subscriber, int subscriberId)
        {
            try
            {
                Subscriber updateSubscriber = _bibliotecaContext.Subscribers.Find(subscriberId);

                if (updateSubscriber == null)
                    throw new ArgumentException();
                if (updateSubscriber.Name != null)
                    updateSubscriber.Name = subscriber.Name;
                if (updateSubscriber.Address != null)
                    updateSubscriber.Address = subscriber.Address;
                if (updateSubscriber.Email != null)
                    updateSubscriber.Email = subscriber.Email;
                if (updateSubscriber.NumberOfBooks != null)
                    updateSubscriber.NumberOfBooks = subscriber.NumberOfBooks;
                _bibliotecaContext.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n Impossible to perform the changes");
            }
        }

        public void DeleteSubscriber(int subscriberId)
        {
            try
            {
                Subscriber subscriberToDelete = _bibliotecaContext.Subscribers.Find(subscriberId);
                if (subscriberToDelete == null)
                    throw new ArgumentNullException();
                _bibliotecaContext.Remove(subscriberToDelete);
                _bibliotecaContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n Impossible to perform the action");
            }
        }

        public Subscriber GetSubscriberById(int id)
        {
            _logger.LogInformation($"Getting subscriber By Id");
            return _bibliotecaContext.Subscribers.FirstOrDefault(b => b.Id == id);
        }

        public List<Subscriber> GetSubscribers()
        {
            _logger.LogInformation($"Getting all subscribers");
            return _bibliotecaContext.Subscribers.ToList();
        }
    }
}
