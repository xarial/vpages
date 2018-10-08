using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Framework.Base
{
    public interface IBinding
    {
        event Action<IBinding> ModelUpdated;
        event Action<IBinding> ControlUpdated;

        IControl Control { get; }
        object Model { get; }

        void UpdateControl();
        void UpdateDataModel();
    }
}
