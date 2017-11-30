//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using BetizagastiGnocchi.BackEnd.DAL;
//using BetizagastiGnocchi.BackEnd.Domain.Entities;
//using BetizagastiGnocchi.BackEnd.Services.UserService;
//using System.Collections.Generic;
//using System.Linq;
//using System;

//using System.Linq.Expressions;

//namespace BetizagastiGnocchi.BackEnd.Test.Services
//{
//    [TestClass]
//    public class UserServiceTests:SetUp
//    {
//        [TestMethod()]
//        public void UpdateUserTest()
//        {
//            //Arrange 
//            var mockUnitOfWork = new Mock<IUnitOfWork>();
//            mockUnitOfWork.Setup(un => un.UserRepository.GetByID(It.IsAny<int>())).Returns(new User() { });
//            mockUnitOfWork.Setup(un => un.UserRepository.Update(It.IsAny<User>()));
//            mockUnitOfWork.Setup(un => un.Save());

//            IUserService userService = new UserService(mockUnitOfWork.Object);

//            //act
//            bool updated = userService.UpdateById
//                //UpdateById(0, new User() { });

//            //Assert
//            mockUnitOfWork.Verify(un => un.UserRepository.Update(It.IsAny<User>()), Times.Exactly(1));
//            mockUnitOfWork.Verify(un => un.Save(), Times.Exactly(1));
//            Assert.IsTrue(updated);
//        }
//        [TestMethod()]
//        public void UpdateUserGetNullTest()
//        {
//            //Arrange 
//            var mockUnitOfWork = new Mock<IUnitOfWork>();
//            mockUnitOfWork.Setup(un => un.UserRepository.GetByID(It.IsAny<int>())).Returns((User)null);

//            IUserService userService = new UserService(mockUnitOfWork.Object);

//            //act
//            bool updated = userService.UpdateById(0, new User() { });

//            //Assert
//            Assert.IsFalse(updated);
//        }
//        [TestMethod()]
//        public void UpdateUserWithDataTest()
//        {
//            //Arrange 
//            var mockUnitOfWork = new Mock<IUnitOfWork>();
//            mockUnitOfWork
//                .Setup(un => un.UserRepository.GetByID(It.IsAny<int>()))
//                .Returns(new User() { });
//            mockUnitOfWork.Setup(un => un.UserRepository.Update(It.IsAny<User>()));
//            mockUnitOfWork.Setup(un => un.Save());

//            IUserService userService = new UserService(mockUnitOfWork.Object);

//            //act
//            User userUdpdate = CreateTestUser();
//            bool updated = userService.UpdateById(1, userUdpdate);

//            //Assert
//            mockUnitOfWork.Verify(un => un.UserRepository.Update(It.IsAny<User>()), Times.Exactly(1));
//            mockUnitOfWork.Verify(un => un.Save(), Times.Exactly(1));
//            Assert.IsTrue(updated);
//        }
//        [TestMethod()]
//        public void DeleteUserTest()
//        {
//            //Arrange 
//            var mockUnitOfWork = new Mock<IUnitOfWork>();
//            mockUnitOfWork.Setup(un => un.UserRepository.GetByID(It.IsAny<int>())).Returns(() => new User() { });
//            mockUnitOfWork.Setup(un => un.UserRepository.Delete(It.IsAny<int>()));
//            mockUnitOfWork.Setup(un => un.Save());
//            List<User> listUsers = GetUsers();
//            mockUnitOfWork.Setup(un => un.UserRepository.Get(It.IsAny<Expression<Func<User, bool>>>(),
//                 It.IsAny<Func<IQueryable<User>, IOrderedQueryable<User>>>(), It.IsAny<string>()))
//                 .Returns(listUsers);

//            IUserService userService = new UserService(mockUnitOfWork.Object);

//            //act
//            bool delete = userService.DeleteById(0);

//            //Assert
//            mockUnitOfWork.Verify(un => un.UserRepository.Delete(It.IsAny<int>()), Times.Exactly(1));
//            mockUnitOfWork.Verify(un => un.Save(), Times.Exactly(1));
//            Assert.IsTrue(delete);
//        }


//        [TestMethod()]
//        public void DeleteUserOnlyOneAdminTest()
//        {
//            //Arrange 
//            var mockUnitOfWork = new Mock<IUnitOfWork>();
//            mockUnitOfWork
//                .Setup(un => un.UserRepository.GetByID(It.IsAny<int>()))
//                .Returns(() => new User() { });
//            mockUnitOfWork.Setup(un => un.UserRepository.Delete(It.IsAny<int>()));
//            mockUnitOfWork.Setup(un => un.Save());
//            List<User> listUsers = new List<User>();
//            listUsers.Add(CreateTestUser());
//            mockUnitOfWork.Setup(un => un.UserRepository.Get(It.IsAny<Expression<Func<User, bool>>>(),
//                 It.IsAny<Func<System.Linq.IQueryable<User>, IOrderedQueryable<User>>>(), It.IsAny<string>()))
//                 .Returns(listUsers);

//            IUserService userService = new UserService(mockUnitOfWork.Object);

//            //act            
//            EnumError errorCode = EnumError.InternalError;
//            try
//            {
//                bool delete = userService.DeleteById(0);

