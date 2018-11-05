/* 
 * Hoa Luu
 * ITSE 1430
 * November 03, 2018
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Memory
{
    public class MemoryContactDatabase : ContactDatabase
    {
        protected override void AddCore( Contact contact )
            =>_items.Add(contact);

        protected override IEnumerable<Contact> GetAllCore()
        {
            return from item in _items
                   select new Contact()
                   {
                       Name = item.Name,
                       EmailAddress = item.EmailAddress,
                   };
        }

        protected override void EditCore(Contact oldContact, Contact newContact)
        {
            _items.Remove(oldContact);

            _items.Add(newContact);
        }

        protected override Contact FindByName(string name)
        {
            return (from m in _items
                    where String.Compare(name, m.Name, true) == 0
                    select m).FirstOrDefault();
        }

        protected override void RemoveCore(string name)
        {
            var contact = FindByName(name);
            if (contact != null)
                _items.Remove(contact);
        }

        private List<Contact> _items = new List<Contact>();
    }
}
