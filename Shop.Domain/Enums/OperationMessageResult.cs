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
        [Display(Name = "نام کاربری وجود ندارد.")]
        UserNameExist = 6,
        [Display(Name = "شماره موبایل وجود ندارد.")]
        PhoneNumberExist = 7,
        #endregion

        #region Inventory
        [Display(Name = "انبار یافت نشد.")]
        InventoryNotFound = 8,
        #endregion

        #region Property
        [Display(Name = "ویژگی یافت نشد.")]
        PropertyNotFound = 9,
        #endregion

        #region UserAddress
        [Display(Name = "آدرس کاربر یافت نشد.")]
        UserAddressNotFound = 10,
        #endregion

        #region Category
        [Display(Name = "دسته بندی کاربر یافت نشد.")]
        CategoryNotFound = 11,
        [Display(Name = "امکان حذف دسته بندی نمی باشد")]
        CanNotDeleteCategory = 12,
        #endregion

        #region Order
        [Display(Name = "سفارش یافت نشد.")]
        OrderNotFound = 13,
        #endregion

        #region Product
        [Display(Name = "محصول یافت نشد.")]
        ProductNotFound = 14,
        #endregion

        #region Profile
        [Display(Name = "اطلاعات کاربر یافت نشد.")]
        ProfileNotFound = 15,
        #endregion
    }
}
