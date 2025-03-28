using InstrumentsApp.Context;
using InstrumentsApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstrumentsApp.Services {
    public static class CartService {
        private static Cart? _cart;
        public static Cart? GetCart(UserService userService) {
            var context = Program.ServiceProvider.GetRequiredService<DataContext>();
            try {
                if (!userService.IsAuthenticated()) return null;
                var cart = context.Cart.Include(i => i.Items).FirstOrDefault(x => x.UserId == userService.GetLoggedUserId());
                if (cart == null) {
                    cart = new Cart() { UserId = userService.GetLoggedUserId() };
                    context.Add(cart);
                    context.SaveChanges();
                }
                _cart = cart;
                return cart;
            }
            catch (Exception ex) {
                Utilities.MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static bool CheckStock(Instrument instrument, out string message) {
            if (instrument.Stock == 0) {
                message = $"{instrument.Name} is out of stock!";
                return false;
            }
            else if (instrument.Stock <= _cart?.Items.FirstOrDefault(x => x.Instrument == instrument)?.Quantity) {
                message = $"The cart amount is already same value as in stock.";
                return false;
            };
            message = string.Empty;
            return true;
        }
        public static void UpdateStockMinus(Instrument instrument, int amount) {
            try {
                instrument.Stock -= amount;
            }
            catch {

            }
        }
    }
}
