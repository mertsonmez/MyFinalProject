using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //static classlar newlenmez!!
        //publicler pascal case yazılır !! yoksa fieldlar küçük harfle başlar!!
        public static string ProductAdded = "Ürün eklendi";
        //fluent validation kullanacağız daha sonra ??
        public static string ProductNameInvalid = "Ürün ismi geçersiz";

        public static string MaintenanceTime = "Sistem bakımda !!";

        public static string ProductsListed = "Ürünler listelendi";

        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";

        public static string ProductNameAlreadyExists = "Böyle bir isimde ürün mevcut";

        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";

        public static string AuthorizationDenied = "Yetkiniz yok !!";

        public static string UserAlreadyExists { get; internal set; }
        public static string SuccessfulLogin { get; internal set; }
        public static User UserNotFound { get; internal set; }
        public static User PasswordError { get; internal set; }
        public static string UserRegistered { get; internal set; }
        public static string AccessTokenCreated { get; internal set; }
    }
}
