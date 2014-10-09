import java.util.Scanner;


public class _7_CountOfBitsOne {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		int counter = 0;
		String bin = Integer.toBinaryString(n);
		for (int i = 0; i < bin.length(); i++) {
			if (bin.charAt(i) == '1') {
				counter++;
			}
		}
		System.out.println(counter);
	}
}
