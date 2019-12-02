using DAL.Interface;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQLcontext
{
    public class ReferenceContext : iReference
    {
        public bool AddReference(ReferenceDTO referenceDTO)
        {
            throw new NotImplementedException();
        }

        public bool EditReference(ReferenceDTO reference)
        {
            throw new NotImplementedException();
        }

        public List<ReferenceDTO> GetReference()
        {
            throw new NotImplementedException();
        }

        public ReferenceDTO GetReferenceByID(string id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveReference(string id)
        {
            throw new NotImplementedException();
        }
    }
}
