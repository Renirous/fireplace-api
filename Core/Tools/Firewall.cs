﻿using FireplaceApi.Core.Enums;
using FireplaceApi.Core.Exceptions;
using FireplaceApi.Core.Extensions;
using FireplaceApi.Core.Models;
using FireplaceApi.Core.Operators;
using FireplaceApi.Core.Validators;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace FireplaceApi.Core.Tools
{
    public class Firewall
    {
        private readonly ILogger<Firewall> _logger;
        private readonly AccessTokenOperator _accessTokenOperator;
        private readonly SessionOperator _sessionOperator;
        private readonly AccessTokenValidator _accessTokenValidator;

        public Firewall(ILogger<Firewall> logger,
            AccessTokenOperator accessTokenOperator,
            SessionOperator sessionOperator, AccessTokenValidator accessTokenValidator)
        {
            _logger = logger;
            _accessTokenOperator = accessTokenOperator;
            _sessionOperator = sessionOperator;
            _accessTokenValidator = accessTokenValidator;
        }

        public async Task<User> CheckUser(User requestingUser, IPAddress ipAddress)
        {
            var sw = Stopwatch.StartNew();
            await ValidateSessionAsync(requestingUser.Id, ipAddress);
            await ValidateLimitationOfUserRequestCounts(requestingUser.Id);
            await ValidateLimitationOfIpRequestCounts(ipAddress);
            _logger.LogAppTrace($"User {requestingUser.Id} doesn't have any problem to continue. ",
                sw: sw, parameters: requestingUser.ToJson());
            return requestingUser;
        }

        public async Task CheckGuest(IPAddress ipAddress)
        {
            var sw = Stopwatch.StartNew();
            await ValidateLimitationOfIpRequestCounts(ipAddress);
            _logger.LogAppTrace($"Guest doesn't have any problem to continue. {ipAddress}", sw);
        }

        public void ValidateRequestingUserExists(User requestingUser, string accessTokenValue)
        {
            if (requestingUser == null)
                throw new ApiException(ErrorName.AUTHENTICATION_FAILED,
                    $"There isn't any authorization in input header parameters! " +
                    $"accessTokenValue: {accessTokenValue}");
        }

        public async Task<AccessToken> ValidateAccessTokenAsync(string accessTokenValue, bool isUserEndpoint)
        {
            _accessTokenValidator.ValidateAccessTokenValueFormat(accessTokenValue);
            //if (Regexes.AccessTokenValue.IsMatch(accessTokenValue) == false)
            //    throw new ApiException(ErrorName.AUTHENTICATION_FAILED,
            //        $"Input access token doesn't have valid format! accessTokenValue: {accessTokenValue}");

            var accessToken = await _accessTokenOperator
                .GetAccessTokenByValueAsync(accessTokenValue, true);
            if (isUserEndpoint && accessToken == null)
                throw new ApiException(ErrorName.AUTHENTICATION_FAILED,
                    $"Input access token does not exist! accessTokenValue: {accessTokenValue}");

            return accessToken;
        }

        public async Task<Session> ValidateSessionAsync(ulong userId, IPAddress ipAddress)
        {
            var session = await _sessionOperator.FindSessionAsync(userId, ipAddress);
            if (session != null && session.State == SessionState.CLOSED)
                throw new ApiException(ErrorName.AUTHENTICATION_FAILED,
                    $"User session was closed! userId: {userId}, ipAddress: {ipAddress}");

            session = await _sessionOperator.CreateOrUpdateSessionAsync(userId, ipAddress);
            return session;
        }

        public async Task ValidateLimitationOfUserRequestCounts(ulong userId)
        {
            await Task.CompletedTask;
        }

        public async Task ValidateLimitationOfIpRequestCounts(IPAddress ipAddress)
        {
            await Task.CompletedTask;
        }
    }
}
