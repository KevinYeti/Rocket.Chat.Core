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
            IJsonSerializer jsonSerializer = new JsonSerializer();
            IAuthHelper authHelper = new AuthHelper();
            IRestClientService restClientService = new RestClientService(authHelper, restClient, jsonSerializer);
            IFileRestClientService fileRestClientService = new FileRestClientService(authHelper, restClient, jsonSerializer);
            IAuthenticationService authService = new AuthenticationService(authHelper, restClientService);
            IChannelsService channelsService = new ChannelsService(restClientService);
            IGroupsService groupsService = new GroupsService(restClientService);
            IUsersService usersService = new UsersService(restClientService);
            IChatService chatService = new ChatService(restClientService);
            IRoomService roomService = new RoomService(restClientService);
            IAssetsService assetsService = new AssetsService(restClientService);
            IAutoTranslateService autoTranslateService = new AutoTranslateService(restClientService);
            ICommandsService commandsService = new CommandsService(restClientService);
            IEmojisService emojisService = new EmojisService(restClientService, fileRestClientService);

            Api = new RocketChatApi(
                chatService,
                usersService,
                groupsService,
                channelsService,
                authService,
                roomService,
                assetsService,
                autoTranslateService,
                commandsService,
                emojisService);
        }       
    }
}