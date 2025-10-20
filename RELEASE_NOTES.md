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
