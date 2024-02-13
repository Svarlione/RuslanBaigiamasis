using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RuslanAPI.Core.DTO;
using RuslanAPI.Core.Models;
using RuslanAPI.Services.Authorization;
using RuslanAPI.Services.Mappers;
using RuslanAPI.Services.UserServices;
using System.Net.Mime;

/// <summary>
/// Контроллер для управления пользователями в системе регистрации.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UserRegSistem : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IUserMapper _userMapper;
    private readonly IAuthService _authService;
    public UserRegSistem(IUserService userService, IUserMapper userMapper, IAuthService authService)
    {
        _userService = userService;
        _userMapper = userMapper;
        _authService = authService;
    }

    /// <summary>
    /// Создает нового пользователя.
    /// </summary>
    /// <param name="createUserDto">Данные пользователя для создания.</param>
    /// <returns>HTTP-статус 200 с идентификатором созданного пользователя или HTTP-статус 400 в случае ошибки.</returns>
    [HttpPost("user/Create")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
    {
        try
        {
            _userService.CreateUser(createUserDto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    /// <summary>
    /// Обновляет информацию о пользователе.
    /// </summary>
    /// <param name="updateUserDto">Обновленные данные пользователя.</param>
    /// <returns>HTTP-статус 200 в случае успешного обновления или HTTP-статус 400 в случае ошибки.</returns>
    [HttpPut("userUpdate")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdateUser([FromBody] UpdateUserDto updateUserDto, long userId)
    {
        try
        {
            _userService.UpdateUser(updateUserDto, userId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    [HttpPost("addressCreate")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateUserAddress([FromBody] AdressDto userAddressDto, long userId)
    {
        try
        {
            UserAdress userAddress = _userMapper.MapToUserAdressEntity(userAddressDto);
            _userService.CreateUserAddress(userAddress, userId);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    [HttpPut("addressUpdate")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdateUserAddress([FromBody] AdressDto userAddressDto, long userId)
    {
        try
        {
            UserAdress userAddress = _userMapper.MapToUserAdressEntity(userAddressDto);
            _userService.UpdateUserAddress(userAddress, userId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    [HttpPost("imageCreate")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateImage([FromForm] ImageDto imageDto, long userId)
    {
        try
        {
            _userService.CreateImage(imageDto, userId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }


    [HttpPut("image/update/{id}")]
    public IActionResult UpdateImage(int id, [FromBody] ImageUpdateDto imageUpdateDto)
    {
        try
        {
            _userService.UpdateImage(imageUpdateDto, id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }


    [HttpDelete("user/delete/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Administrator")]
    public IActionResult DeleteUser(long userId)
    {
        try
        {
            _userService.DeleteUser(userId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    [HttpGet("user/{userId}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetUserByUserId(long userId)
    {
        try
        {
            var user = _userService.GetUserByUserId(userId);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    [HttpPost("login")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginInfoDto request)
    {
        try
        {
            // Преобразовать пароль из byte[] в строку
            string password = request.Password;

            var token = await _authService.LoginAsync(request.UserName, password);
            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    [HttpPost("signup")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignUp([FromBody] SingUpDto request)
    {
        try
        {
            byte[] salt = _authService.GeneratePasswordSalt();

            var token = await _authService.SignUpAsync(request.UserName, request.Role, request.Password, salt);
            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }
}
