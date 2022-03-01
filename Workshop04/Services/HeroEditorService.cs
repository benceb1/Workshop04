using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop04.Models;

namespace Workshop04.Services
{
    class HeroEditorService : IHeroEditorService
    {
        public void Create()
        {
            new Window1().ShowDialog();
        }
    }
}
