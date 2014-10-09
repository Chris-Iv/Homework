import java.util.Scanner;


public class _06_CountSpecifiedWord {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String entry = input.nextLine().toLowerCase();
		String word = input.nextLine().toLowerCase();
		String[] text = entry.split("\\W+");
		int counter = 0;
		for (int i = 0; i < text.length; i++) {
			if (text[i].equals(word)) {
				counter++;
			}
		}
		System.out.println(counter);
	}

}
