﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Sozluk.Api.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    public Guid UserId => new Guid(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
}