//            }
//            catch (BetizagestiGnocchiException ex)
//            {
//                errorCode = ex.ErrorCode;
//            }

//            //Assert
//            Assert.IsTrue(errorCode == EnumError.UserIsTheOnlyOneAdmin);
//        }

//        [TestMethod()]
//        public void DeleteUserGetNullTest()
//        {
//            //Arrange 
//            var mockUnitOfWork = new Mock<IUnitOfWork>();
//            mockUnitOfWork.Setup(un => un.UserRepository.GetByID(It.IsAny<int>())).Returns((User)null);

//            IUserService userService = new UserService(mockUnitOfWork.Object);

//            //act
//            bool updated = userService.DeleteById(0);

//            //Assert
//            Assert.IsFalse(updated);
//        }

//        [TestMethod()]
//        public void CreateUserWithSameNameTest()
//        {
//            //Arrange
//            var user = new User() { UserName = "TestName" };
//            var mockUnitOfWork = new Mock<IUnitOfWork>();
//            Expression<Func<User, bool>> filter = dto => dto.UserName == user.UserName;
//            mockUnitOfWork
//                 .Setup(un => un.UserRepository.Get(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<Func<IQueryable<User>, IOrderedQueryable<User>>>(), It.IsAny<string>()))
//                 .Returns(() => new List<User>() { user });


//            IUserService userService = new UserService(mockUnitOfWork.Object);

//            //Act  
//            EnumError errorCode = EnumError.InternalError;
//            try
//            {
//                string token;
//                int id = userService.CreateUser(user);

//            }
//            catch (BetizagestiGnocchiException ex)
//            {
//                errorCode = ex.ErrorCode;
//            }

//            //Assert
//            Assert.IsTrue(errorCode == EnumError.UserNameAlreadyRegistered);
//        }


//        [TestMethod()]
//        public void CreateUserTest()
//        {
//            //Arrange
//            var mockUnitOfWork = new Mock<IUnitOfWork>();
//            mockUnitOfWork.Setup(unR => unR.UserRepository.Insert(It.IsAny<User>()));
//            mockUnitOfWork.Setup(unR => unR.Save());

//            IUserService userService = new UserService(mockUnitOfWork.Object);

//            //Act
//            var user = new User();
//            string token;
//            int id = userService.CreateUser(user);

//            //Assert
//            mockUnitOfWork.VerifyAll();
//        }
//        [TestMethod()]
//        public void GetUserByIdTest()
//        {
//            //Arrange
//            var mockUnitOfWork = new Mock<IUnitOfWork>();

//            mockUnitOfWork.Setup(un => un.UserRepository.GetByID(It.IsAny<int>())).Returns(new User() { Id = 2 });

//            IUserService userService = new UserService(mockUnitOfWork.Object);

//            //Act
//            object returnedUsers = userService.GetbyId(2);

//            //Assert
//            mockUnitOfWork.VerifyAll();
//        }

//        [TestMethod()]
//        public void GetUserByIdNullTest()
//        {
//            //Arrange 
//            var mockUnitOfWork = new Mock<IUnitOfWork>();
//            User user = null;
//            mockUnitOfWork.Setup(un => un.UserRepository.GetByID(It.IsAny<int>())).Returns(user);

//            IUserService service = new UserService(mockUnitOfWork.Object);

//            //Act
//            EnumError errorCode = EnumError.InternalError;
//            try
//            {
//                object userDb = service.GetbyId(0);
//            }
//            catch (BetizagestiGnocchiException ex)
//            {
//                errorCode = ex.ErrorCode;
//            }

//            //Assert
//            Assert.IsTrue(errorCode == EnumError.UserNotFound);
//        }

//		[TestMethod()]
//		public void AccessToAction()
//		{
//			//Arrange 
//			var mockUnitOfWork = new Mock<IUnitOfWork>();
			
//			User user = null;
//			mockUnitOfWork.Setup(un => un.UserRepository.GetByID(It.IsAny<int>())).Returns(user);

//			IUserService service = new UserService(mockUnitOfWork.Object);
//			bool hasAccess = false;
//			//Act
//			EnumError errorCode = EnumError.InternalError;
//			try
//			{
//				hasAccess = service.HasAccess("xxxx","coso");
//			}
//			catch (BetizagestiGnocchiException ex)
//			{
//				errorCode = ex.ErrorCode;
//			}

//			//Assert
//			Assert.IsTrue(errorCode == EnumError.NotAuthorized);
//		}

//		[TestMethod()]
//		public void AccessToActionXXX()
//		{
//			//Arrange 
//			var mockUnitOfWork = new Mock<IUnitOfWork>();

//			User user = null;
//			mockUnitOfWork.Setup(un => un.UserRepository.GetByID(It.IsAny<int>())).Returns(user);

//			IUserService service = new UserService(mockUnitOfWork.Object);
//			bool hasAccess = false;
//			//Act
//			EnumError errorCode = EnumError.InternalError;
//			try
//			{
//				hasAccess = service.HasAccess("xxxx", "coso");
//			}
//			catch (BetizagestiGnocchiException ex)
//			{
//				errorCode = ex.ErrorCode;
//			}

//			//Assert
//			Assert.IsTrue(errorCode == EnumError.NotAuthorized);
//		}
//	}
//}
