using LMS.Dal.Entities;
using Microsoft.Data.SqlClient;
using Moq;
using System.Globalization;

namespace LMS.Dal.Test
{
    public class Tests
    {
        UserDao userDao;

        public Tests()
        {
            userDao = new UserDao();
        }

        [Test]
        public void Create_New_Return()
        {
            var user = new User()
            {
                Name = "Lily",
                Email = "459578063@qq.com",
                PhoneNumber = "12312312312"
            };

            var result = userDao.Create(user);

            //Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Delete_ValidName_Return()
        {
            var user = userDao.GetByName("Lily");

            var result = user.Select(x => userDao.Delete(x.Id)).ToList();

            Assert.That(result.All(x => x == 1), Is.True);
        }

        [Test]
        public async Task GetAllAsync_ReturnUsers()
        {
            //Act 
            var users = await userDao.GetAllAsync();

            //Assert
            Assert.That(users.Any(), Is.True);
        }

        [Test]
        public void Update_Valid_Return()
        {
            var oldAge = 0;
            var newAge = 0;
            var user = userDao.GetByName("Lucy").First();
            oldAge = user.Age;
            var birthday = user.BirthDay;

            //user.BirthDay = new DateTime(2000, 1, 1, new GregorianCalendar());

            user.BirthDay = user.BirthDay + TimeSpan.FromDays(400);
            user.Email = "dafdasfd@email";
            userDao.Update(user);
            newAge = userDao.GetByName("Lucy").First().Age;
            Assert.That(newAge - oldAge, Is.EqualTo(-1));
        }

        [Test]
        public void GetAll_ReturnUsers()
        {
            //Act
            var users = userDao.GetAll().ToList();

            //Assert
            Assert.That(users.Any(), Is.True);
        }

        [Test]
        public void GetByName_NameIsValid_ReturnUsers()
        {
            //Act
            var users = userDao.GetByName("Omar");

            //Assert
            Assert.NotNull(users);
            Assert.That(users.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task GetPageCount_Returns()
        {
            var count = await userDao.GetPageCount(3);

            Assert.That(count == 2, Is.True);
        }

        [Test]
        public async Task GetPageAsync_WhenPageNumberIsValid_ReturnUsers()
        {
            var pageNumber = 1;
            var pageSize = 2;

            ////模拟数据库连接
            //var conn = new Mock<SqlConnection>();
            //var command = new Mock<SqlCommand>();
            //var reader = new Mock<SqlDataReader>();

            ////模拟ExecuteReaderAsync方法
            //command.Setup(x => x.ExecuteReaderAsync())
            //    .ReturnsAsync(reader.Object);

            ////模拟数据
            //var users = new List<User>()
            //{
            //    new(){Name = "User1",Email = "123@qq.com",Age = 18},
            //    new(){Name = "User2",Email = "224@qq.com",Age = 19},
            //    new(){Name = "User3",Email = "324@qq.com",Age = 19},
            //    new(){Name = "User4",Email = "424@qq.com",Age = 19},
            //};
            //reader.SetupSequence(x => x.ReadAsync())
            //     .ReturnsAsync(true)
            //     .ReturnsAsync(true)
            //     .ReturnsAsync(false);

            //var userDao = new UserDao(conn.Object);

            //Act
            var result = await userDao.GetPageAsync(pageNumber, pageSize);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Name, Is.EqualTo("Stark"));
            Assert.That(result[1].Name, Is.EqualTo("Lucy"));


        }

    }
}