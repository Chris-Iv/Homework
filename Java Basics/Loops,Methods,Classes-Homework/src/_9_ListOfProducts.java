import java.io.BufferedReader;
import java.io.FileReader;
import java.io.Writer;
import java.util.ArrayList;
import java.util.Collections;
import java.io.BufferedWriter;
import java.io.FileWriter;


public class _9_ListOfProducts {

	public static void main(String[] args) {
		ArrayList<Product> products = new ArrayList<Product>();
		BufferedReader reader;
		Writer writer = null;
		try {
			reader = new BufferedReader(new FileReader("Input.txt"));
			String line;
			while ((line = reader.readLine()) != null) {
				String[] split = line.split(" ");
				products.add(new Product(split[0], Double.parseDouble(split[1])));
			}
			Collections.sort(products);
			writer = new BufferedWriter(new FileWriter("Output.txt"));
			for (Product product : products) {
				writer.write(product.getPrice() + " " + product.getName() + "\r\n");
			}
		} catch (Exception ex) {
			System.out.println("Error");
		} finally {
			try {writer.close();} catch (Exception ex) {}
		}
	}

}

class Product implements Comparable<Product>{
	private String name;
	private double price;
	public Product(String name, double price) {
		this.name = name;
		this.price = price;
	}
	public String getName() {
		return name;
	}
	public double getPrice() {
		return price;
	}
	public int compareTo(Product compareFruit) {
		double otherPrice = ((Product) compareFruit).getPrice();
		if (this.price>otherPrice) {
			return 1;
		} else if (this.price==otherPrice) {
			return 0;
		} else {
			return -1;
		}
	}
}