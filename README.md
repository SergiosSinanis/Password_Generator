# Password_Generator
A secure and customizable password generator built in C#. This console application allows users to create strong passwords with various character combinations.

## Features:

- Custom password length (1-100 characters)
- Multiple character type options:

- Uppercase letters (A-Z)
- Lowercase letters (a-z)
- Numbers (0-9)
- Special symbols (!@#$%^&*()_+-=[]{}|;:',.<>?/)

### Includes:
- Input validation
- Error handling
- User-friendly interface
- Flexible character set combinations

## Requirements:

- .NET 6.0 or higher
- Visual Studio 2022 or compatible IDE

## How to Use:

- Run the application
- Enter desired password length
- Specify character types (upper, lower, numbers, symbols)
- Get your generated password
- Choose to generate another or exit

### Example Usage:
Input: "12, upper, numbers"
Output: Generated password with 12 characters containing uppercase letters and numbers
Example Commands:

"8, lower, numbers" - 8 characters with lowercase and numbers
"16, upper, lower, symbols" - 16 characters with uppercase, lowercase, and symbols
"20, upper, lower, numbers, symbols" - 20 characters with all character types

## Error Handling:

- Invalid length detection
- Unknown character type validation
- Empty input protection
- Overflow protection

## Best Practices:

Use longer passwords (12+ characters) for better security
Combine multiple character types
Avoid using personal information
Generate new passwords regularly

## Contributing:

Fork the repository
Create a feature branch
Make your changes
Submit a pull request

## Security Note:
This generator uses C#'s Random class for password generation. While suitable for general use, for cryptographic purposes, consider using RNGCryptoServiceProvider.

## License:
Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.

## Contact:
sergiosinanis@gmail.com

## Support:
For bugs, feature requests, or questions, please open an issue in the GitHub repository.

### Version History:
1.0.0 - Initial release

- Basic password generation
- Character type selection
- Input validation
- Error handling

## Future Improvements:

- Password strength meter
- Save password history
- GUI interface
- Custom character sets
- Password encryption
- Multiple password generation
