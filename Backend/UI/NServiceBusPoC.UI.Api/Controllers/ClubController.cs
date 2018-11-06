using AutoMapper;
using NServiceBusPoC.BussinesLogic.ClubDomain;
using NServiceBusPoC.UI.ViewEntities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace NServiceBusPoC.UI.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Club")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubBussinesLogic _clubBussinesLogic;
        private readonly IMapper _mapper;

        public ClubController(IMapper mapper, IClubBussinesLogic clubBussinesLogic)
        {
            this._clubBussinesLogic = clubBussinesLogic;
            this._mapper = mapper;
        }

        // GET: api/Club
        [HttpGet]
        public IActionResult Get()
        {
            List<ClubResponse> clubs = new List<ClubResponse>();
            var clubsresolved = _clubBussinesLogic.GetAllClubs();
            clubs = _mapper.Map<List<ClubResponse>>(clubsresolved);
            return Ok(clubs);

        }

        // GET: api/Club/5
        [HttpGet("{id}")]
        public string Get([FromRoute]int id)
        {
            throw new NotImplementedException();
            //ClubResponse clubs = new ClubResponse();
            //var clubsresolved = _clubBussinesLogic.GetAllClubs();
            //clubs = _mapper.Map<IEnumerable<ClubResponse>>(clubs);
            //return Ok(clubs);
        }

        // PUT: api/Club/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
