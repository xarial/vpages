﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using Xarial.VPages.Core.Constructors;

namespace Xarial.VPages.WinForms
{
    public class PageConstructor : IPageConstructor<Page>
    {
        public Page Create(AttributeSet atts)
        {
            return new Page();
        }
    }
}
