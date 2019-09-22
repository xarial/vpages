using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xarial.VPages.Framework.Attributes;
using Xarial.VPages.Framework.Base;
using Xarial.VPages.WinForms;

namespace WinFormExample
{
    public enum ControlTags_e
    {
        Option,
        Number
    }

    public class MyDependencyHandler : IDependencyHandler
    {
        public void UpdateState(IBinding binding, IBinding[] dependencies)
        {
            foreach (var dep in dependencies)
            {
                (binding.Control as IFormControl).Control.Enabled = (bool)dep.Control.GetValue();
            }
        }
    }

    public class DataModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public class DataGroup : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private string m_GroupTextField1;

            public string GroupTextField1
            {
                get
                {
                    return m_GroupTextField1;
                }
                set
                {
                    m_GroupTextField1 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GroupTextField1)));
                }
            }

            public string GroupTextField2 { get; set; }
            public decimal NumberField1 { get; set; }
            public decimal NumberField2 { get; set; }

            [IgnoreBinding]
            public decimal NumberField3 { get; set; }
            
            public string GroupTextField4 { get; set; }

            public string GroupTextField5 { get; set; }
        }

        private bool m_Option;

        public string TextField { get; set; }

        [ControlTag(ControlTags_e.Number)]
        [DependentOn(typeof(MyDependencyHandler), ControlTags_e.Option)]
        public decimal NumberField { get; set; }
        
        [ControlTag(ControlTags_e.Option)]
        public bool Option
        {
            get
            {
                return m_Option;
            }
            set
            {
                m_Option = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Option)));
            }
        }

        public DataGroup Group { get; set; }

        public Action Button => OnButtonClick;

        private void OnButtonClick()
        {
            Group.GroupTextField1 = "Hello";
            Option = !Option;
        }
    }
}
