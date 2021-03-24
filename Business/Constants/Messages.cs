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

        public static string UserAlreadyExists = "Kullanıcı Mevcut";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserNotFound = "Kullanıcı bulunamadı!";
        public static string PasswordError = "Parola hatası";
        public static string UserRegistered = "Kullanıcı kaydı yapıldı";

        public static string AccessTokenCreated = "Token Oluşturuldu !!";
    }
}
