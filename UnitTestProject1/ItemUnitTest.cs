using DAL.Interface;
using DAL.Memory;
using FluentAssertions;
using Logic;
using Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class ItemUnitTest
    {
        private List<Item> ListOfItems;
        private MockItem ListOfMockItems;
        private ItemLogic itemLogic;

        [TestInitialize]
        public void Setup_Test()
        {
            ListOfItems = new List<Item>();
            ListOfMockItems = new MockItem();
            foreach (var item in ListOfMockItems.ItemsMock)
            {
                ListOfItems.Add(new Item(item));
            };
        }

        [TestMethod]
        public void Get_All_Items_Test_Succesfull_Logic()
        {
            Mock<iItem> mockItems = new Mock<iItem>();
            mockItems.Setup(x => x.GetItem()).Returns(ListOfMockItems.ItemsMock);

            itemLogic = new ItemLogic(mockItems.Object);
            var result = itemLogic.GetItem();

            Assert.AreEqual(result[1].ItemID, ListOfMockItems.ItemsMock[1].ItemID);
        }

        [TestMethod]
        public void Get_All_Items_Test_Unsuccesfull_Logic()
        {
            Mock<iItem> mockItems = new Mock<iItem>();
            mockItems.Setup(x => x.GetItem()).Returns(ListOfMockItems.ItemsMock);

            itemLogic = new ItemLogic(mockItems.Object);
            var result = itemLogic.GetItem();

            Assert.AreNotEqual(result[1].ItemID, ListOfMockItems.ItemsMock[3].ItemID);
        }

        [TestMethod]
        public void Get_All_Items_Test_Succesfull_Interface()
        {
            Mock<iItem> mockItems = new Mock<iItem>();
            var result = mockItems.Setup(x => x.GetItem()).Returns(ListOfMockItems.ItemsMock);
            result.Should().NotBeNull();
        }

        [TestMethod]
        public void Add_Item_Test_Succesfull_Interface()
        {
            var ListOfItems = new MockItem();
            Mock<iItem> mockItems = new Mock<iItem>();
            var result = mockItems.Setup(x => x.AddItem(ListOfItems.ItemsMock[1])).Returns(true);
            result.Should().NotBeNull();
        }

        [TestMethod]
        public void Remove_Item_Test_Succesfull_Interface()
        {
            Mock<iItem> mockItems = new Mock<iItem>();
            var result = mockItems.Setup(x => x.RemoveItem(ListOfMockItems.ItemsMock[1].ItemID)).Returns(true);
            result.Should().NotBeNull();
        }

        [TestMethod]
        public void Get_Item_By_ID_Succesfull_Interface()
        {
            Mock<iItem> mockItems = new Mock<iItem>();
            var result = mockItems.Setup(x => x.GetItemByID(ListOfMockItems.ItemsMock[1].ItemID)).Returns(ListOfMockItems.ItemsMock[1]);
            result.Should().NotBeNull();
        }

        [TestMethod]
        public void Edit_Item_Test_Succesfull_Interface()
        {
            Mock<iItem> mockItems = new Mock<iItem>();
            var result = mockItems.Setup(x => x.GetItem()).Returns(ListOfMockItems.ItemsMock);
            result.Should().NotBeNull();
        }
    }
}
