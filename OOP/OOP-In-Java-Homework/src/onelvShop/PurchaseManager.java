package onelvShop;

public final class PurchaseManager {
	private PurchaseManager() {
	}
	
	public static void ProcessPurchase(Customer customer, Product product) throws ProductManagementException {
		if (product instanceof FoodProduct) {
			if (((FoodProduct) product).isExpired()) {
				throw new ProductHasExpiredException();
			}
		}
		
		if (product.getQuantity() < 1) {
			throw new ProductOutOfStockException();
		}
		
		if (customer.getBalance().compareTo(product.getPrice()) == -1) {
			throw new CustomerinsufficientBalanceException();
		}
		
		if (product.ageRestrictionLevel == AgeRestriction.Adult &&
				customer.getAge() < 18) {
			throw new CustomerNoPermissionToBuyException();
		}
		
		customer.setBalance(customer.getBalance().subtract(product.getPrice()));
		product.setQuantity(product.getQuantity() - 1);
	}
}
