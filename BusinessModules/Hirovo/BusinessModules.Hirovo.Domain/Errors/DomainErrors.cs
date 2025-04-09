namespace BusinessModules.Hirovo.Domain.Errors;

public class DomainErrors
{

    public class JobErrors
    {
        public static object IdNotValid { get; set; } = "İş ilanı ID'si geçersiz.";
        public static object JobNotFound { get; set; } = "İş ilanı bulunamadı.";
        public static object JobAlreadyExists { get; set; } = "İş ilanı zaten mevcut.";
        public static object JobNotActive { get; set; } = "İş ilanı aktif değil.";
        public static object JobAlreadyApplied { get; set; } = "İş ilanına zaten başvurulmuş.";
        public static object JobApplicationNotFound { get; set; } = "İş başvurusu bulunamadı.";
        public static object JobApplicationAlreadyExists { get; set; } = "İş başvurusu zaten mevcut.";
        public static object JobApplicationNotActive { get; set; } = "İş başvurusu aktif değil.";
        public static object JobApplicationAlreadyAccepted { get; set; } = "İş başvurusu zaten kabul edilmiş.";
        public static object JobApplicationAlreadyRejected { get; set; } = "İş başvurusu zaten reddedilmiş.";
        public static object JobApplicationAlreadyCancelled { get; set; } = "İş başvurusu zaten iptal edilmiş.";
    }

    public class WorkerErrors
    {
        public static string WorkerNotFound { get; set; } = "İşçi bulunamadı.";
        public static string PhoneNumberInvalid { get; set; } = "Telefon numarası geçersiz.";
        public static string UserIdNotValid { get; set; } = "Kullanıcı ID'si geçersiz.";
        public static string UserIdNotExist { get; set; } = "Kullanıcı bulunamadı.";
        public static string UserIdNotValidOrDeleted { get; set; } = "Kullanıcı geçersiz veya silinmiş.";
    }
}
