﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Framework.Core;

namespace Xarial.VPages.Framework.Base
{
    public interface IDependencyManager
    {
        void Init(IRawDependencyGroup depGroup);
    }
}
