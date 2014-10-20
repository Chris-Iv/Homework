import java.util.Scanner;


public class _26_Problem2 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		int[] entry = new int[n];
		boolean no = false;
		for (int i = 0; i < n; i++) {
			int num = input.nextInt();
			entry[i] = num;
		}
		for (int i = 0; i < entry.length; i++) {
			int a = entry[i];
			for (int j = 0; j < entry.length; j++) {
				int b = entry[j];
				if (a <= b) {
					for (int k = 0; k < entry.length; k++) {
						int c = entry[k];
						if (a*a + b*b == c*c) {
							System.out.printf("%d*%d + %d*%d = %d*%d"
									, a, a, b, b, c, c);
							System.out.println();
							no = true;
						}
					}
				}
			}
		}
		if (!no) {
			System.out.println("No");
		}
	}

}
