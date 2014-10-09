import java.util.Scanner;


public class _2_Generate3LetterWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String entry = input.next();
		char[] letters = entry.toCharArray();
		for (int i = 0; i < letters.length; i++) {
			for (int j = 0; j < letters.length; j++) {
				for (int m = 0; m < letters.length; m++) {
					System.out.printf("%c%c%c ", letters[i], letters[j], letters[m]);
				}
			}
		}
	}

}
