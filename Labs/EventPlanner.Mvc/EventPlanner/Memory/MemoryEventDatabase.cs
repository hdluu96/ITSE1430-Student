/*
 * Hoa Luu
 * ITSE1430
 * December 8, 2018
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventPlanner.Memory
{
    /// <summary>Provides an implementation of <see cref="IEventDatabase"/> backed by memory.</summary>
    public class MemoryEventDatabase : IEventDatabase
    {
        
        public ScheduledEvent Add ( ScheduledEvent evnt )
        {
            Verify.ArgumentIsValidAndNotNull(nameof(evnt), evnt);

            // Cannot have duplicate event names 
            var existing = FindByName(evnt.Name);
            if (existing != null)
                throw new Exception("Event already exists.");

            var newEvnt = CloneEvent(evnt);
            evnt.Id = newEvnt.Id = id++;

            _items.Add(newEvnt);

            return evnt;
        }

        public ScheduledEvent Get ( int id ) => CloneEvent(_items.FirstOrDefault(i => i.Id == id));

        public void Remove ( int id )
        {
            Verify.ArgumentIsGreaterThan(nameof(id), id, 0);

            var item = FindById(id, false);
            if (item != null)
                _items.Remove(item);
        }

        public ScheduledEvent Update ( int id, ScheduledEvent evt )
        {
            Verify.ArgumentIsGreaterThan(nameof(id), id, 0);
            var item = FindById(id, true);

            //See if the new event already exists
            var existing = FindByName(evt.Name);
            if (existing != null && existing.Id != id)
                throw new Exception("Event already exists.");

            CopyEvent(item, evt);

            return CloneEvent(item);
        }

        #region Private Members

        private ScheduledEvent CloneEvent ( ScheduledEvent cEvnt )
        {
            if (cEvnt == null)
                return null;

            var item = new ScheduledEvent();
            CopyEvent(item, cEvnt);
            return item;
        }

        private void CopyEvent ( ScheduledEvent target, ScheduledEvent source )
        {
            target.Id = source.Id;
            target.Name = source.Name;
            target.Description = source.Description;
            target.StartDate = source.StartDate;
            target.EndDate = source.EndDate;
            target.IsPublic = source.IsPublic;
        }

        private ScheduledEvent FindById ( int id, bool notExist )
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null && notExist)
                throw new Exception("Event could not be found.");

            return item;
        }

        private ScheduledEvent FindByName ( string name ) => _items.FirstOrDefault(i => String.Compare(i.Name, name, true) == 0);

        public IEnumerable<ScheduledEvent> GetAll(EventCriteria criteria)
        {
            throw new NotImplementedException();
        }

        private readonly List<ScheduledEvent> _items = new List<ScheduledEvent>();
        private int id = 1;
        #endregion
    }
}
