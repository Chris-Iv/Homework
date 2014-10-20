package onelvShop;

public class ProductHasExpiredException extends ProductManagementException {
	public ProductHasExpiredException() {
		super("This product has expired");
	}
}
