using SmartHealth.Data.Infrastructure;
using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartHealth.Data.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        SmartHealthEntities _context;
        public MessageRepository(DbContext context)
            : base(context)
        {
            _context = (SmartHealthEntities)context;
        }
    }

    public interface IMessageRepository : IRepository<Message>
    {

    }
}