using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.VPages.Core;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.Framework.Core;
using Xarial.VPages.Framework.PageElements;

namespace Xarial.VPages.WinForms
{
    public interface IFormControl : IControl
    {
    }

    public abstract class FormControl<TVal> : Control<TVal>, IFormControl
    {
        internal abstract System.Windows.Forms.Control Control { get; }
    }
}
