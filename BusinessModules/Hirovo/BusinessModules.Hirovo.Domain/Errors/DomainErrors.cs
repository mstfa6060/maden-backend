namespace BusinessModules.Hirovo.Domain.Errors;

public class DomainErrors
{
    public class WorkerErrors
    {
        public static string WorkerNotFound { get; set; } = "İşçi bulunamadı.";
        public static string PhoneNumberInvalid { get; set; } = "Telefon numarası geçersiz.";
    }
}
