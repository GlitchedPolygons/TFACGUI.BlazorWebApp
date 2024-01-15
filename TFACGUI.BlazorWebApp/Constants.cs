namespace TFACGUI.BlazorWebApp;

public static class Constants
{
    public static class ElementIds
    {
        public const string USER_DATA = "UserData";
        public const string IMPORT_PW = "importPassword";
        public const string EXPORT_PW = "exportPassword";
        public const string EXPORT_PW_CONFIRMATION = "exportPasswordConfirmation";
        public const string BACKUP_ENCRYPTION_CIPHERTEXT = "encryptionCiphertext";
        public const string BACKUP_DECRYPTION_CIPHERTEXT = "decryptionCiphertext";
        public const string COPY_EXPORTED_BACKUP_BUTTON = "copyExportedBackupButton";
        
        public const string TOTP_SECRET = "totpSecret";
    }

    public static class InteropFunctionNames
    {
        public const string ALERT_DIALOG = "alert";
        public const string CONFIRM_DIALOG = "confirm";
        public const string GET_INPUT_VALUE = "GetInputValue";
        public const string SET_INPUT_VALUE = "SetInputValue";
        public const string GET_LOCALSTORAGE_VALUE = "localStorage.getItem";
        public const string SET_LOCALSTORAGE_VALUE = "localStorage.setItem";
        public const string COPY_TO_CLIPBOARD = "navigator.clipboard.writeText";
        public const string INIT_COPY_BUTTON_LABEL = "InitCopyButtonLabel";
        public const string PRESS_COPY_BUTTON_PORTABLE = "PressCopyButtonPortable";
    }
    
    public static class AesGcm
    {
        public const int NONCE_SIZE_BYTES = 12;
        public const int MAC_SIZE_BYTES = 16;
        public const int TAG_SIZE_BYTES = 16;
        public const int KEY_SIZE_BYTES = 32;
    }
    
    public static readonly char[] KEYGEN_LEGAL_CHARS =
    [
        '0',
        '1',
        '2',
        '3',
        '4',
        '5',
        '6',
        '7',
        '8',
        '9',
        'a',
        'b',
        'c',
        'd',
        'e',
        'f',
        'g',
        'h',
        'i',
        'j',
        'k',
        'l',
        'm',
        'n',
        'o',
        'p',
        'q',
        'r',
        's',
        't',
        'u',
        'v',
        'w',
        'x',
        'y',
        'z',
        'A',
        'B',
        'C',
        'D',
        'E',
        'F',
        'G',
        'H',
        'I',
        'J',
        'K',
        'L',
        'M',
        'N',
        'O',
        'P',
        'Q',
        'R',
        'S',
        'T',
        'U',
        'V',
        'W',
        'X',
        'Y',
        'Z',
        '-',
        '_',
        '*',
        '@',
        ',',
        '.',
        '+',
        '#'
    ];
}