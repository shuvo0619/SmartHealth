using SmartHealth.Data.Infrastructure;
using SmartHealth.Data.Repository;
using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHealth.Service.Services
{
    public interface IMessageService
    {
        void SaveMessage();
        void AddMessage(Message message);       
        List<Message> GetAllMessage();
        IEnumerable<Message> GetMessageList();
        Message GetMessageById(int id);
        Message GetMessage(int UserId);
        void UpdateMessage(Message msg);
    }

    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _MessageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MessageService(IMessageRepository messageRepository,
           IUnitOfWork unitOfWork )
        {
            this._MessageRepository = messageRepository;
            this._unitOfWork = unitOfWork;
        }

        public void SaveMessage()
        {
            _unitOfWork.Commit();
        }

        public void AddMessage(Message message)
        {
            _MessageRepository.Add(message);
            SaveMessage();
        }

        public List<Message> GetAllMessage()
        {
            return _MessageRepository.GetAll().ToList();
        }
        
        public Message GetMessageById(int id)
        {
            return _MessageRepository.Get(r => r.ConnectionId == id);
        }

        public Message GetMessage(int UserId)
        {
            return _MessageRepository.GetAll().Where(u => u.UserId == UserId).LastOrDefault();
        }

        public void UpdateMessage(Message msg)
        {
            _MessageRepository.Update(msg);
        }
        public IEnumerable<Message> GetMessageList()
        {
            return _MessageRepository.GetAll().ToList();
        }
    }
}