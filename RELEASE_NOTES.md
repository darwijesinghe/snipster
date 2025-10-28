# Release Notes

## [v1.0.0] - 2025-08-12
### Summary
Initial release with core helper methods and extensions for common operations.

### Added
- Core helper utilities for strings, numbers, and JSON.

---

## [v1.0.1] - 2025-08-14
### Summary
Maintenance update focusing on cleanup and reducing dependencies.

### Changed
- Removed unused package references.
- Performed code cleanup.

---

## [v1.0.2] - 2025-08-22
### Summary
Introduced new helper utilities and EF Core transaction support to simplify development.

### Added
- File helper utilities.
- Network helper utilities.
- EF Core transaction support with `IUnitOfWork` and default `IGenericRepository`.

---

## [v1.0.3] - 2025-10-08
### Summary
Introduced a new helper utility to handle writing data to Excel files and memory streams. And enhancements to `JsonValEx`, `CollectionEx`, and fixed some typo issues.

### Added
- Excel file helper utility.

## [v1.0.4] - 2025-10-20
### Summary
Introduces new object manipulation and validation utilities, along with 
enhanced network helpers, and fixed typo issues.

### Added
- Network validation extensions
    - `IsValidIPv6()`
    - `IsValidWebAddress()`
- object validation extensions
    - `IsDefaultValue()`
    - `HasProperty()`
- Object extensions
    - `GetPropertyValue()`
    - `SetPropertyValue()`
- Network helpers
    - `HasInternetConnectionAsync()`
- Object helpers
    - `DeepClone<T>(T)`

## [v1.0.5] - 2025-10-28
### Summary
The `IsValidEmail` method now handles a wider range of valid email formats, including internationalized domain names.
The `IsStrongPassword` method has been enhanced to recognize Unicode scripts and provide more comprehensive strength validation.

### Changed
- `IsValidEmail`

    - Added support for internationalized (Unicode) email addresses.
    - Improved regex validation to reject invalid formats (e.g. consecutive dots, invalid characters).
    - Retains built-in MailAddress parsing for RFC compliance.

- `IsStrongPassword`

    - Added full Unicode support, including non-Latin scripts such as Japanese and Chinese.
    - Enhanced strength criteria to handle both cased (A–Z/a–z) and uncased scripts correctly.
    - Improved regex detection for digits, symbols, and punctuation characters.

- Other

    - Improved test coverage for edge cases and Unicode-based inputs.
    - Minor documentation refinements for DocFX and IntelliSense clarity.
