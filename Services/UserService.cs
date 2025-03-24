using InstrumentsApp.Models;
using InstrumentsApp.Context;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace InstrumentsApp.Services {
    public class UserService {
        private readonly DataContext _context;
        private readonly PasswordHasher<User> _passwordHasher;
        private User? _loggedInUser;
        public UserService(DataContext context) {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }
        static bool IsValidEmail(string email) {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
        public bool CheckAuth(out string message) {
            if (!this.IsAuthenticated()) {
                message = "Log in to add items to cart.";
                return false;
            }
            message = string.Empty;
            return true;
        }
        public bool IsAuthenticated() => _loggedInUser != null;
        public void Logout() => _loggedInUser = null;
        public int GetLoggedUserId() => _loggedInUser?.Id ?? 0;
        public bool RegisterUser(string email, string password, out string message) {
            if (!IsValidEmail(email)) {
                message = "Email is not valid";
                return false;
            }
            try {
                if (_context.Users.Any(u => u.Email == email)) {
                    message = "User already exists";
                    return false;
                }
                var user = new User {
                    Email = email,
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, password);
                _context.Users.Add(user);
                _context.SaveChanges();
                message = "Registration successful";
                return true;
            }
            catch (Exception ex) { 
                message = ex.Message;
                return false;
            }
            
        }
        public bool Login(string email, string password, out string message) {
            try {
                var user = _context.Users.FirstOrDefault(u => u.Email == email);
                if (user != null && _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Success) {
                    _loggedInUser = user;
                    message = "Login successful";
                    return true;
                }
                message = "Invalid login credentials.";
                return false;
            }
            catch (Exception ex) {
                message=ex.Message;
                return false;
            }
        }
    }
}
