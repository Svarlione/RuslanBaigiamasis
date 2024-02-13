using RuslanAPI.Core.DTO;
using RuslanAPI.Core.Models;
using Image = RuslanAPI.Core.Models.Image;

namespace RuslanAPI.DataLayer.Data
{
    public class DbRepository : IDbRepository
    {
        private readonly UserDbContext _userDbContext;

        public DbRepository(UserDbContext context)
        {
            _userDbContext = context;
        }

        /// <summary>
        /// Создает нового пользователя.
        /// </summary>
        /// <param name="user">Данные пользователя для создания.</param>
        /// <returns>Идентификатор созданного пользователя.</returns>
        public long Create(User user)
        {
            try
            {
                if (user == null)

                    throw new ArgumentNullException(nameof(user), "User cannot be null.");

                _userDbContext.Users.Add(user);
                _userDbContext.SaveChanges();

                if (user.Id <= 0)

                    throw new InvalidOperationException("User ID is invalid after creation.");


            }
            catch (Exception ex)
            {
                // Здесь можно добавить логирование ошибки или обработку исключения
                throw new InvalidOperationException("An error occurred while saving the entity changes.", ex);
            }
            return user.Id;
            _userDbContext.Users.Add(user);
            _userDbContext.SaveChanges();
        }


        /// <summary>
        /// Обновляет информацию о пользователе.
        /// </summary>
        /// <param name="user">Обновленные данные пользователя.</param>
        public void UpdateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null.");

            _userDbContext.Users.Update(user);
            _userDbContext.SaveChanges();
        }

        /// <summary>
        /// Удаляет пользователя по его идентификатору.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя для удаления.</param>
        public void DeleteUser(long userId)
        {
            var deletingUser = _userDbContext.Users.Find(userId);

            if (deletingUser != null && deletingUser.LoginInfo.Role == "administrator")
            {
                _userDbContext.Users.Remove(deletingUser);
                _userDbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Unable to delete user. User not found or insufficient permissions.");
            }
        }

        /// <summary>
        /// Получает пользователя по его идентификатору.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Найденный пользователь.</returns>
        public User GetUserByUserId(long userId)
        {
            return _userDbContext.Users.FirstOrDefault(x => x.Id == userId);
        }

        /// <summary>
        /// Создает новый адрес пользователя.
        /// </summary>
        /// <param name="userAdress">Данные адреса для создания.</param>
        public void CreateAdress(UserAdress userAdress)
        {
            if (userAdress == null)
                throw new ArgumentNullException(nameof(userAdress), "User address cannot be null.");

            _userDbContext.UserAdress.Add(userAdress);
            _userDbContext.SaveChanges();
        }

        /// <summary>
        /// Обновляет информацию о пользовательском адресе.
        /// </summary>
        /// <param name="userAdress">Обновленные данные пользовательского адреса.</param>
        public void UpdateAdress(UserAdress userAdress)
        {
            if (userAdress == null)
                throw new ArgumentNullException(nameof(userAdress), "User address cannot be null.");

            _userDbContext.UserAdress.Update(userAdress);
            _userDbContext.SaveChanges();
        }

        /// <summary>
        /// Создает новое изображение.
        /// </summary>
        /// <param name="image">Данные изображения для создания.</param>
        public void CreatImage(Image image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image), "Image cannot be null.");

            _userDbContext.Image.Add(image);
            _userDbContext.SaveChanges();
        }

        /// <summary>
        /// Обновляет информацию об изображении.
        /// </summary>
        /// <param name="image">Обновленные данные изображения.</param>
        public void UpdateImage(Image image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image), "Image cannot be null.");

            _userDbContext.Image.Update(image);
            _userDbContext.SaveChanges();
        }
    }
}
