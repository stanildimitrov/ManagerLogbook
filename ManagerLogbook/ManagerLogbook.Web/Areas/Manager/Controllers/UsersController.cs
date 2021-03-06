﻿using log4net;
using ManagerLogbook.Services.Contracts;
using ManagerLogbook.Services.Contracts.Providers;
using ManagerLogbook.Services.CustomExeptions;
using ManagerLogbook.Web.Models;
using ManagerLogbook.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ManagerLogbook.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly ILogbookService logbookService;
        private readonly IUserServiceWrapper wrapper;
        private static readonly ILog log =
        LogManager.GetLogger(typeof(UsersController));

        public UsersController(IUserService userService,
                               ILogbookService logbookService,
                               IUserServiceWrapper wrapper)
        {
            this.userService = userService;
            this.logbookService = logbookService;
            this.wrapper = wrapper;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SwitchLogbook(IndexNoteViewModel model)
        {
            try
            {
                var userId = this.wrapper.GetLoggedUserId(User);
                var user = await this.userService.GetUserByIdAsync(userId);
                if (model.CurrentLogbookId.HasValue)
                {
                    var logbook = await this.logbookService.GetLogbookById(model.CurrentLogbookId.Value);
                    if (user.CurrentLogbookId ==  model.CurrentLogbookId)
                    {
                        return BadRequest((string.Format(WebConstants.AlreadyInLogbook,  user.UserName, logbook.Name)));
                    }
                    user = await this.userService.SwitchLogbookAsync(userId, model.CurrentLogbookId.Value);
                    //return Ok(string.Format(WebConstants.SwitchLogbook, logbook.Name));
                    return RedirectToAction("Index", "Notes");
                }

                return BadRequest(WebConstants.NoLogbookChoosen);
            }

            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotAuthorizedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                log.Error("Unexpected exception occured:", ex);
                return RedirectToAction("Error", "Home");
            }
        }
    }
}