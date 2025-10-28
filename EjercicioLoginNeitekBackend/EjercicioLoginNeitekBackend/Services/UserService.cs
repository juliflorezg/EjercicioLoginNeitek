using EjercicioLoginNeitekBackend.Models;
using EjercicioLoginNeitekBackend.Repository;
using EjercicioLoginNeitekBackend.DTOs;
using Microsoft.AspNetCore.Identity;

namespace EjercicioLoginNeitekBackend.Services
{
    public class UserService(IRepository<User, Guid> userRepository, IRepository<UserType, int> userTypeRepository, IPasswordHasher<User> passwordHasher) : IUserService
    {
        private readonly IRepository<User, Guid> _userRepository = userRepository;
        private readonly IRepository<UserType, int> _userTypeRepository = userTypeRepository;
        private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;
        public List<string> Errors { get; } = [];

        public async Task<UserDTO> Add(UserCreateDTO userInsertDto)
        {
            User user = new()
            {
                Email = userInsertDto.Email,
                UserTypeId = userInsertDto.UserTypeId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            user.HashedPassword = _passwordHasher.HashPassword(user, userInsertDto.Password);

            await _userRepository.Add(user);
            await _userRepository.Save();

            var userDTO = new UserDTO()
            {
                Id = user.Id,
                Email = user.Email,
                UserTypeId = user.UserTypeId,
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate,
            };

            return userDTO;
        }

        public Task<UserDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Update(int id, UserUpdateDTO skateUpdateDto)
        {
            throw new NotImplementedException();
        }

        public bool Validate(UserCreateDTO insertDto)
        {
            if (_userRepository.Search(b => b.Email.Equals(insertDto.Email)).Count() > 0)
            {
                Errors.Add("There is already an user with that email.");
                return false;
            }
            return true;
        }

        public bool Validate(UserUpdateDTO updateDto)
        {
            throw new NotImplementedException();
        }

        public UserDTO? GetByEmail(LoginDTO loginDTO)
        {
            var user = _userRepository.Search(u => u.Email == loginDTO.Email).FirstOrDefault();
            if (user == null) return null;

            var userDTO = new UserDTO()
            {
                Id = user.Id,
                Email = user.Email,
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate,
                UserTypeId = user.UserTypeId,
            };

            return userDTO;
        }

        public bool ValidatePassword(LoginDTO loginDTO)
        {
            var user = _userRepository.Search(u => u.Email == loginDTO.Email).FirstOrDefault();

            var isCorrectPassword = _passwordHasher.VerifyHashedPassword(user, user.HashedPassword, loginDTO.Password);

            return isCorrectPassword == PasswordVerificationResult.Success || isCorrectPassword == PasswordVerificationResult.SuccessRehashNeeded;
        }

        public async Task<string> GetUserTypeNameById(UserDTO userDTO)
        {
            var userType = await _userTypeRepository.GetById(userDTO.UserTypeId);
            return userType?.Type ?? "unknown";
        }
    }
}
