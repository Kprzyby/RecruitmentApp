using Common.Listing;
using Common.ServiceRegistrationAttributes;
using Data.Entities;
using Data.Repositories;
using PagedList;
using Services.DTOs.User;
using Services.Listing;

namespace Services.Services
{
    [ScopedRegistration]
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Guid GetUserGuid(string email)
        {
            var result = _userRepository.GetUserGuidByEmail(email);
            return result;
        }

        public void SetUserRecoveryGuid(string email, Guid guid)
        {
            var user = _userRepository.GetUserByEmail(email);
            user.PasswordRecoveryGuid = guid;
            _userRepository.UpdateUser(user);
        }

        public void SetUserConfirmationGuid(string email, Guid guid)
        {
            var user = _userRepository.GetUserByEmail(email);
            user.ConfirmationGuid = guid;
            _userRepository.UpdateUser(user);
        }

        public UserDTO Get(int userId)
        {
            User user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                return null;
            }

            UserDTO userDTO = new UserDTO(user.Id, user.Email, user.UserStatus, user.RoleName);

            return userDTO;
        }

        public UserListing GetUsers(Paging paging, SortOrder sortOrder, UserFiltringDTO userFiltringDTO)
        {
            IQueryable<User> users = _userRepository.GetAllUsers();
            users = users.Where(u => !u.DeletedDate.HasValue);

            if (!String.IsNullOrEmpty(userFiltringDTO.Email))
            {
                users = users.Where(s => s.Email.Contains(userFiltringDTO.Email));
            }
            if (!String.IsNullOrEmpty(userFiltringDTO.UserStatus))
            {
                users = users.Where(s => s.UserStatus.Equals(userFiltringDTO.UserStatus));
            }
            if (!String.IsNullOrEmpty(userFiltringDTO.RoleName))
            {
                users = users.Where(s => s.RoleName.Equals(userFiltringDTO.RoleName));
            }

            users = Sorter<User>.Sort(users, sortOrder.Sort);

            UserListing userListing = new UserListing();
            userListing.TotalCount = users.Count();
            userListing.UserFiltringDTO = userFiltringDTO;
            userListing.Paging = paging;
            userListing.SortOrder = sortOrder;
            userListing.UserDTOs = users
                .Select(x => new UserDTO(x.Id, x.Email, x.UserStatus, x.RoleName))
                .ToPagedList(paging.PageNumber, paging.PageSize);

            return userListing;
        }

        public int Update(UserEditDTO userEdit)
        {
            User user = _userRepository.GetUserById(userEdit.Id);
            if (user == null)
            {
                return 0;
            }

            user.UserStatus = userEdit.UserStatus;
            user.RoleName = userEdit.RoleName;
            user.LastUpdatedDate = DateTime.UtcNow;

            _userRepository.UpdateAndSaveChanges(user);

            return user.Id;
        }

        public int Delete(int userId, int loginUserId)
        {
            User user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                return 0;
            }

            user.DeletedById = loginUserId;
            user.DeletedDate = DateTime.UtcNow;

            _userRepository.UpdateAndSaveChanges(user);

            return user.Id;
        }
    }
}