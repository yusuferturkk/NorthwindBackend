using NorthwindBackend.CoreLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.BusinessLayer.Constants
{
    public static class Messages
    {
        public static string AddedProduct = "Ürün başarıyla eklendi.";
        public static string DeletedProduct = "Ürün başarıyla silindi.";
        public static string UpdatedProduct = "Ürün başarıyla güncellendi.";
        public static string AddedCategory = "Kategori başarıyla eklendi.";
        public static string DeletedCategory = "Kategori başarıyla silindi.";
        public static string UpdatedCategory = "Kategori başarıyla güncellendi.";
        public static string AddedUser = "Kullanıcı başarıyla eklendi.";

        public static string UserNotFound = "Kullanıcı bulunamadı!";
        public static string PasswordError = "Şifre hatalı!";
        public static string SuccessfulLogin = "Sisteme giriş başarılı.";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut.";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi.";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu.";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut.";
    }
}
