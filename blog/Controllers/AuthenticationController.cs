using Application.Services.Authentication;
using blog.Contracts.Authentication;
using Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;

namespace blog.Controllers;

[ApiController]
[Route("auth")]

public class AuthenticationController : ControllerBase {

    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService){
        _authenticationService = authenticationService;
    }

    [Route("register")]
    [HttpPost]
    public IActionResult Register(RegisterRequest request){
        System.Console.WriteLine("Registering user");
        var regResult = _authenticationService.Register(request.Username, request.Email, request.Password);
        var response = new AuthenticationResponse(regResult.Username, regResult.Email, regResult.Token, Guid.NewGuid());
        return Ok(response);
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login(LoginRequest request){
        System.Console.WriteLine("Logging in user");
        var logResult = _authenticationService.Login(request.Email, request.Password);
        var response = new AuthenticationResponse(logResult.Username, logResult.Email, logResult.Token, Guid.NewGuid());
        return Ok(response);
    }
}