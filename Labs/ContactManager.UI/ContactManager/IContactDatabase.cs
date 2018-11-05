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
    public interface IContactDatabase
    {
        void Add( Contact contact );

        void Edit( string name, Contact contact );

        IEnumerable<Contact> GetAll();

        void Remove( string name );
    }
}
