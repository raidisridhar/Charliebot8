﻿using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace ContosoFlowers.Handlers
{
    public interface IIntentHandler
    {
        Task Respond(IAwaitable<IMessageActivity> activity, LuisResult result);
    }
}
