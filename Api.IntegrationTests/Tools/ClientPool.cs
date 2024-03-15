﻿using GamingCommunityApi.Core.Interfaces.IRepositories;
using GamingCommunityApi.Core.Operators;
using GamingCommunityApi.Core.ValueObjects;
using GamingCommunityApi.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GamingCommunityApi.Api.IntegrationTests.Tools
{
    public class ClientPool : IDisposable
    {
        private readonly ILogger<ClientPool> _logger;
        private readonly WebApplicationFactory<Startup> _apiFactory;
        private readonly WebApplicationFactoryClientOptions _clientOptions;
        private readonly GamingCommunityApiContext _gamingCommunityApiContext;
        private readonly IUserRepository _userRepository;
        private readonly IEmailRepository _emailRepository;
        private readonly IAccessTokenRepository _accessTokenRepository;
        private readonly AccessTokenOperator _accessTokenOperator;

        public HttpClient GuestClient { get; }
        public HttpClient TheHulkClient { get; }

        public ClientPool(ApiIntegrationTestFixture testFixture)
        {
            _logger = testFixture.ServiceProvider.GetRequiredService<ILogger<ClientPool>>();
            _apiFactory = testFixture.ApiFactory;
            _clientOptions = new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = true,
                BaseAddress = new Uri("https://localhost:5021"),
                HandleCookies = true,
                MaxAutomaticRedirections = 7
            };
            _gamingCommunityApiContext = testFixture.ServiceProvider.GetRequiredService<GamingCommunityApiContext>();
            _userRepository = testFixture.ServiceProvider.GetRequiredService<IUserRepository>();
            _emailRepository = testFixture.ServiceProvider.GetRequiredService<IEmailRepository>();
            _accessTokenRepository = testFixture.ServiceProvider.GetRequiredService<IAccessTokenRepository>();
            _accessTokenOperator = testFixture.ServiceProvider.GetRequiredService<AccessTokenOperator>();
            GuestClient = CreateGuestClient();
            TheHulkClient = CreateTheHulkClientAsync().GetAwaiter().GetResult();
        }

        private HttpClient CreateGuestClient()
        {
            var guestClient = _apiFactory.CreateClient(_clientOptions);
            _logger.LogInformation($"Guest client initialized successfully.");
            return guestClient;
        }

        private async Task<HttpClient> CreateTheHulkClientAsync()
        {
            var user = await _userRepository.CreateUserAsync("Bruce", "Banner",
                "TheHulk", Password.OfValue("TheHulkP0"), Core.Enums.UserState.NOT_VERIFIED);
            var emailActivation = new Activation(12345, Core.Enums.ActivationStatus.SENT, "Code: 12345");
            var email = await _emailRepository.CreateEmailAsync(user.Id, "TheHulk", emailActivation);
            var newAccessTokenValue = _accessTokenOperator.GenerateNewAccessTokenValue();
            var accessToken = await _accessTokenRepository.CreateAccessTokenAsync(user.Id, newAccessTokenValue);
            var theHulkClient = _apiFactory.CreateClient(_clientOptions);
            var defaultRequestHeaders = theHulkClient.DefaultRequestHeaders;
            defaultRequestHeaders.Add(Api.Tools.Constants.AuthorizationHeaderKey, $"Bearer {newAccessTokenValue}");
            _logger.LogInformation($"Guest client initialized successfully.");
            return theHulkClient;
        }

        public void Dispose()
        {
            _gamingCommunityApiContext.Database.ExecuteSqlRaw(@"TRUNCATE TABLE public.""UserEntities"" CASCADE;");
        }
    }
}
