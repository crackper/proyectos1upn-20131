using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBSystem.Repository
{
    public abstract class MasterRepository
    {
        private DBSystemContext _context;

        public MasterRepository()
        {
            if (_context == null)
            {
                _context = new DBSystemContext();
            }
        }

        protected DBSystemContext Context
        {
            get { return _context; }
        }
    }
}
