using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop04.Models;

namespace Workshop04.ViewModels
{
    class HeroEditorViewModel
    {
        public Hero Actual { get; set; }

        public List<string> Items = Enum.GetNames(typeof(Side)).ToList();

        public void Setup(Hero hero)
        {
            this.Actual = hero;
        }


        public HeroEditorViewModel()
        {

        }
    }
}
