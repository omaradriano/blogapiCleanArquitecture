using Application.Services.Authentication;
using blog.Contracts.Authentication;
using Contracts.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace blog.Controllers;

[ApiController]
[Route("auth")]

public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase {

    private readonly IAuthenticationService _authenticationService = authenticationService;

    [HttpPost("register")]
    public IActionResult Register([FromBody]RegisterRequest request){
        //Email, Username, Password
        System.Console.WriteLine("Registering user");
        var regResult = _authenticationService.Register(request.Username, request.Email, request.Password);
        var response = new AuthenticationResponse(regResult.Username, regResult.Email, regResult.Token, Guid.NewGuid());
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody]LoginRequest request){
        //Email, Password
        System.Console.WriteLine("Logging in user");
        var logResult = _authenticationService.Login(request.Email, request.Password);
        var response = new AuthenticationResponse(logResult.Username, logResult.Email, logResult.Token, Guid.NewGuid());
        return Ok(response);
    }

    [Authorize]
    [HttpGet("test")]
    public IActionResult TestRoute(){
        var newData = new AuthenticationResponse("test", "test", "test", Guid.NewGuid());
        return Ok(newData);
    }
}