﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using net_core_bootcamp_b1_Hander.DTOs;
using net_core_bootcamp_b1_Hander.Services;

namespace net_core_bootcamp_b1_Hander.Controllers
{
    
        [Route("api/[controller]")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ApiController]
        public class EventController : ControllerBase
        {
            private readonly IEventService _eventService;

            public EventController(IEventService eventService)
            {
                _eventService = eventService;
            }

            [HttpPost("Add")]
            public IActionResult Add([FromBody]EventAddDto model)
            {
                var result = _eventService.Add(model);

                return Ok(result);
            }
        }
       
    
}