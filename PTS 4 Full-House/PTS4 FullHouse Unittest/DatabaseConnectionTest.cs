using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PTS4_FullHouse_Unittest;
using PTS_4_Full_House;
using System.Data.SqlClient;

namespace PTS4_FullHouse_Unittest
{
    [TestClass]
    public class UnitTest1
    {
        DatabaseConnection dbConnection = null;

        [TestInitialize]
        public void testInit() {
            dbConnection = new DatabaseConnection();
        }
        [TestMethod]
        public void testGetUser()
        {
            List<User> users = dbConnection.getUsers();
            Assert.AreEqual(true, users.Count > 0);
        }
        [TestMethod]
        public void makeNotification()
        {
            dbConnection.makeNotification("test", "unittest", 2);
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void makeNotificationNullTitleExpected()
        {
            dbConnection.makeNotification(null, "unittest", 2);
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void makeNotificationNullMessageExpected()
        {
            dbConnection.makeNotification("test", null, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void makeNotificationNullUserExpected()
        {
            dbConnection.makeNotification("test", "unittest", 0);
        }

        [TestMethod]
        public void makeUserTest()
        {
            dbConnection.createNewUser(new User(0,"Wang","","Qunfong","Qunfong","test1",null,null));
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void makeUserTestLastNameNullException()
        {
            dbConnection.createNewUser(new User(0, null, "", "Qunfong", "Qunfong", "test1", null, null));
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void makeUserTestFirstNameNullException()
        {
            dbConnection.createNewUser(new User(0, "Wang", null, "", "Qunfong", "test1", null, null));
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void makeUserTestUserNameNullException()
        {
            dbConnection.createNewUser(new User(0, "Wang", "", "Qunfong", null, "test1", null, null));
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void makeUserPasswordNullException()
        {
            dbConnection.createNewUser(new User(0, "Wang", "", "Qunfong", "Qunfong", null, null, null));
        }
    }

}
