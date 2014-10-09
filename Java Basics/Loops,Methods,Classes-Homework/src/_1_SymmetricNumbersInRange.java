import java.util.Scanner;


public class _1_SymmetricNumbersInRange {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int start = input.nextInt();
		int stop = input.nextInt();
		for (int i = start; i <= stop; i++) {
			char[] arr = Integer.toString(i).toCharArray();
			boolean symetric = true;
			for (int j = 0, m = 1; j < arr.length/2; j++, m++) {
				if (symetric) {
					if (arr[j] != arr[arr.length-m]) {
						symetric = false;
					}
				}
			}
			if (symetric) {
				System.out.print(i + " ");
			}
		}
	}

}
