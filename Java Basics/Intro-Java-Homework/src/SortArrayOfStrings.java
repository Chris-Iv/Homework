import java.util.Arrays;
import java.util.Scanner;

public class SortArrayOfStrings {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		int n = scan.nextInt();
		String[] words = new String[n];
		for (int i = 0; i < n; i++) {
			words[i] = scan.next();
		}
		Arrays.sort(words);
		for (int i = 0; i < n; i++) {
			System.out.println(words[i]);
		}
		scan.close();
	}

}
