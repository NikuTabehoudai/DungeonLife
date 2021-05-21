using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.ViewModels;
using MvvmCross.Core;
using DungeonLife.Core.ViewModels;

namespace DungeonLife.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<DungeonLifeViewModel>();
        }
    }
}
