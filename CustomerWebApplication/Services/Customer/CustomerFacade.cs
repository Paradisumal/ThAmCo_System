using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CustomerWebApplication.ViewModels;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;


namespace Customer.Web.Services.Customer
{
    public class CustomerFacade : ControllerBase, ICustomerFacade
    {
        private readonly ILogger<CustomerDto> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _client;

        public CustomerFacade(ILogger<CustomerDto> logger,
                              IHttpClientFactory clientFactory,
                              HttpClient client)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        // POST: api/Customer
        public async Task<CustomerDto> Register(CustomerDto newCustomer)
        {
            var newAccount = new UserPutDto
            {
                Email = newCustomer.EmailAddress,
                Password = newCustomer.Password,
            };

            var authClient = _clientFactory.CreateClient("RetryAndBreak");

            var authdisco = await authClient.GetDiscoveryDocumentAsync("https://customerauththamco.azurewebsites.net");
            var authtokenResponse = await authClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = authdisco.TokenEndpoint,
                ClientId = "customer_web_app",
                ClientSecret = "8PuT=9o6TC0i0CB#ctzR",
                Scope = "customer_web_app"
            });

            if (authtokenResponse.IsError)
            {
                /*ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);*/
            }

            authClient.SetBearerToken(authtokenResponse.AccessToken);
            var authResponse = await _client.PostAsJsonAsync("api/users", newCustomer);
            authResponse.EnsureSuccessStatusCode();

            var client = _clientFactory.CreateClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://thamcocustomeraccount.azurewebsites.net/");
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "customer_web_app",
                ClientSecret = "8PuT=9o6TC0i0CB#ctzR",
                Scope = "customer_web_app"
            }); ;

            if (tokenResponse.IsError)
            {
                /*ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);*/
            }

            client.SetBearerToken(authtokenResponse.AccessToken);
            var response = await _client.PostAsJsonAsync("api/Customer", newCustomer);
            response.EnsureSuccessStatusCode();

            return newCustomer;
        }

        // POST: xxx
        public async Task<AccountDto> Login(AccountDto account)
        {
            var client = _clientFactory.CreateClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://customerauththamco.azurewebsites.net");
            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "customer_web_app",
                ClientSecret = "8PuT=9o6TC0i0CB#ctzR",

                UserName = account.Email,
                Password = account.Password
            });

            if (tokenResponse.IsError)
            {
                /*ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);*/
            }

            var userInfoResponse = await client.GetUserInfoAsync(new UserInfoRequest
            {
                Address = disco.UserInfoEndpoint,
                Token = tokenResponse.AccessToken
            });

            if (userInfoResponse.IsError)
            {
                /*ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);*/
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

            return account;
        }

        // POST: xxx
        public async Task<AccountDto> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");

            return null;
        }

        // GET: api/Customer/X
        public async Task<CustomerDto> GetCustomer(int customerId)
        {

            var client = _clientFactory.CreateClient("RetryAndBreak");

            string accessToken = await HttpContext.GetTokenAsync("access_token");

            client.SetBearerToken(accessToken);

            var response = await _client.GetAsync("https://thamcocustomeraccount.azurewebsites.net/Customer/" + customerId);
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var customer = await response.Content.ReadAsAsync<CustomerDto>();

            return customer;
        }

        // PUT: api/Customer/X
        [HttpPut("api/Customer")]
        public async Task<CustomerDto> PutCustomer(int customerId, CustomerDto updatedCustomer)
        {
            var client = _clientFactory.CreateClient("RetryAndBreak");

            string accessToken = await HttpContext.GetTokenAsync("access_token");

            client.SetBearerToken(accessToken);

            var response = await _client.PutAsJsonAsync("https://thamcocustomeraccount.azurewebsites.net/Customer/" + customerId, updatedCustomer);
            response.EnsureSuccessStatusCode();
           
            return updatedCustomer;
        }

        // DELETE: api/Customer/X
        [HttpDelete("api/Customer")]
        public async Task<CustomerDto> DeleteCustomer(int customerId)
        {
            var client = _clientFactory.CreateClient("RetryAndBreak");

            string accessToken = await HttpContext.GetTokenAsync("access_token");

            client.SetBearerToken(accessToken);

            var response = await _client.DeleteAsync("https://thamcocustomeraccount.azurewebsites.net/Customer/" + customerId);

            return null;
        }
    }
}
