//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace UnitTestProject1.EF4Behaviour
{
    public partial class EF4Detail
    {
        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual EFMaster EFMaster
        {
            get { return _eFMaster; }
            set
            {
                if (!ReferenceEquals(_eFMaster, value))
                {
                    var previousValue = _eFMaster;
                    _eFMaster = value;
                    FixupEFMaster(previousValue);
                }
            }
        }
        private EFMaster _eFMaster;

        #endregion

        #region Association Fixup
    
        private void FixupEFMaster(EFMaster previousValue)
        {
            if (previousValue != null && previousValue.EF4Detail.Contains(this))
            {
                previousValue.EF4Detail.Remove(this);
            }
    
            if (EFMaster != null)
            {
                if (!EFMaster.EF4Detail.Contains(this))
                {
                    EFMaster.EF4Detail.Add(this);
                }
            }
        }

        #endregion

    }
}