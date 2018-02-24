using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Models.Tests
{
  [TestClass]
  public class ItemTest : IDisposable
 {
   public void Dispose()
   {
     Item.DeleteAll();
     Category.DeleteAll();
   }

    // public ItemTests()
    // {
    //
    //   DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=my_database_name_test;";
    // }
    //


    [TestMethod]
    public void GetDescription_FetchTheDescription_String()
    {
      //Arrange
      string controlDesc = "Go to the Moon";
      Item newItem = new Item("Go to the Moon", 2);

      //Act
      string result = newItem.GetDescription();

      //Assert
      Assert.AreEqual(result, controlDesc);
    }
  }
}
