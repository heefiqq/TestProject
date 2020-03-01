using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTest.Core.Data.Enums
{
    public enum ETrackEvent
    {
        #region filter events

        Filter_CustomerId,
        Filter_Name,
        Filter_BirthDay,
        Filter_Gender,
        Filter_QuantityRequest,

        #endregion

        #region sort events

        Sort_Asc_CustomerId,
        Sort_Desc_CustomerId,
        Sort_Asc_Name,
        Sort_Desc_Name,
        Sort_Asc_BirthDay,
        Sort_Desc_BirthDay,
        Sort_Asc_Gender,
        Sort_Desc_Gender,
        Sort_Asc_QuantityRequest,
        Sort_Desc_QuantityRequest

        #endregion
    }
}
