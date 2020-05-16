using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.SSOT
{
    public enum ProjectStatusSSOT
    {
        NoRecord = 0,


        /// <summary>
        /// زمانی که پروژه ایجاد شده است و هنوز دست کسی هست که آن را ایجاد کرده است
        /// در این جالت کاربر هنوز میتواند به آن تسک جدید اضافه کند
        /// </summary>
        Customer = 1,

        /// <summary>
        /// زمانی که پروژه دست ادمین کاستومر میرود
        /// در این حالت کاستومر‌ها دیگر توانایی ایجاد تسک جدید بر روی آن را ندارند
        /// </summary>
        AdminCustomer = 2,

        /// <summary>
        /// زمانی که پروژه ایی از دست ادمین کاستومر خارح می‌شود و  باید به دست ادمین اصلی سایت برود
        /// </summary>
        Admin = 3,


        /// <summary>
        /// از طرف ادمین دوباره به دست ادمین کاستومر فرستاده می شود 
        /// تا آن فرد پرداختی لازم را انجام دهد
        /// </summary>
        AdminCustomerShoudPay = 4,

        Progressing = 5,

        //Delivery = 6,


        Success = 6,
        Deny = 7

    }
}
