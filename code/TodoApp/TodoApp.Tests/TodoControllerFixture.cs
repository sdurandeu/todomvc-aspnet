namespace TodoApp.Tests
{
    using Controllers;
    using Microsoft.AspNet.Identity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Moq;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Security.Claims;
    using System.Web.Http.Results;

    [TestClass]
    public class TodoControllerFixture
    {
        [TestMethod]
        public void ShouldGetOne()
        {
            var applicationUserManager = this.GetApplicationUserManagerMock();
            var applicationDbContext = this.GetApplicationDbContextMock();

            var todoController = new TodoController(applicationUserManager.Object, applicationDbContext.Object);

            var todo = todoController.GetOne(1).Result as OkNegotiatedContentResult<ToDo>;

            Assert.IsNotNull(todo);
            Assert.AreEqual(todo.Content.Id, 1);
            Assert.AreEqual(todo.Content.User.Id, "1");
        }

        [TestMethod]
        public void ShouldGetByUserId()
        {
            var applicationUserManager = this.GetApplicationUserManagerMock();
            var applicationDbContext = this.GetApplicationDbContextMock();

            var todoController = new TodoController(applicationUserManager.Object, applicationDbContext.Object);

            var todos = todoController.GetByUserId().Result as OkNegotiatedContentResult<List<ToDo>>;

            Assert.IsNotNull(todos);
            Assert.AreEqual(todos.Content.Count(), 2);
        }

        private Mock<ApplicationUserManager> GetApplicationUserManagerMock()
        {
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            
            var applicationUserMock = new Mock<ApplicationUser>();
            applicationUserMock.Setup(u => u.Id).Returns("1");

            var userManager = new Mock<ApplicationUserManager>(userStore.Object);
            userManager.Setup(u => u.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(applicationUserMock.Object);

            return userManager;
        }

        private Mock<ApplicationDbContext> GetApplicationDbContextMock()
        {
            // single user
            var appUser = new ApplicationUser();
            appUser.Id = "1";

            var data = new List<ToDo>  {
                    new ToDo { Id = 0, Title = "Todo 1", Completed = false, User = appUser },
                    new ToDo { Id = 1, Title = "Todo 2", Completed = true, User = appUser },
                  }.AsQueryable();

            var mockSet = new Mock<DbSet<ToDo>>();

            mockSet.As<IDbAsyncEnumerable<ToDo>>()
               .Setup(m => m.GetAsyncEnumerator())
               .Returns(new TestDbAsyncEnumerator<ToDo>(data.GetEnumerator()));

            mockSet.As<IQueryable<ToDo>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<ToDo>(data.Provider));

            mockSet.As<IQueryable<ToDo>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<ToDo>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<ToDo>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var applicationDbContext = new Mock<ApplicationDbContext>();
            applicationDbContext.Setup(c => c.ToDos).Returns(mockSet.Object);

            return applicationDbContext;
        }

        private ClaimsPrincipal GetUserPrincipal()
        {
            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "1"));

            return new ClaimsPrincipal(identity);
        }
    }
}
