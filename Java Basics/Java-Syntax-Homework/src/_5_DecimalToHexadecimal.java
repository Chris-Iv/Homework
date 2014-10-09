import java.util.Scanner;


public class _5_DecimalToHexadecimal {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int num = input.nextInt();
		String hex = Integer.toHexString(num);
		System.out.println(hex);
	}

}
