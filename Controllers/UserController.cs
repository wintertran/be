using AutoMapper;
using be.DTOs;
using be.Models;
using be.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;  // Repository để làm việc với tài khoản người dùng
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IAccountRepository accountRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;  // Khởi tạo repository cho tài khoản
            _mapper = mapper;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(userDtos);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        // PATCH: api/User/{id} - Chỉnh sửa thông tin người dùng
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Kiểm tra nếu người dùng có tài khoản hay không
            var account = await _accountRepository.GetByUserIdAsync(id);
            if (account == null)
            {
                return NotFound("Account not found.");
            }

            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Chỉnh sửa thông tin người dùng
            _mapper.Map(updateUserDto, user);
            await _userRepository.UpdateAsync(user);

            return NoContent(); // Trả về NoContent nếu việc cập nhật thành công
        }

        // DELETE: api/User/{id} - Xóa người dùng
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            // Kiểm tra nếu người dùng có tài khoản hay không
            var account = await _accountRepository.GetByUserIdAsync(id);
            if (account == null)
            {
                return NotFound("Account not found.");
            }

            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            await _userRepository.DeleteAsync(id);
            return NoContent(); // Trả về NoContent nếu xóa thành công
        }
    }
}
