﻿using RestSharp;
using Rocket.Chat.Api.Core.RestHelpers;
using Rocket.Chat.Api.Core.Services;

namespace Rocket.Chat.Api.Core
{
    public class RocketChat
    {
        public IRocketChatApi Api { get; }

        public RocketChat(string serverUrl)
        {
            IRestClient restClient = new RestClient(serverUrl);
            IJsonConvertHelper jsonConvertHelper = new JsonConvertHelper();
            IAuthHelper authHelper = new AuthHelper();
            IRestClientService restClientService = new RestClientService(authHelper, restClient, jsonConvertHelper);
            IAuthenticationService authService = new AuthenticationService(authHelper, restClientService);
            IChannelsService channelsService = new ChannelsService(restClientService);
            IGroupsService groupsService = new GroupsService(restClientService);
            IUsersService usersService = new UsersService(restClientService);
            IChatService chatService = new ChatService(restClientService);
            
            Api = new RocketChatApi(
                chatService,
                usersService,
                groupsService,
                channelsService,
                authService);
        }       
    }
}