import java.util.Scanner;


public class _07_CountSubstringOccurences {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String entry = input.nextLine().toLowerCase();
		String subStr = input.nextLine().toLowerCase();
		int counter = 0;
		for (int i = 0; i < entry.length() - subStr.length(); i++) {
			if (entry.substring(0 + i, subStr.length() + i).contains(subStr)) {
				counter++;
			}
		}
		System.out.println(counter);
	}

}
