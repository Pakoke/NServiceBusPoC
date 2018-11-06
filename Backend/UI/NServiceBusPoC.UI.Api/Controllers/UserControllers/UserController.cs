using AutoMapper;
using NServiceBusPoC.BussinesLogic;
using NServiceBusPoC.BussinesLogic.Entities.UserDomain;
using NServiceBusPoC.UI.ViewEntities;
using NServiceBusPoC.UI.ViewEntities.Errors;
using Microsoft.AspNetCore.Mvc;

namespace NServiceBusPoC.UI.Api.Controllers.UserControllers
{
    /// <summary>
    /// Controller to login,register and delete a user
    /// </summary>
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserBussinesLogic _userBussinesLogic;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserBussinesLogic userBussinesLogic)
        {
            this._userBussinesLogic = userBussinesLogic;
            this._mapper = mapper;
        }

        /// <summary>
        /// Status user controller
        /// </summary>
        /// <returns></returns>
        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        /// <summary>
        /// Login a specific user
        /// </summary>
        /// <param name="value"></param>
        /// /// <remarks>
        /// Sample UserLogin Request:
        ///
        ///     POST /User
        ///     {
        ///        "Email": "testemail@email.com",
        ///        "Password": "1111"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">The user is properly logged</response>
        /// <response code="400">There is an error trying to log the user</response>            
        // POST: api/User
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] UserLoginRequest value)
        {
            if (ModelState.IsValid)
            {

                var user = new UserDto()
                {
                    Email = value.Email,
                    Password = value.Password
                };

                var userObtained = _userBussinesLogic.GetUserByPassword(user);

                if (userObtained != null)
                {
                    return Ok(userObtained);
                }
                else
                {
                    return new GeneralError(400) { ErrorMessage = "Error trying to get the user on the login." };
                }

            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }

        /// <summary>
        /// Register a specific user
        /// </summary>
        /// <param name="value"></param>
        /// /// <remarks>
        /// Sample UserLogin Request:
        ///
        ///     POST /User
        ///     {
        ///           "Name": "TestName",
        ///           "Surname": "TestSurnameName",
        ///           "SecondName": "TestSecondName",
        ///           "SecondSurname": "TestSecondSurname",
        ///           "Club": 0,
        ///           "Email": "testemail@email.com",
        ///           "Password": "1111",
        ///           "ConfirmationPassword": "1111",
        ///           "BirthDate":"1991-07-01",
        ///           "Role": 0,
        ///           "Country":"UK",
        ///           "DNI":"44556630T",
        ///           "Nationality":"English",
        ///           "SocialNumber":"",
        ///           "Street":"calle walabe 5"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">The user is properly register</response>
        /// <response code="401">User is not valid</response>    
        [HttpPut()]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(402)]
        public IActionResult Put([FromBody]UserRegisterRequest value)
        {
            if (ModelState.IsValid)
            {

                var result = new UserDto()
                {
                    BirthDate = value.BirthDate,
                    Club = value.Club,
                    ConfirmationPassword = value.ConfirmationPassword,
                    Country = value.Country,
                    DNI = value.DNI,
                    Email = value.Email,
                    Name = value.Name,
                    Nationality = value.Nationality,
                    Password = value.Password,
                    Role = value.Role,
                    SecondName = value.SecondName,
                    SecondSurname = value.SecondSurname,
                    SocialNumber = value.SocialNumber,
                    Street = value.Street,
                    Surname = value.Surname
                };

                //var result = _mapper.Map<UserDto>(value);

                if (_userBussinesLogic.ValidUser(result))
                    if (_userBussinesLogic.CreateNewUserAndSendConfirmationEmail(result))
                    {
                        return Ok();
                    }
                    else
                    {
                        return new GeneralError(402) { ErrorMessage = "The user cannot be created or the email cannot be send" };
                    }
                else
                {
                    return new GeneralError(401) { ErrorMessage = "User not valid" };
                }

            }
            else
            {
                return BadRequest(ModelState.Values);
            }

        }

        /// <summary>
        /// Delete a specific user given a name
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete([FromBody]int id)
        {
        }
    }
}
