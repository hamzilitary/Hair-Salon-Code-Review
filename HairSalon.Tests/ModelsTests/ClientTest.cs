using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Models.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
 {
   public void Dispose()
   {
     Client.DeleteAll();
     Stylist.DeleteAll();
   }

    public ClientTests()
    {

      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=hair_salon_test;";
    }



    [TestMethod]
    public void GetDescription_FetchTheDescription_String()
    {
      //Arrange
      string controlDesc = "Go to the Moon";
      Client newClient = new Client("Go to the Moon", 2);

      //Act
      string result = newClient.GetDescription();

      //Assert
      Assert.AreEqual(result, controlDesc);
    }
  }
}
