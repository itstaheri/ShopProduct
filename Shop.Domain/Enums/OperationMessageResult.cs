using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shop.Domain.Enums
{
    public enum OperationMessageResult
    {
        #region general
        [Display(Name = "عملیات با موفقیت انجام شد.")]
        OperationSuccess = 1,
        [Display(Name = "عملیات با شکست مواجه شد.")]
        OperationFailed = -1,
        [Display(Name = "عملیات لغو شد.")]
        OperationCancelled = 3,
        [Display(Name = "خطای سیستمی")]
        InternalServerError = -1,
        #endregion

        #region user service
        [Display(Name ="کاربر یافت نشد.")]
        UserInvalid = 4,
        [Display(Name ="کاربر غیرفعال است.")]
        UserIsDeActive = 5,
        #endregion

        #region Inventory
        [Display(Name = "انبار یافت نشد.")]
        InventoryNotFound = 6,
        #endregion

        #region Property
        [Display(Name = "ویژگی یافت نشد.")]
        PropertyNotFound = 7,
        #endregion

        #region UserAddress
        [Display(Name = "آدرس کاربر یافت نشد.")]
        UserAddressNotFound = 8,
        #endregion
    }
}
