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

namespace ContactManager
{
    public abstract class ContactDatabase : IContactDatabase
    {
        public void Add( Contact contact )
        {
            if (contact == null)
                return;

            AddCore(contact);
        }

        public IEnumerable<Contact> GetAll()
        {
            return GetAllCore();
        }

        public void Edit( string name, Contact contact )
        {
            if (String.IsNullOrEmpty(name))
                return;
            if (contact == null)
                return;

            var existing = FindByName(name);
            if (existing == null)
                return;

            EditCore(existing, contact);
        }

        public void Remove( string name )
        {
            if (String.IsNullOrEmpty(name))
                return;

            RemoveCore(name);
        }

        #region Protected Members
        protected abstract void AddCore( Contact contact );

        protected abstract void EditCore( Contact oldContact, Contact newContact );

        protected abstract Contact FindByName( string name );

        protected abstract IEnumerable<Contact> GetAllCore();

        protected abstract void RemoveCore( string name );

        #endregion

    }
}
