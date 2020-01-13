using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface iReference
    {
        bool RemoveReference(string id);
        bool EditReference(ReferenceDTO reference);
        List<ReferenceDTO> GetReference();
        ReferenceDTO GetReferenceByID(string id);
        bool AddReference(ReferenceDTO referenceDTO);
        bool CheckReference(string id);
    }
}
