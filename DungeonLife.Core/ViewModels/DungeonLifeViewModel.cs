using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.ObjectModel;
using DungeonLife.Models;
using DungeonLife.Data;

namespace DungeonLife.Core.ViewModels
{
    public class DungeonLifeViewModel : MvxViewModel
    {

        DungeonLifeModel Data = new DungeonLifeModel();
        EventModel Events;

        bool tempwindowopen = false;

        public DungeonLifeViewModel()
        {
            NextTurnCommand = new MvxCommand(NextTurn);
            CharacterWindowCommand = new MvxCommand(CharacterWindow);
            SkillWindowCommand = new MvxCommand(SkillWindow);
            MagicWindowCommand = new MvxCommand(MagicWindow);
            WorkWindowCommand = new MvxCommand(WorkWindow);
            FamilyWindowCommand = new MvxCommand(FamilyWindow);
            ActionsWindowCommand = new MvxCommand(ActionsWindow);
            Events = new EventModel(Data.Player.Keywords.RetreiveKeywords());
            RetreivePlayer();
            FamilyList = Data.Family;
            HistoryList = Data.History;


        }



        #region Buttons Commands

        public IMvxCommand NextTurnCommand { get; set; }

        public void NextTurn()
        {
            //Move to next turn
            EndTurn();
        }

        public IMvxCommand CharacterWindowCommand { get; set; }

        public void CharacterWindow()
        {
            if (CharacterViewVisbility == "Visible")
                EmptyView();
            else if (tempwindowopen)
            {
                EmptyView();
                ChangeView("Character");
            }
            else
                ChangeView("Character");
        }

        public IMvxCommand SkillWindowCommand { get; set; }

        public void SkillWindow()
        {
            if (SkillsViewVisbility == "Visible")
                EmptyView();
            else if (tempwindowopen)
            {
                EmptyView();
                ChangeView("Skills");
            }
            else
                ChangeView("Skills");
        }

        public IMvxCommand MagicWindowCommand { get; set; }

        public void MagicWindow()
        {
            //Open Magic Usercontrole
            EmptyView();

        }

        public IMvxCommand WorkWindowCommand { get; set; }

        public void WorkWindow()
        {
            //Open Work Usercontrole
            EmptyView();

        }

        public IMvxCommand FamilyWindowCommand { get; set; }

        public void FamilyWindow()
        {
            //Open Family Usercontrole
            if (FamilyViewVisbility == "Visible")
                EmptyView();
            else if (tempwindowopen)
            {
                EmptyView();
                ChangeView("Family");
            }
            else
                ChangeView("Family");
        }

        public IMvxCommand ActionsWindowCommand { get; set; }

        public void ActionsWindow()
        {
            if (ActionsViewVisbility == "Visible")
                EmptyView();
            else if (tempwindowopen)
            {
                EmptyView();
                ChangeView("Actions");
            }
            else
                ChangeView("Actions");
        }
        #endregion

        #region Databindings

        private String _Name;

        public String Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        private int _Age;

        public int Age
        {
            get { return _Age; }
            set { SetProperty(ref _Age, value); }
        }

        private String _Sex;

        public String Sex
        {
            get { return _Sex; }
            set { SetProperty(ref _Sex, value); }
        }

        private String _Race;

        public String Race
        {
            get { return _Race; }
            set { SetProperty(ref _Race, value); }
        }

        private String _Height;

        public String Height
        {
            get { return _Height; }
            set { SetProperty(ref _Height, value); }
        }

        private String _Weight;

        public String Weight
        {
            get { return _Weight; }
            set { SetProperty(ref _Weight, value); }
        }

        private String _Class;

        public String Class
        {
            get { return _Class; }
            set { SetProperty(ref _Class, value); }
        }

        private int _Level;

        public int Level
        {
            get { return _Level; }
            set { SetProperty(ref _Level, value); }
        }

        private string _Portrait = "/Images/ProfileBar/Character.png";

        public string Portrait
        {
            get { return _Portrait; }
            set { SetProperty(ref _Portrait, value); }
        }

        private string _CharacterSource = "/Images/ProfileBar/Character.png";

        public string CharacterSource
        {
            get { return _CharacterSource; }
            set { SetProperty(ref _CharacterSource, value); }
        }

        private ObservableCollection<string> _HistoryList;

        public ObservableCollection<string> HistoryList
        {
            get { return _HistoryList; }
            set { SetProperty(ref _HistoryList, value); }
        }

        private ObservableCollection<NPC> _FamilyList;

        public ObservableCollection<NPC> FamilyList
        {
            get { return _FamilyList; }
            set { SetProperty(ref _FamilyList, value); }
        }

        private int _strPB;

        public int strPB
        {
            get { return _strPB; }
            set { SetProperty(ref _strPB, value); }
        }

        private int _agiPB;

        public int agiPB
        {
            get { return _agiPB; }
            set { SetProperty(ref _agiPB, value); }
        }

        private int _conPB;

