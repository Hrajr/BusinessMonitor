using DAL.Interface;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQLcontext
{
    public class ItemContext : iItem
    {
        public bool AddItem(ItemDTO item)
        {
            throw new NotImplementedException();
        }

        public List<ItemDTO> GetItem()
        {
            throw new NotImplementedException();
        }

        public ItemDTO GetItemByID(string id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(string id)
        {
            throw new NotImplementedException();
        }

        public bool EditItem(ItemDTO item)
        {
            throw new NotImplementedException();
        }

        public bool OpenItem(string id)
        {
            throw new NotImplementedException();
        }
    }
}
