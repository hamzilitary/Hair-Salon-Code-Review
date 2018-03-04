using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {
    public void Dispose()
    {
      Client.DeleteAll();
      Stylist.DeleteAll();
    }

    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=hair_salon_test";
    }
    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Recipe()
  {
    // Arrange
    Client firstClient = new Client("Bob");
    Client secondClient = new Client("Bob");

    //Act
    firstClient.Save();
    secondClient.Save();

    // Assert
    Assert.AreEqual(true, firstClient.GetDescription().Equals(secondClient.GetDescription()));
  }

  [TestMethod]
  public void Find_FindsClientInDatabase_Client()
  {
    //Arrange
    Client testClient = new Client("Bob");
    testClient.Save();

    //Act
    Client foundClient = Client.Find(testClient.GetId());

    //Assert
    Assert.AreEqual(testClient, foundClient);
  }
    [TestMethod]
    public void Delete_DeleteAllClientsInDatabase_void()
    {
      //arrange
       Client newClient = new Client("Bob");

       //act
       Client.DeleteAll();
       int result = Client.GetAll().Count;

       //assert
       Assert.AreEqual(0, result);
    }

  }
}
