using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Customer.Web.Services.Customer;
using Customer.Web.ViewModels;
using CustomerWebApplication.Models;
using CustomerWebApplication.ViewModels;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;


namespace CustomerWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly ICustomerFacade _customerFacade;

        public AccountController(ILogger<AccountController> logger,
                                 IHttpClientFactory clientFactory,
                                 ICustomerFacade customerFacade)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _customerFacade = customerFacade;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                CustomerDto customer = new CustomerDto
                {
                    GivenName = model.GivenName,
                    FamilyName = model.FamilyName,
                    EmailAddress = model.Email,
                    Password = model.Password
                };

                await _customerFacade.Register(customer);

                return RedirectToAction("login", "account");
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login([FromQuery] string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginViewModel model,
                                               [FromQuery] string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            AccountDto account = new AccountDto
            {
                Email = model.Email,
                Password = model.Password,
                RememberMe = model.RememberMe
            };

            await _customerFacade.Login(account);

            /*if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient("RetryAndBreak");

                var disco = await client.GetDiscoveryDocumentAsync("https://customerauththamco.azurewebsites.net");
                var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    ClientId = "customer_web_app",
                    ClientSecret = "8PuT=9o6TC0i0CB#ctzR",

                    UserName = model.Email,
                    Password = model.Password
                });

                if (tokenResponse.IsError)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }

                var userInfoResponse = await client.GetUserInfoAsync(new UserInfoRequest
                {
                    Address = disco.UserInfoEndpoint,
                    Token = tokenResponse.AccessToken
                });

                if (userInfoResponse.IsError)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }

                var claimsIdentity = new ClaimsIdentity(userInfoResponse.Claims, "Cookies");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                var tokensToStore = new AuthenticationToken[]
                {
                    new AuthenticationToken { Name = "access_token", Value = tokenResponse.AccessToken }
                };

                var authProperties = new AuthenticationProperties();
                authProperties.StoreTokens(tokensToStore);

                await HttpContext.SignInAsync("Cookies", claimsPrincipal, authProperties);

                return LocalRedirect(returnUrl ?? "/");
            }*/

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout([FromQuery] string returnUrl = null)
        {
            await _customerFacade.Logout();
            return LocalRedirect(returnUrl ?? "/");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        /*[Authorize]*/
        public async Task<IActionResult> Details(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CustomerDto customer = null;
            try
            {
                customer = await _customerFacade.GetCustomer(1);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Customer Facade");
                customer = null;
            }

            var viewModel = new CustomerViewModel
            {
                CustomerId = customer.CustomerId,
                GivenName = customer.GivenName,
                FamilyName = customer.FamilyName,
                AddressOne = customer.AddressOne,
                AddressTwo = customer.AddressTwo,
                Town = customer.Town,
                State = customer.State,
                AreaCode = customer.AreaCode,
                Country = customer.Country,
                EmailAddress = customer.EmailAddress,
                TelephoneNumber = customer.TelephoneNumber
            };

            return View(viewModel);
        }

        // GET: Customer/Update/5
        public async Task<IActionResult> Update(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var customer = await _customerFacade.GetCustomer(id);

            if(customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerViewModel
            {
                CustomerId = customer.CustomerId,
                GivenName = customer.GivenName,
                FamilyName = customer.FamilyName,
                AddressOne = customer.AddressOne,
                AddressTwo = customer.AddressTwo,
                Town = customer.Town,
                State = customer.State,
                AreaCode = customer.AreaCode,
                Country = customer.Country,
                EmailAddress = customer.EmailAddress,
                TelephoneNumber = customer.TelephoneNumber
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, CustomerViewModel customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var updatedCustomer = new CustomerDto()
                    {
                        CustomerId = customer.CustomerId,
                        GivenName = customer.GivenName,
                        FamilyName = customer.FamilyName,
                        AddressOne = customer.AddressOne,
                        AddressTwo = customer.AddressTwo,
                        Town = customer.Town,
                        State = customer.State,
                        AreaCode = customer.AreaCode,
                        Country = customer.Country,
                        EmailAddress = customer.EmailAddress,
                        TelephoneNumber = customer.TelephoneNumber
                    };

                    await _customerFacade.PutCustomer(id, updatedCustomer);
                }
                catch (HttpRequestException)
                {
                    _logger.LogWarning("Exception Occured using Customer Facade");
                }
                return RedirectToAction(nameof(Details));
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _customerFacade.DeleteCustomer(id);

            return RedirectToAction("Index", "Home");
        }
    }
}