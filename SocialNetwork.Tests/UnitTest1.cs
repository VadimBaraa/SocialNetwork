using Moq;
using NUnit.Framework;
using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Exceptions;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class FriendServiceTests
    {
        private Mock<IFriendService> _friendServiceMock;

        [SetUp]
        public void SetUp()
        {
            _friendServiceMock = new Mock<IFriendService>();
        }

        [Test]
        public void AddFriend_ValidEmail_ShouldAddFriendSuccessfully()
        {
            // Arrange
            var userId = 1;
            var friendEmail = "friend@example.com";
            _friendServiceMock.Setup(fs => fs.AddFriend(userId, friendEmail)).Verifiable();

            // Act
            _friendServiceMock.Object.AddFriend(userId, friendEmail);

            // Assert
            _friendServiceMock.Verify(fs => fs.AddFriend(userId, friendEmail), Times.Once);
        }

        [Test]
        public void AddFriend_UserNotFound_ShouldThrowException()
        {
            // Arrange
            var userId = 1;
            var friendEmail = "nonexistent@example.com";
            _friendServiceMock.Setup(fs => fs.AddFriend(userId, friendEmail))
                .Throws(new UserNotFoundException());

            // Act & Assert
            var ex = Assert.Throws<UserNotFoundException>(() => _friendServiceMock.Object.AddFriend(userId, friendEmail));
            Assert.That(ex.Message, Is.EqualTo("Пользователь не найден."));
        }
    }
}
