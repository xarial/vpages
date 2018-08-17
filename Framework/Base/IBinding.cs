using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Xarial.VPages.Framework.Base
{
    public interface IBinding
    {
        void UpdateUserControl();
        void UpdateDataModel();
    }
}
