using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Utilities
{
    public interface INotificationService
    {
        Task Subscribe<T>(Action<T> handler);
        Task Publish<T>(T payload);
    }

    public class NotificationService : INotificationService
    {
        private readonly Dictionary<Type, List<Action<object>>> _handlers = new Dictionary<Type, List<Action<object>>>();

        public Task Subscribe<T>(Action<T> handler)
        {
            if (!_handlers.ContainsKey(typeof(T)))
            {
                _handlers.Add(typeof(T), new List<Action<object>>());
            }

            _handlers[typeof(T)].Add(obj => handler((T)obj));
            return Task.CompletedTask;
        }

        public Task Publish<T>(T payload)
        {
            if (_handlers.ContainsKey(typeof(T)))
            {
                foreach (var handler in _handlers[typeof(T)])
                {
                    handler(payload);
                }
            }
            return Task.CompletedTask;
        }
    }
}