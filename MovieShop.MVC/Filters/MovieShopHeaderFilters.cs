using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MovieShop.MVC.Filters
{
    public class MovieShopHeaderFilterAttribute : Attribute, IActionFilter
    {
        private readonly ICurrentUserService _currentUserService;

        public MovieShopHeaderFilterAttribute(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var email = _currentUserService.Email;
            var userId = _currentUserService.UserId;
            var fullName = _currentUserService.FullName;
            var isAuthenticated = _currentUserService.IsAuthenticated;

            if (!isAuthenticated)
            {
                throw new Exception("Not Authenticated");
            }
            // log this information to the text file/database
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
