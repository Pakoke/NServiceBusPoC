using AutoMapper;
using NServiceBusPoC.BussinesLogic;
using NServiceBusPoC.BussinesLogic.Entities.UserDomain;
using NServiceBusPoC.UI.ViewEntities.Errors;
using Microsoft.AspNetCore.Mvc;

namespace NServiceBusPoC.UI.Api.Controllers.UserControllers
{
    [Produces("application/json")]
    [Route("api/User/Confirmation")]
    public class UserConfirmationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserBussinesLogic _userBussinesLogic;

        public UserConfirmationController(IMapper mapper, IUserBussinesLogic userBussinesLogic)
        {
            _mapper = mapper;
            _userBussinesLogic = userBussinesLogic;
        }
        // GET: api/User/Confirmation
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET: api/User/Confirmation/0f8fad5b-d9cb-469f-a165-70867728950e
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NoContent();
            }
            else
            {
                EmailConfirmationDto emailObtained = _userBussinesLogic.GetEmailConfirmationById(id);
                if (emailObtained != null)
                {
                    UserDto user = new UserDto()
                    {
                        Email = emailObtained.Email,
                        Role = (Core.Entities.RoleUserEnum)emailObtained.RoleId
                    };

                    _userBussinesLogic.ConsumeEmailConfirmation(emailObtained.Email, emailObtained.RoleId, id);

                    var userFound = _userBussinesLogic.GetExistingFullInfoByUserId(user);

                    if (userFound != null)
                    {
                        return Ok(userFound);
                    }
                    else
                    {
                        return new GeneralError(404) { ErrorMessage = "The user cannot be obtained." };
                    }

                }
                else
                {
                    return new GeneralError(403) { ErrorMessage = "The email cannot be obtained." };
                }

            }

        }

        [HttpPost]
        public IActionResult Post([FromBody]string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NoContent();
            }
            else
            {
                return Ok(id);
            }
        }

    }
}
