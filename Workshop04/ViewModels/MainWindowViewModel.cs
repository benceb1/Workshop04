using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Workshop04.Logic;
using Workshop04.Models;

namespace Workshop04.ViewModels
{
    class MainWindowViewModel : ObservableRecipient
    {
        IHeroLogic logic;

        public ObservableCollection<Hero> Heroes { get; set; }

        public ObservableCollection<Hero> ActiveHeroes { get; set; }

        private Hero selectedFromHeroes;

        public Hero SelectedFromHeroes
        {
            get { return selectedFromHeroes; }
            set { SetProperty(ref selectedFromHeroes, value); }
        }

        private Hero selectedFromActiveHeroes;

        public Hero SelectedFromActiveHeroes
        {
            get { return selectedFromActiveHeroes; }
            set { SetProperty(ref selectedFromActiveHeroes, value); }
        }

        public ICommand AddToActiveHeroesCommand { get; set; }
        public ICommand RemoveFromActiveHeroesCommand { get; set; }
        public ICommand NewHeroCommand { get; set; }

        public double AVGPower
        {
            get
            {
                return logic.AVGPower;
            }
        }

        public double AVGSpeed
        {
            get
            {
                return logic.AVGSpeed;
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
            : this(IsInDesignMode ? null : Ioc.Default.GetService<IHeroLogic>())
        {

        }

        public MainWindowViewModel(IHeroLogic logic)
        {
            this.logic = logic;
            Heroes = new ObservableCollection<Hero>();
            ActiveHeroes = new ObservableCollection<Hero>();

            Heroes.Add(new Hero()
            {
                Name = "asdfa",
                Power = 3,
                Side = Side.Evil,
                Speed = 3
            });

            logic.SetupCollections(Heroes, ActiveHeroes);

            AddToActiveHeroesCommand = new RelayCommand(
                () => logic.AddToActiveHeroes(SelectedFromHeroes),
                () => SelectedFromHeroes != null
                );

            RemoveFromActiveHeroesCommand = new RelayCommand(
                () => logic.RemoveFromActiveHeroes(SelectedFromActiveHeroes),
                () => SelectedFromActiveHeroes != null
                );
            Messenger.Register<MainWindowViewModel, string, string>(this, "HeroInfo", (recipient, msg) =>
            {
                OnPropertyChanged("AVGPower");
                OnPropertyChanged("AVGSpeed");
            });
            /*NewHeroCommand = new RelayCommand(
                () => logic.EditTrooper(SelectedFromBarracks),
                () => SelectedFromBarracks != null
                );*/
        }
    }
}
