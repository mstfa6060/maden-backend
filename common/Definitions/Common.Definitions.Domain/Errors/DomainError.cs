namespace Common.Definitions.Domain.Errors;

public class DomainErrors
{
    public class AuthErrors
    {
        // Model Validation
        public static string UserIdNotValid { get; set; } = "";

        // Database Validation
        public static string UserNotExist { get; set; } = "";
        public static string UserBlocked { get; set; } = "";
        public static string UserBanned { get; set; } = "";
        public static string UserDeleted { get; set; } = "";
        public static string AdAccountsCanBeDeletedByAdministrator { get; set; } = "";
        public static string UserCanDeleteOnlyOwnAccount { get; set; } = "";
        public static string EmailOrPasswordIncorrect { get; set; } = "";
        public static string UserLoginCodeNotBelongToRequestedUser { get; set; } = "";
        public static string UserLoginCodeIsExpired { get; set; } = "";
        public static string UserLoginCodeIsNotExpired { get; set; } = "";
        public static string UserLoginCodeIsNotCorrect { get; set; } = "";
        public static string UserLoginCodeNotExist { get; set; } = "";
        public static string DeviceIdNotValid { get; set; } = "";
        public static string ApprovalExpired { get; set; } = "";
        public static string ApprovalHasOwner { get; set; } = "";
        public static string ApprovalStatusIsInvalid { get; set; } = "";
        public static string UserCanOnlyMakeActionsForSelf { get; set; } = "";
        public static string ApprovalNotFound { get; set; } = "";
        public static string QrCounterHasException { get; set; } = "";
        public static string QrJobTaskCancelled { get; set; } = "";
        public static string QrJobTaskHasException { get; set; } = "";
        public static string IdentityNumberCannotBeEmpty { get; set; } = "";
        public static string IdentityNumberIsInvalid { get; set; } = "";
        public static string VerificationIdCannotBeEmpty { get; set; } = "";
        public static string VerificationIdInvalidFormat { get; set; } = "";
        public static string VerificationEnvironmentInvalidFormat { get; set; } = "";
        public static string VerificationMerkezBirligiUserCanLogin { get; set; } = "";
        public static string TenantIdIsNotGuidEmpty { get; set; } = "";
    }
    public class CommonErrors
    {
        // Model Validation
        public static string NameValid { get; set; } = "";
        public static string LocationIdNotValid { get; set; } = "";
        public static string DepartmanIdNotValid { get; set; } = "";

        // Database Validation
        public static string UserNotExist { get; set; } = "";
        public static string EkoopUserNotExist { get; set; } = "";
        public static string ModuleNotExist { get; set; } = "";
        public static string UniversityNotExist { get; set; } = "";
        public static string CompanyNotExist { get; set; } = "";
        public static string CompanyPartnershipNotExist { get; set; } = "";
        public static string CompanyManagementNotExist { get; set; } = "";
        public static string LocationNotExist { get; set; } = "";
        public static string DepartmentNotExist { get; set; } = "";
        public static string DepartmentUnitNotExist { get; set; } = "";
        public static string TitleNotExist { get; set; } = "";
        public static string QualificationNotExist { get; set; } = "";
        public static string ProcessNotExist { get; set; } = "";
        public static string ProcessStepNotExist { get; set; } = "";
        public static string GroupNotExist { get; set; } = "";
        public static string QualificationHasBeenDeleted { get; set; } = "";
        public static string FileBucketIdCanNotBeEmpty { get; set; } = "";
        public static string DescriptionCanNotBeEmpty { get; set; } = "";

    }

    public class CityErrors
    {
        // Model Validation

        // Database Validation
        public static string CityNotExist { get; set; } = "";

    }
    public class CompanyErrors
    {
        // Model Validation

        // Database Validation
        public static string UserDoesNotBelongToThisCompany { get; set; } = "";

    }
    public class SystemAdminErrors
    {
        // Model Validation

