using Deck.Api.Models;
using Deck.Logic.Entities;
using Deck.Logic.Interfaces.Entities;
using Deck.Logic.Interfaces.Services;
using Deck.Logic.Interfaces.Storages;
using Deck.Logic.Services;
using Deck.Logic.Settings;
using Deck.Logic.Storages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiskFirst.Hateoas;
using System;

namespace Deck.Api.Configuration
{
    public static class ConfigurationExtension
    {
        public static IServiceCollection AddHateoas(this IServiceCollection services)
        {
            services.AddLinks(config =>
            {
                config.AddPolicy<DeckResponse>(policy =>
                {
                    policy.RequireRoutedLink("get", "get-deck", x => new { deckName = x.DeckName })
                        .RequireRoutedLink("all", "get-decks")
                        .RequireRoutedLink("del", "delete-deck", x => new { deckName = x.DeckName })
                        .RequireRoutedLink("shuffle", "shuffle-deck", x => new { deckName = x.DeckName });
                });

                config.AddPolicy<DeckHeaderResponse>(policy =>
                {
                    policy.RequireSelfLink("shuffle")
                        .RequireRoutedLink("get", "get-deck", x => new { deckName = x.DeckName });
                });

            });

            return services;
        }

        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DeckSettings>(configuration.GetSection(nameof(DeckSettings)));
            services.Configure<ShuffleSettings>(configuration.GetSection(nameof(ShuffleSettings)));

            switch (configuration["ShuffleSettings:ShuffleAlgorithm"])
            {
                case "Fast":
                    services.AddTransient<IShuffler<ICard>, FastShuffler>();
                    break;
                case "Manual":
                    services.AddTransient<IShuffler<ICard>, ManualShuffler>();
                    break;
                case "Optimal":
                default:
                    services.AddTransient<IShuffler<ICard>, OptimalShuffler>();
                    break;
            }

            services.AddSingleton<ResponseMapper>();

            services.AddTransient<IDeckStorage<Guid, DeckDTO>, FakeDeckStorage>();

            services.AddTransient<IDeckService<IDeck>, DeckService>();
            services.AddTransient<IShuffleService, ShuffleService>();

            services.AddSingleton<Services>();

            return services;
        }
    }
}
