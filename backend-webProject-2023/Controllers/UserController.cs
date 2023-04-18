﻿using backend_webProject_2023.IServices;
using backend_webProject_2023.Modele;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace backend_webProject_2023.Controllers
{
   [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }


        [HttpGet("authentification/{login}/{mdp}")]
        public User authentification(String login, String mdp)
        {
            return this._userService.authentification(login, mdp);
        }

        [HttpGet("listUsers/")]
        public List<User> getUserList()
        {
            return this._userService.getUserList();
        }

        [HttpGet("deleteUser/{idUser}")]
        public void getUserList(String idUser)
        {
           this._userService.deleteUser(idUser);
        }

        [HttpPost("addUser/")]
        public void getUserList(User user)
        {
            this._userService.addUser(user);
        }


        [HttpPost("modifyUser/")]
        public void modifyUser(User user)
        {
            this._userService.modifyUser(user);
        }

    }
}
