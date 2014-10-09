import java.util.Scanner;


public class _6_FormattingNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int a = input.nextInt();
		double b = input.nextDouble();
		double c = input.nextDouble();
		String hex = Integer.toHexString(a).toUpperCase();
		String bin = String.format("%10s", Integer.toBinaryString(a)).replace(' ', '0');
		String format = "|%-10s|%s|%10.2f|%-10.3f|";
		System.out.printf(format, hex, bin, b, c);
	}

}