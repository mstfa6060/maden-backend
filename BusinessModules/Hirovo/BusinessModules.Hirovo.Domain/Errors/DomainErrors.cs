namespace BusinessModules.Hirovo.Domain.Errors;

public class DomainErrors
{
    public class WorkerErrors
    {
        public static string WorkerNotFound { get; set; } = "İşçi bulunamadı.";
        public static string PhoneNumberInvalid { get; set; } = "Telefon numarası geçersiz.";
        public static string UserIdNotValid { get; set; } = "Kullanıcı ID'si geçersiz.";
        public static string UserIdNotExist { get; set; } = "Kullanıcı bulunamadı.";
        public static string UserIdNotValidOrDeleted { get; set; } = "Kullanıcı geçersiz veya silinmiş.";
    }
}
