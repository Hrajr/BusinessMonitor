using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interface.DTO;

namespace DAL.Interface
{
    public interface iItem
    {
        bool AddItem(ItemDTO item);
        bool RemoveItem(string id);
        ItemDTO GetItemByID(string id);
        List<ItemDTO> GetItem();
        bool EditItem(ItemDTO item);
    }
}