        public int conPB
        {
            get { return _conPB; }
            set { SetProperty(ref _conPB, value); }
        }

        private int _willPB;

        public int willPB
        {
            get { return _willPB; }
            set { SetProperty(ref _willPB, value); }
        }

        private int _intPB;

        public int intPB
        {
            get { return _intPB; }
            set { SetProperty(ref _intPB, value); }
        }

        private int _chaPB;

        public int chaPB
        {
            get { return _chaPB; }
            set { SetProperty(ref _chaPB, value); }
        }

        private int _HealthPB;

        public int HealthPB
        {
            get { return _HealthPB; }
            set { SetProperty(ref _HealthPB, value); }
        }

        private int _EnergiePB;

        public int EnergiePB
        {
            get { return _EnergiePB; }
            set { SetProperty(ref _EnergiePB, value); }
        }

        private NPC _FamSelect;

        public NPC FamSelect
        {
            get { return _FamSelect; }
            set { SetProperty(ref _FamSelect, value); OpenNPCUnitFrame(); }
        }


        private ObservableCollection<NPC> _NPCUnitFrame;

        public ObservableCollection<NPC> NPCUnitFrame
        {
            get { return _NPCUnitFrame; }
            set { SetProperty(ref _NPCUnitFrame, value); }
        }


        //Main Viewchanges on main view
        private string _HistoryViewVisbility = "Visible";

        public string HistoryViewVisbility
        {
            get { return _HistoryViewVisbility; }
            set { SetProperty(ref _HistoryViewVisbility, value); }
        }

        private string _CharacterViewVisbility = "Hidden";

        public string CharacterViewVisbility
        {
            get { return _CharacterViewVisbility; }
            set { SetProperty(ref _CharacterViewVisbility, value); }
        }

        private string _SkillsViewVisbility = "Hidden";

        public string SkillsViewVisbility
        {
            get { return _SkillsViewVisbility; }
            set { SetProperty(ref _SkillsViewVisbility, value); }
        }

        private string _ActionsViewVisbility = "Hidden";

        public string ActionsViewVisbility
        {
            get { return _ActionsViewVisbility; }
            set { SetProperty(ref _ActionsViewVisbility, value); }
        }

        private string _FamilyViewVisbility = "Hidden";

        public string FamilyViewVisbility
        {
            get { return _FamilyViewVisbility; }
            set { SetProperty(ref _FamilyViewVisbility, value); }
        }

        private string _NPCUnitFrameVisibility = "Hidden";

        public string NPCUnitFrameVisibility
        {
            get { return _NPCUnitFrameVisibility; }
            set { SetProperty(ref _NPCUnitFrameVisibility, value); }
        }


        #endregion

        #region UIControles
        private void ChangeView(string View)
        {

            switch (View)
            {
                case "Actions":
                    ActionsViewVisbility = "Visible";
                    break;

                case "Skills":
                    SkillsViewVisbility = "Visible";
                    break;

                case "Character":
                    CharacterViewVisbility = "Visible";
                    break;

                case "Family":
                    FamilyViewVisbility = "Visible";
                    break;
            }
            tempwindowopen = true;
        }

        private void EmptyView()
        {
            ActionsViewVisbility = "hidden";
            SkillsViewVisbility = "hidden";
            CharacterViewVisbility = "hidden";
            FamilyViewVisbility = "hidden";
            NPCUnitFrameVisibility = "hidden";
            tempwindowopen = false;
        }

        private void OpenNPCUnitFrame()
        {
            NPCUnitFrame = new ObservableCollection<NPC>();
            NPCUnitFrame.Add(FamSelect);
            NPCUnitFrameVisibility = "visible";

        }

        #endregion

        #region DataControl

        private void EndTurn()
        {
            Data.EndTurn();

            ResetFamList();
            //AddHistory("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec rhoncus, diam ac aliquet pretium, velit enim porta ipsum, non eleifend elit enim ut massa. In at interdum leo. Nunc sed nisi nec magna finibus dictum. Nam ultrices pulvinar augue, vel gravida est gravida a. Quisque feugiat vulputate lectus sed hendrerit. Curabitur enim risus, rutrum efficitur volutpat ac, auctor quis neque. Nullam finibus ligula sapien, vitae dapibus eros molestie vitae.");
            // for testing
        
        }

        //Creating the player
        private void RetreivePlayer()
        {
            Name = Data.Player.FirstName + " " + Data.Player.LastName;
            Age = Data.Player.Age;
            Sex = Data.Player.Sex;
            Race = Data.Player.Race;

            strPB = Data.Player.Strenght;
            agiPB = Data.Player.Agility;
            conPB = Data.Player.Constitution;
            willPB = Data.Player.Willpower;
            intPB = Data.Player.Intelligence;
            chaPB = Data.Player.Charisma;

            HealthPB = Data.Player.Health;
            EnergiePB = Data.Player.Energie;

        }

        private void ResetFamList()
        {
            FamilyList = null;
            FamilyList = Data.Family;
        }

        #endregion
    }
}
