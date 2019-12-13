using Deck.Api.Models;
using Deck.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using RiskFirst.Hateoas;

namespace Deck.Api.Controllers
{
    /// <summary>
    /// Базовый контроллер приложения
    /// </summary>
    [ApiController]
    public class MainController : ControllerBase
    {
        /// <summary>
        /// Доступные сервисы.
        /// </summary>
        protected Services Services { get; private set; }

        /// <summary>
        /// Маппер моделей ответов.
        /// </summary>
        protected ResponseMapper Mapper { get; private set; }

        /// <summary>
        /// Сервис добавления ссылок Hateoas.
        /// </summary>
        protected ILinksService LinksService { get; private set; }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public MainController(Services services, ResponseMapper mapper, ILinksService linksService)
        {
            Services = services;
            Mapper = mapper;
            LinksService = linksService;
        }
    }
}