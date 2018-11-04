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
        System.Windows.Forms.Control Control { get; }
    }

    public abstract class FormControl<TVal> : Control<TVal>, IFormControl
    {
        public FormControl(int id, object tag) : base(id, tag)
        {
        }

        public abstract System.Windows.Forms.Control Control { get; }
    }
}
