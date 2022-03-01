using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop04.Models;
using Workshop04.Services;

namespace Workshop04.Logic
{
    class HeroLogic : IHeroLogic
    {
        IList<Hero> heroes;

        IList<Hero> activeHeroes;

        IMessenger messenger;

        IHeroEditorService editorService;

        public HeroLogic(IMessenger messenger, IHeroEditorService editorService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
        }

        public double AVGPower
        {
            get
            {
                return Math.Round(activeHeroes.Count == 0 ? 0 : activeHeroes.Average(t => t.Power), 2);
            }
        }

        public double AVGSpeed
        {
            get
            {
                return Math.Round(activeHeroes.Count == 0 ? 0 : activeHeroes.Average(t => t.Speed), 2);
            }
        }

        public void SetupCollections(IList<Hero> heroes, IList<Hero> activeHeroes)
        {
            this.heroes = heroes;
            this.activeHeroes = activeHeroes;
        }

        public void AddToActiveHeroes(Hero hero)
        {
            heroes.Add(hero.GetCopy());
            messenger.Send("Hero added", "HeroInfo");
        }

        public void RemoveFromActiveHeroes(Hero hero)
        {
            heroes.Remove(hero);
            messenger.Send("Hero removed", "HeroInfo");
        }
    }
}