        // Database Validation
        public static string SystemAdminNotExist { get; set; } = "";
        public static string UserAlreadyRegisteredAsSystemAdmin { get; set; } = "";
        public static string OnlySystemAdminPermitted { get; set; } = "";
        public static string OnlyBussinesModuleAccepted { get; set; }
    }

    public class CompanyAdminErrors
    {
        // Model Validation

        // Database Validation
        public static string CompanyAdminNotExist { get; set; } = "";
        public static string UserAlreadyRegisteredAsCompanyAdmin { get; set; } = "";
        public static string OnlySystemAdminOrCompanyAdminPermitted { get; set; } = "";
        public static string UserNotPermitted { get; set; } = "";
    }

    public class ModuleAdminErrors
    {
        // Model Validation

        // Database Validation
        public static string ModuleAdminNotExist { get; set; } = "";
        public static string UserAlreadyRegisteredAsModuleAdmin { get; set; } = "";
        public static string OnlySystemAdminOrModuleAdminPermitted { get; set; } = "";
    }

    public class AuthorizedModuleErrors
    {
        // Model Validation

        // Database Validation
        public static string AuthorizedModuleNotExist { get; set; } = "";
        public static string AuthorizedModuleAlreadyExist { get; set; } = "";
        // public static string OnlyCompanyAdminPermitted { get; set; } = "";
    }

    public class CompanyResourceErrors
    {
        // Model Validation

        // Database Validation
        public static string CompanyResourceNotExist { get; set; } = "";

    }
    public class UserProxyErrors
    {
        public static string UserProxyNotExist { get; set; } = "";
        public static object EndDateCantBeSmallerThanThisHour { get; set; }
        public static object EndDateCantBeSmallerThanStartDate { get; set; }
    }
    public class CompanySettingErrors
    {
        public static string CompanySettingNotExist { get; set; } = "";
        public static string CompanyIdNotExist { get; set; } = "";
    }

    public class AuthorizationServiceErrors
    {
        public static string UserDoesNotHaveSufficientPermission { get; set; } = "";
        public static string UserIsBanned { get; set; } = "";
        public static string CrossTenantDataAccessNotPermtted { get; set; } = "";
        public static string NamespaceNotFound { get; set; } = "";
        public static string TenantRelationError { get; set; } = "";
    }
    public class PollErrors
    {
        public static string PollIdNotValid { get; set; } = "";
        public static string PollCompanyIdNotValid { get; set; } = "";
        public static string PollOptionIdNotValid { get; set; } = "";
        public static string PollAnswerIdNotValid { get; set; } = "";

    }
    public class AnnouncementErrors
    {
        public static string AnnouncementIdNotValid { get; set; } = "";
        public static string AnnouncementCompanyIdNotValid { get; set; } = "";
        public static string AnnouncementNotFound { get; set; } = "";


    }
    public class EventErrors
    {
        public static string EventIdNotValid { get; set; } = "";
        public static string EventCompanyIdNotValid { get; set; } = "";
        public static string EventNotFound { get; set; } = "";

    }
    public class InstrumentErrors
    {
        public static string InstrumentIdNotValid { get; set; } = "";


    }

    public class RoleErrors
    {
        public static string NameValid { get; set; } = "";
        public static string IdValid { get; set; } = "";
        public static string IncludeDeletedValid { get; set; } = "";

    }

    public class UserErrors
    {
        public static string UserNameValid { get; set; } = "Geçersiz kullanıcı adı.";
        public static string EmailValid { get; set; } = "Geçersiz e-posta adresi.";

        // Şifre ile ilgili hata kodları
        public static string PasswordRequired { get; set; } = "Şifre zorunludur.";
        public static string PasswordTooShort { get; set; } = "Şifre en az 6 karakter olmalıdır.";
        public static string PasswordMustContainUppercase { get; set; } = "Şifre en az bir büyük harf içermelidir.";
        public static string PasswordMustContainLowercase { get; set; } = "Şifre en az bir küçük harf içermelidir.";
        public static string PasswordMustContainDigit { get; set; } = "Şifre en az bir rakam içermelidir.";
        public static string UserNotFound { get; set; } = " Kullanıcı bulunamadı.";

    }
}