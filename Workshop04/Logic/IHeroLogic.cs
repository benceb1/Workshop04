using System.Collections.Generic;
using Workshop04.Models;

namespace Workshop04.Logic
{
    interface IHeroLogic
    {
        double AVGPower { get; }
        double AVGSpeed { get; }

        void AddToActiveHeroes(Hero hero);
        void RemoveFromActiveHeroes(Hero hero);
        void SetupCollections(IList<Hero> heroes, IList<Hero> activeHeroes);
        void EditHero();
    }
}