using System.Collections.Generic;
using System.Linq;
using Flock.Facade.Interfaces;
using Flock.Models;
using System;


namespace Flock.Facade.Concrete
{
    public class MessageFacade : IMessageFacade
    {
        //private readonly IMessageRepository _messageRepository;

        //public MessageFacade(IMessageRepository messageRepository)
        //{
        //    _messageRepository = messageRepository;
        //}

        //public void SaveMessage(FlockMessage message)
        //{
        //    message.CreateDateTime = DateTime.Now;
        //    _messageRepository.Add(message);
        //}

        //public void UpdateMessage(FlockMessage message)
        //{
        //    _messageRepository.Update(message);
        //}


        //public IEnumerable<FlockMessage> GetAllMessages()
        //{
        //    var messages = _messageRepository.GetAll();
        //    var flockMessages = messages as FlockMessage[] ?? messages.ToArray();
        //    foreach (var message in flockMessages)
        //    {
        //        TimeSpan timeSpan = DateTime.Now.Subtract(message.CreateDateTime);
        //        if (timeSpan.Days > 2)
        //        {
        //            message.LastUpdated = message.CreateDateTime.ToString("MMMM dd, yyyy") + " at " +
        //                                  message.CreateDateTime.ToString("hh:mm tt");
        //        }
        //        else if (timeSpan.Days > 0)
        //        {
        //            message.LastUpdated = timeSpan.Days + " days ago";
        //        }
        //        else if (timeSpan.Hours > 0)
        //        {
        //            message.LastUpdated = timeSpan.Hours + " hours ago";
        //        }
        //        else if (timeSpan.Minutes > 0)
        //        {
        //            message.LastUpdated = timeSpan.Minutes + " minutes ago";
        //        }
        //        else
        //        {
        //            message.LastUpdated = "Few seconds ago";
        //        }

        //    }
        //    return flockMessages.OrderByDescending(x => x.CreateDateTime);
        //}
        public void SaveMessage(FlockMessage message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FlockMessage> GetAllMessages()
        {
            return null;
        }

        public void UpdateMessage(FlockMessage message)
        {
            throw new NotImplementedException();
        }
    }
}