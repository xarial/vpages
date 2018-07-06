using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Core;

namespace Xarial.VPages.WinForms
{
    public interface IFormControl : IControl
    {
    }

    public abstract class FormControl<TVal> : Control<TVal>, IFormControl
    {
    }
}
