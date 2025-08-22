using System;
using System.IO;
using System.Text;

namespace Snipster.Library.Helpers
{
    /// <summary>
    /// A class that provides file-related utility functions.
    /// </summary>
    public class FileFx
    {
        /// <summary>
        /// Safely reads the content of a text file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="encoding">The encoding to use for reading the file. Defaults to UTF8.</param>
        /// <returns>
        /// The content of the file as a string, or null if an error occurs.
        /// </returns>
        public static string? SafeReadText(string path, Encoding? encoding = null)
        {
            try
            {
                return File.ReadAllText(path, encoding ?? Encoding.UTF8);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Safely reads the content of a binary file as a byte array.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>
        /// The content of the file as a byte array, or null if an error occurs.
        /// </returns>
        public static byte[]? SafeReadBytes(string path)
        {
            try
            {
                return File.ReadAllBytes(path);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Safely writes text content to a file, creating the file if it does not exist or overwriting it if it does.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="content">The content to write to the file.</param>
        /// <param name="encoding">The encoding to use for writing the file. Defaults to UTF8.</param>
        /// <returns>
        /// True if the write operation was successful; otherwise, false.
        /// </returns>
        public static bool SafeWriteText(string path, string content, Encoding? encoding = null)
        {
            try
            {
                File.WriteAllText(path, content, encoding ?? Encoding.UTF8);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Safely writes a byte array to a file, creating the file if it does not exist or overwriting it if it does.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="data">The byte array to write to the file.</param>
        /// <returns>
        /// True if the write operation was successful; otherwise, false.
        /// </returns>
        public static bool SafeWriteBytes(string path, byte[] data)
        {
            try
            {
                File.WriteAllBytes(path, data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Creates a temporary file with a unique name in the system's temporary directory.
        /// </summary>
        /// <param name="extension">The file extension for the temporary file. Defaults to ".tmp".</param>
        /// <returns>
        /// The path to the created temporary file, or null if an error occurs.
        /// </returns>
        public static string? CreateTempFile(string extension = ".tmp")
        {
            try
            {
                if (!extension.StartsWith(".")) extension = "." + extension;

                string path;

                // loop until we find a unique file name
                do
                {
                    // generate a unique file name in the temp directory
                    path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + extension);

                } while (File.Exists(path));

                // ensure file exists
                File.Create(path).Dispose();

                return path;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Calculates the total size of a directory, including all its subdirectories and files.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <returns>
        /// The total size of the directory in bytes, or 0 if the directory does not exist or an error occurs.
        /// </returns>
        public static long GetDirectorySize(string path)
        {
            if (!Directory.Exists(path)) return 0;

            long size = 0;
            try
            {
                // get the size of all files in the directory and its subdirectories
                foreach (var file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
                {
                    size += new FileInfo(file).Length;
                }
            }
            catch (Exception)
            {
                // handle exceptions as needed, e.g., log them
            }

            return size;
        }

        /// <summary>
        /// Sanitizes a file name by replacing all invalid file name characters 
        /// with a specified replacement string (default is underscore).
        /// </summary>
        /// <param name="fileName">The original file name to sanitize.</param>
        /// <param name="replacement">The string used to replace invalid characters. Defaults to "_".</param>
        /// <returns>
        /// A sanitized file name where invalid characters are replaced, or null if an error occurs.
        /// </returns>
        public static string? SanitizeFileName(string fileName, string replacement = "_")
        {
            try
            {
                // get the list of characters that are not allowed in file names on the current platform
                var invalidChars = Path.GetInvalidFileNameChars();

                // replace each invalid character with the provided replacement string
                foreach (var c in invalidChars)
                {
                    fileName = fileName.Replace(c.ToString(), replacement);
                }

                return fileName;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
